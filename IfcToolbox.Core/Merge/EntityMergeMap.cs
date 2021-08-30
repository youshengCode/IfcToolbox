using Serilog;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;

namespace IfcToolbox.Core.Merge
{
    public class EntityMergeMap
    {
        public static Dictionary<IPersistEntity, IPersistEntity> FromDuplicatedGroups(Dictionary<IPersistEntity, IEnumerable<IPersistEntity>> duplicatedGroups)
        {
            var entityMap = new Dictionary<IPersistEntity, IPersistEntity>();
            foreach (var duplicatedGroup in duplicatedGroups)
                foreach (var duplicatedEntity in duplicatedGroup.Value)
                    if (duplicatedEntity.EntityLabel != duplicatedGroup.Key.EntityLabel)
                        entityMap.Add(duplicatedEntity, duplicatedGroup.Key);
            return entityMap;
        }

        public static IEnumerable<IPersistEntity> GetAllRelated(Dictionary<IPersistEntity, IPersistEntity> entityMap)
        {
            var related = entityMap.Keys.ToList();
            var hash = new HashSet<IPersistEntity>();
            foreach (var item in entityMap.Values)
                hash.Add(item);
            related.AddRange(hash);
            return related;
        }

        public static void LogDetail(Dictionary<IPersistEntity, IPersistEntity> mergeMap)
        {
            if (!mergeMap.Any())
                return;
            Log.Information("Current Type --- {@typeName}", mergeMap.Keys.First().ExpressType.Type.Name);
            Log.Information("MergeMap Count: {@count}", mergeMap.Count());
            foreach (var item in mergeMap)
                Log.Information($"Mapping: {item.Key} --> {item.Value}");
        }
    }
}
