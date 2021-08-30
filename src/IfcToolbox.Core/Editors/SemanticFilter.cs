using Xbim.Common;

namespace IfcToolbox.Core.Editors
{
    public static class SemanticFilter
    {
        public static PropertyTranformDelegate GetAll()
        {
            PropertyTranformDelegate semanticFilter = (property, parentObject) =>
            {
                return property.PropertyInfo.GetValue(parentObject, null);
            };
            return semanticFilter;
        }
    }
}
