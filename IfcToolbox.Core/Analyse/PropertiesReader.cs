using System.Collections.Generic;
using System.Linq;
using Xbim.Ifc4.Interfaces;

namespace IfcToolbox.Core.Analyse
{
    public static class PropertiesReader
    {
        public static IEnumerable<IIfcPropertySingleValue> GetAllProperties(IIfcProduct product)
        {
            var props = product.IsDefinedBy
                .SelectMany(r => r.RelatingPropertyDefinition.PropertySetDefinitions)
                .OfType<IIfcPropertySet>()
                .SelectMany(pset => pset.HasProperties)
                .OfType<IIfcPropertySingleValue>();
            return props;
        }

        public static IEnumerable<IIfcPhysicalQuantity> GetAllQuantities(IIfcProduct product)
        {
            var quans = product.IsDefinedBy
                .SelectMany(r => r.RelatingPropertyDefinition.PropertySetDefinitions)
                .OfType<IIfcElementQuantity>()
                .SelectMany(qto => qto.Quantities)
                .OfType<IIfcPhysicalQuantity>();
            return quans;
        }

        public static IEnumerable<IIfcPropertySingleValue> GetTypeProperties(IIfcProduct product)
        {
            var props = product.IsTypedBy
                .Select(t => t.RelatingType)
                .SelectMany(pset => pset.HasPropertySets)
                .OfType<IIfcPropertySet>()
                .SelectMany(pset => pset.HasProperties)
                .OfType<IIfcPropertySingleValue>();
            return props;
        }
    }
}
