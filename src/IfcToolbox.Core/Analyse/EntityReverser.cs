using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Common.Metadata;
using Xbim.IO;

namespace IfcToolbox.Core.Analyse
{
    public class EntityReverser
    {
        private readonly ConcurrentDictionary<Type, List<ReferingType>> ReferingTypesListsCache =
            new ConcurrentDictionary<Type, List<ReferingType>>();

        private readonly ConcurrentDictionary<Type, ReferingType> ReferingTypesCache =
            new ConcurrentDictionary<Type, ReferingType>();

        private ConcurrentDictionary<int, HashSet<IPersistEntity>> InstanceReverseCache =
            new ConcurrentDictionary<int, HashSet<IPersistEntity>>();

        private struct ReferingType
        {
            public ExpressType Type;
            public List<ExpressMetaProperty> SingleReferences;
            public List<ExpressMetaProperty> ListReferences;
            public List<ExpressMetaProperty> NestedListReferences;
        }

        public Dictionary<int, HashSet<IPersistEntity>> GetReversedEntities(IModel model, IPersistEntity entity)
        {
            return GetReversedEntities(model, new List<IPersistEntity> { entity });
        }

        public Dictionary<int, HashSet<IPersistEntity>> GetReversedEntities(IModel model, IEnumerable<IPersistEntity> entities)
        {
            var uniqueTypes = new HashSet<Type>(entities.Select(e => e.GetType()));
            var referingTypes = new HashSet<ReferingType>(uniqueTypes.SelectMany(t => GetReferingTypes(model, t)));

            foreach (var entity in entities)
                if (entity != null)
                    InstanceReverseCache.TryAdd(entity.EntityLabel, new HashSet<IPersistEntity>());

            foreach (var referingType in referingTypes)
                GetInstanceReferences<IPersistEntity, IPersistEntity>(model, entities, referingType, null);

            return InstanceReverseCache.ToDictionary(x => x.Key, x => x.Value);
        }

        /// <summary>
        /// Extented from ModelHelper GetReferingTypes
        /// </summary>
        private IEnumerable<ReferingType> GetReferingTypes(IModel model, Type entityType)
        {
            if (ReferingTypesListsCache.TryGetValue(entityType, out List<ReferingType> referingTypes))
                return referingTypes;

            referingTypes = new List<ReferingType>();
            if (!ReferingTypesListsCache.TryAdd(entityType, referingTypes))
            {
                //it is there already (done in another thread)
                return ReferingTypesListsCache[entityType];
            }

            //find all potential references
            var types = model.Metadata.Types().Where(t => typeof(IInstantiableEntity).GetTypeInfo().IsAssignableFrom(t.Type));

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var type in types)
            {
                if (!ReferingTypesCache.TryGetValue(type.Type, out ReferingType rt))
                {
                    var singleReferences = type.Properties.Values.Where(p =>
                        p.EntityAttribute != null && p.EntityAttribute.Order > 0 &&
                        p.PropertyInfo.PropertyType.GetTypeInfo().IsAssignableFrom(entityType)).ToList();
                    var listReferences = type.Properties.Values.Where(p =>
                        p.EntityAttribute != null && p.EntityAttribute.Order > 0 &&
                        p.PropertyInfo.PropertyType.GetTypeInfo().IsGenericType &&
                        p.PropertyInfo.PropertyType.GenericTypeArgumentIsAssignableFrom(entityType)).ToList();
                    var nestedListReferences = type.Properties.Values.Where(p =>
                        p.EntityAttribute != null && p.EntityAttribute.Order > 0 &&
                        p.PropertyInfo.PropertyType.GetTypeInfo().IsGenericType &&
                        p.PropertyInfo.PropertyType.GetItemTypeFromGenericType().IsGenericType &&
                        p.PropertyInfo.PropertyType.GetItemTypeFromGenericType().GenericTypeArgumentIsAssignableFrom(entityType)).ToList();
                    if (!singleReferences.Any() && !listReferences.Any() && !nestedListReferences.Any())
                        continue;

                    rt = new ReferingType { Type = type, SingleReferences = singleReferences, ListReferences = listReferences, NestedListReferences = nestedListReferences };
                    ReferingTypesCache.TryAdd(type.Type, rt);
                }
                referingTypes.Add(rt);
            }
            return referingTypes;
        }

        /// <summary>
        /// Extented from ModelHelper ReplaceReferences
        /// </summary>
        private void GetInstanceReferences<TEntity, TReplacement>(IModel model, IEnumerable<TEntity> entities, ReferingType referingType, TReplacement replacement)
                where TEntity : IPersistEntity where TReplacement : TEntity
        {
            if (entities == null || !entities.Any()) return;

            //use hash set for quick object reference matching
            var hash = new HashSet<object>(entities.Cast<object>());

            //mapped elements hash set
            var hashMap = new HashSet<int>(InstanceReverseCache.Keys);

            //get all instances of this type and nullify and remove the entity
            var entitiesToCheck = model.Instances.OfType(referingType.Type.Type.Name, true);
            foreach (var toCheck in entitiesToCheck)
            {
                //check properties
                foreach (var pInfo in referingType.SingleReferences.Select(p => p.PropertyInfo))
                {
                    var pVal = pInfo.GetValue(toCheck);
                    if (pVal == null && replacement == null) continue;

                    TryAdd(pVal, toCheck);
                }

                foreach (var pInfo in referingType.ListReferences.Select(p => p.PropertyInfo))
                {
                    var pVal = pInfo.GetValue(toCheck);
                    if (pVal == null) continue;

                    //it might be uninitialized optional item set
                    if (pVal is IOptionalItemSet optSet && !optSet.Initialized) continue;

                    //or it is non-optional item set implementing IList
                    if (!(pVal is IList itemSet))
                        throw new XbimException($"Unable to remove items from {referingType.Type.Name}.{pInfo.Name}. No IList implementation.");

                    for (int i = 0; i < itemSet.Count; i++)
                        TryAdd(itemSet[i], toCheck);
                }

                foreach (var pInfo in referingType.NestedListReferences.Select(p => p.PropertyInfo))
                {
                    var pVal = pInfo.GetValue(toCheck);
                    if (pVal == null) continue;

                    //it might be uninitialized optional item set
                    if (pVal is IOptionalItemSet optSet && !optSet.Initialized) continue;

                    //or it is non-optional item set implementing IList
                    if (!(pVal is IList nestedItemSet))
                        throw new XbimException($"Unable to remove items from {referingType.Type.Name}.{pInfo.Name}. No IList implementation.");

                    for (int i = 0; i < nestedItemSet.Count; i++)
                    {
                        if (!(nestedItemSet[i] is IList itemSet))
                            throw new XbimException($"Unable to remove items from {referingType.Type.Name}.{pInfo.Name}. No IList implementation.");

                        for (int j = 0; j < itemSet.Count; j++)
                            TryAdd(itemSet[j], toCheck);
                    }
                }
            }

            //try add cache 
            void TryAdd(object item, IPersistEntity toCheck)
            {
                if (!hash.Contains(item)) return;
                var pEntity = item as IPersistEntity;

                if (!hashMap.Contains(pEntity.EntityLabel)) return;
                InstanceReverseCache[pEntity.EntityLabel].Add(toCheck);
            }
        }
    }
}
