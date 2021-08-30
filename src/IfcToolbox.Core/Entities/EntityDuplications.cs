using System.Collections.Generic;
using System.Linq;
using Xbim.Common;

namespace IfcToolbox.Core.Entities
{
    public static class EntityDuplications
    {
        public static Dictionary<IPersistEntity, IEnumerable<IPersistEntity>> FindDuplications(IEnumerable<IPersistEntity> entities)
        {
            var duplications = new Dictionary<IPersistEntity, IEnumerable<IPersistEntity>>();
            if (!entities.Any())
                return duplications;

            var entityProxyList = new List<EntityProxy>();
            foreach (var entity in entities)
                entityProxyList.Add(new EntityProxy(entity));

            var proxyDic = new Dictionary<EntityProxy, IList<EntityProxy>>();
            foreach (var entityProxy in entityProxyList)
            {
                if (proxyDic.TryGetValue(entityProxy, out var elements))
                {
                    elements.Add(entityProxy);
                    continue;
                }
                proxyDic.Add(entityProxy, new List<EntityProxy>());
            }

            duplications = proxyDic.Where(x => x.Value.Count > 0)
                .ToDictionary(group => group.Key.Entity, group => group.Value.Select(x => x.Entity));
            return duplications;
        }
    }
}
