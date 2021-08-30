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

namespace IfcToolbox.Core.Editors
{
    public class EntityReplacer
    {
        private readonly ConcurrentDictionary<Type, List<ReferingType>> ReferingTypesListsCache =
            new ConcurrentDictionary<Type, List<ReferingType>>();

        private readonly ConcurrentDictionary<Type, ReferingType> ReferingTypesCache =
            new ConcurrentDictionary<Type, ReferingType>();

        private struct ReferingType
        {
            public ExpressType Type;
            public List<ExpressMetaProperty> SingleReferences;
            public List<ExpressMetaProperty> ListReferences;
            public List<ExpressMetaProperty> NestedListReferences;
        }

        public void ReplaceEntities(IModel model, IEnumerable<IPersistEntity> entities, Dictionary<IPersistEntity, IPersistEntity> entityMap)
        {
            var uniqueTypes = new HashSet<Type>(entities.Select(e => e.GetType()));
            var referingTypes = new HashSet<ReferingType>(uniqueTypes.SelectMany(t => GetReferingTypes(model, t)));

            foreach (var referingType in referingTypes)
                ReplaceReferences<IPersistEntity, IPersistEntity>(model, entities, referingType, entityMap);
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
        private static void ReplaceReferences<TEntity, TReplacement>(IModel model, IEnumerable<TEntity> entities, ReferingType referingType, Dictionary<IPersistEntity, IPersistEntity> entityMap)
                where TEntity : IPersistEntity where TReplacement : TEntity
        {
            if (entities == null || !entities.Any())
                return;

            // use hash set for quick object reference matching
            var hash = new HashSet<object>(entities.Cast<object>());

            // mapped elements hash set
            var hashMap = new HashSet<int>(entityMap.Keys.Select(x => x.EntityLabel));

            //get all instances of this type and nullify and remove the entity
            var entitiesToCheck = model.Instances.OfType(referingType.Type.Type.Name, true);
            foreach (var toCheck in entitiesToCheck)
            {
                //check properties
                foreach (var pInfo in referingType.SingleReferences.Select(p => p.PropertyInfo))
                {
                    var pVal = pInfo.GetValue(toCheck);
                    if (pVal == null && entityMap == null)
                        continue;

                    //it is enough to compare references
                    if (!hash.Contains(pVal)) continue;

                    var pEntity = pVal as IPersistEntity;
                    if (!hashMap.Contains(pEntity.EntityLabel)) continue;

                    pInfo.SetValue(toCheck, entityMap[pEntity]);
                }

                foreach (var pInfo in referingType.ListReferences.Select(p => p.PropertyInfo))
                {
                    var pVal = pInfo.GetValue(toCheck);
                    if (pVal == null) continue;

                    //it might be uninitialized optional item set
                    if (pVal is IOptionalItemSet optSet && !optSet.Initialized)
                        continue;

                    //or it is non-optional item set implementing IList
                    if (!(pVal is IList itemSet))
                        throw new XbimException($"Unable to remove items from {referingType.Type.Name}.{pInfo.Name}. No IList implementation.");

                    TryReplaceInList(toCheck, itemSet);
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

                    for (int j = 0; j < nestedItemSet.Count; j++)
                    {
                        if (!(nestedItemSet[j] is IList itemSet))
                            throw new XbimException($"Unable to remove items from {referingType.Type.Name}.{pInfo.Name}. No IList implementation.");

                        TryReplaceInList(toCheck, itemSet);
                    }
                }
            }

            //try replace
            void TryReplaceInList(IPersistEntity toCheck, IList itemSet)
            {
                for (int i = 0; i < itemSet.Count; i++)
                {
                    var item = itemSet[i];
                    if (!hash.Contains(item)) continue;

                    var pEntity = item as IPersistEntity;
                    if (!hashMap.Contains(pEntity.EntityLabel)) continue;

                    itemSet.RemoveAt(i);
                    if (entityMap[pEntity] != null)
                        itemSet.Insert(i, entityMap[pEntity]);
                    else
                        i--; // keep in sync
                }
            }
        }
    }
}