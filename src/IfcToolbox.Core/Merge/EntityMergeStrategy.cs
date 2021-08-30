using IfcToolbox.Core.Analyse;
using IfcToolbox.Core.Editors;
using IfcToolbox.Core.Extensions;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;

namespace IfcToolbox.Core.Merge
{
    public class EntityMergeStrategy
    {
        #region Reverse Entities Strategy
        public HashSet<IPersistEntity> MergeEntities(IModel model, IEnumerable<IPersistEntity> entities, bool logDetail, bool isTerminal = false)
        {
            var relatedEntities = new HashSet<IPersistEntity>();
            var updatedEntities = new HashSet<IPersistEntity>();

            if (!entities.Any())
                return relatedEntities;

            var filtedEntities = entities;
            if (isTerminal)
                filtedEntities = entities.Where(x => !x.HasReference());

            var typedGroups = filtedEntities.GroupBy(x => x.ExpressType).Where(x => x.ToList().Count > 1);
            foreach (var typedGroup in typedGroups)
                MergeEntitiesByType(model, typedGroup.ToList(), relatedEntities, updatedEntities, logDetail);

            if (!updatedEntities.Any())
                return new HashSet<IPersistEntity>();

            return relatedEntities;
        }

        private void MergeEntitiesByType(IModel model, IList<IPersistEntity> entities, HashSet<IPersistEntity> relatedEntities, HashSet<IPersistEntity> updatedEntities, bool logDetail)
        {
            var duplicationDic = entities.FindDuplications();
            if (!duplicationDic.Any())
                return;

            var entityMap = EntityMergeMap.FromDuplicatedGroups(duplicationDic);
            if (entityMap.Count > 0)
            {
                //need to find all reversed entities for merged and original together.
                var allRelatedEntities = EntityMergeMap.GetAllRelated(entityMap);
                var reversedEntities = new EntityReverser().GetReversedEntities(model, allRelatedEntities).SelectMany(x => x.Value);
                foreach (var reversedEntity in reversedEntities)
                    relatedEntities.Add(reversedEntity);
                foreach (var entityMapKey in entityMap.Keys)
                    updatedEntities.Add(entityMapKey);

                new EntityReplacer().ReplaceEntities(model, entities, entityMap);

                if (logDetail)
                    EntityMergeMap.LogDetail(entityMap);
            }
        }
        #endregion

        #region Global Types Strategy
        public void MergeGlobalType(IModel model, IList<IPersistEntity> entities, bool logDetail)
        {
            var duplicationDic = entities.FindDuplications();
            if (!duplicationDic.Any())
                return;

            var entityMap = EntityMergeMap.FromDuplicatedGroups(duplicationDic);
            if (entityMap.Count > 0)
            {
                new EntityReplacer().ReplaceEntities(model, entities, entityMap);
                if (logDetail)
                    EntityMergeMap.LogDetail(entityMap);
            }
        }
        #endregion
    }
}
