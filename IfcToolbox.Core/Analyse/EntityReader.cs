using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xbim.Common;
using Xbim.Ifc;
using Xbim.Ifc4.Interfaces;

namespace IfcToolbox.Core.Analyse
{
    public class EntityReader
    {
        public static List<string> GetInfo(IPersistEntity entity)
        {
            // Returns a list with required entity information (STEP-hash number, Entity type).
            var info = new List<string> { { "#" + entity.GetHashCode() }, { entity.GetType().Name }, };
            // For reference objects with own IFC-id (inherited from IfcRoot) also the id will be returned
            if (entity is IIfcRoot)
                info.Add((entity as IIfcRoot).GlobalId);
            return info;
        }
        public static IIfcProject GetIfcProject(IfcStore model)
        {
            return model.Instances.OfType<IIfcProject>().ToList().FirstOrDefault();
        }
        public static IIfcGeometricRepresentationContext GetPresentationContext(IIfcProject project)
        {
            //includes also inherited SubContexts (not necessary for this application)
            var allCtx = project.RepresentationContexts.OfType<IIfcGeometricRepresentationContext>();
            if (allCtx != null)
            {
                //avoid subs (unneccessary overhead)
                var noSubCtx = allCtx.Where(ctx => ctx.ExpressType.ToString() != "IfcGeometricRepresentationSubContext").ToList();
                if (noSubCtx != null)
                {
                    //get only the context for model
                    var projectCtx = noSubCtx.Where(a => a.ContextType == "Model").SingleOrDefault();
                    return projectCtx;
                }
            }
            return null;
        }
        public static IIfcPropertySet GetPropertySetWithName(IfcStore model, string pSetName)
        {
            return model.Instances.OfType<IIfcPropertySet>()
                .Where(p => p.Name.ToString().Contains(pSetName)).ToList().FirstOrDefault();
        }
        public static List<IIfcProduct> GetRootProducts(IfcStore model)
        {
            // A list of from IfcProduct inherited entities with global placement.
            // Valid IFC-files should contain at least one, the IfcSite entity.
            return model.Instances.Where<IIfcLocalPlacement>(e => e.PlacementRelTo == null)
                .SelectMany(e => e.PlacesObject).ToList();
        }

        #region PropertyReader
        public static double GetPropValueToDouble(IIfcPropertySet pset, string propName)
        {
            var prop = (pset.HasProperties.Where(p => p.Name == propName).SingleOrDefault() as IIfcPropertySingleValue);
            var propVal = prop.NominalValue.ToString();
            var val = double.TryParse(propVal, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out double doubleVal);
            //var val = double.TryParse(propVal, out double doubleVal);
            return doubleVal;
        }
        public static string GetPropValueToString(IIfcPropertySet pset, string propName)
        {
            var prop = (pset.HasProperties.Where(p => p.Name == propName).SingleOrDefault() as IIfcPropertySingleValue);
            var propVal = prop.NominalValue.ToString();
            return propVal;
        }
        #endregion
    }

}
