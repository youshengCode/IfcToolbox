using IfcToolbox.Core.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;

namespace IfcToolbox.Core.Extensions
{
    public static class EntityExtension
    {
        public static bool PropertiesEquals(this IPersistEntity self, IPersistEntity other)
        {
            return new EntityPropertiesComparer().Equals(self, other);
        }

        public static bool HasReference(this IPersistEntity entity)
        {
            var metaProperties = entity.ExpressType.Properties.Values.Where(p =>
                        p.EntityAttribute != null && p.EntityAttribute.Order > 0);

            foreach (var pInfo in metaProperties.Select(p => p.PropertyInfo))
            {
                var pVal = pInfo.GetValue(entity);
                if (pVal == null)
                    continue;
                if (pVal is IOptionalItemSet optSet && !optSet.Initialized)
                    continue;

                if (pVal is IPersistEntity pEntity)
                    return true;
                else if (pVal is IList itemSet)
                    foreach (var item in itemSet)
                        if (item is IPersistEntity pEntityInList)
                            return true;
            }
            return false;
        }

        public static Dictionary<IPersistEntity, IEnumerable<IPersistEntity>> FindDuplications(this IEnumerable<IPersistEntity> entities)
        {
            return EntityDuplications.FindDuplications(entities);
        }
    }
}
