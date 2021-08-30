using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xbim.Common;
using Xbim.Common.Metadata;
using Xbim.IO;

namespace IfcToolbox.Core.Extensions
{
    public static class ExpressTypeExtension
    {
        public static IList<ExpressType> GetRelatedTypes(this ExpressType entityType, IModel model)
        {
            var relatedTypes = new List<ExpressType>();
            //find all potential references
            var types = model.Metadata.Types().Where(t => typeof(IInstantiableEntity).GetTypeInfo().IsAssignableFrom(t.Type));

            foreach (var type in types)
            {
                if (!relatedTypes.Contains(type))
                {
                    var singleReferences = type.Properties.Values.Where(p =>
                        p.EntityAttribute != null && p.EntityAttribute.Order > 0 &&
                        p.PropertyInfo.PropertyType.GetTypeInfo().IsAssignableFrom(entityType.Type)).ToList();
                    var listReferences = type.Properties.Values.Where(p =>
                        p.EntityAttribute != null && p.EntityAttribute.Order > 0 &&
                        p.PropertyInfo.PropertyType.GetTypeInfo().IsGenericType &&
                        p.PropertyInfo.PropertyType.GenericTypeArgumentIsAssignableFrom(entityType.Type)).ToList();
                    if (!singleReferences.Any() && !listReferences.Any())
                        continue;
                    relatedTypes.Add(type);
                }
            }
            return relatedTypes;
        }

        public static HashSet<ExpressType> GetRelatedTypes(this IEnumerable<ExpressType> entityTypes, IModel model)
        {
            var relatedTypes = new HashSet<ExpressType>();
            foreach (var entityType in entityTypes)
            {
                var relatedList = entityType.GetRelatedTypes(model);
                foreach (var related in relatedList)
                    relatedTypes.Add(related);
            }
            return relatedTypes;
        }
    }
}
