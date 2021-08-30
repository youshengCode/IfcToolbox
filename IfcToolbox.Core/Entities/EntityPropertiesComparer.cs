using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;

namespace IfcToolbox.Core.Entities
{
    public sealed class EntityPropertiesComparer : IEqualityComparer<IPersistEntity>
    {
        // Ignore nested list props value for perf reason.
        public bool Equals(IPersistEntity self, IPersistEntity other)
        {
            if (self.ExpressType != other.ExpressType)
                return false;

            var metaProperties = self.ExpressType.Properties.Values.Where(p =>
                        p.EntityAttribute != null && p.EntityAttribute.Order > 0);

            foreach (var pInfo in metaProperties.Select(p => p.PropertyInfo))
            {
                var pValSelf = pInfo.GetValue(self);
                var pValOther = pInfo.GetValue(other);
                if (pValSelf == null && pValOther == null)
                    continue;
                if (pValSelf is IList selfItems && pValOther is IList otherItems)
                {
                    if (selfItems.Count != otherItems.Count)
                        return false;
                    for (int i = 0; i < selfItems.Count; i++)
                    {
                        var seltItem = selfItems[i];
                        var otherItem = otherItems[i];
                        if (seltItem == null && otherItem == null)
                            continue;
                        if (seltItem != null && !seltItem.Equals(otherItem))
                            return false;
                    }
                    continue;
                }
                if (pValSelf != pValOther)
                    return false;
            }
            return true;
        }

        public int GetHashCode(IPersistEntity obj)
        {
            return obj.ExpressType == null ? 0 : obj.ExpressType.GetHashCode();
        }
    }
}
