using Xbim.Common;
using Xbim.Ifc4.Interfaces;

namespace IfcToolbox.Core.Editors
{
    static class PropertyFilter
    {
        public static PropertyTranformDelegate GetOnlyGeometry()
        {
            PropertyTranformDelegate semanticFilter = (property, parentObject) =>
            {
                //only bring over IsDefinedBy and IsTypedBy inverse relationships which will take over all properties and types
                if (property.EntityAttribute.Order < 0 && !(
                    property.PropertyInfo.Name == "IsDefinedBy" ||
                    property.PropertyInfo.Name == "IsTypedBy"))
                    return null;
                return property.PropertyInfo.GetValue(parentObject, null);
            };
            return semanticFilter;
        }

        public static PropertyTranformDelegate GetOnlyPropInfo()
        {
            PropertyTranformDelegate semanticFilter = (property, parentObject) =>
            {
                //leave out geometry and placement
                if (parentObject is IIfcProduct &&
                    (property.PropertyInfo.Name == nameof(IIfcProduct.Representation) ||
                    property.PropertyInfo.Name == nameof(IIfcProduct.ObjectPlacement)))
                    return null;
                //leave out mapped geometry
                if (parentObject is IIfcTypeProduct &&
                    property.PropertyInfo.Name == nameof(IIfcTypeProduct.RepresentationMaps))
                    return null;
                //only bring over IsDefinedBy and IsTypedBy inverse relationships which will take over all properties and types
                if (property.EntityAttribute.Order < 0 && !(
                    property.PropertyInfo.Name == nameof(IIfcProduct.IsDefinedBy) ||
                    property.PropertyInfo.Name == nameof(IIfcProduct.IsTypedBy)))
                    return null;
                return property.PropertyInfo.GetValue(parentObject, null);
            };
            return semanticFilter;
        }
    }
}
