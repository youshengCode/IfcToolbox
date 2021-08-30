using IfcToolbox.Core.Entities;
using IfcToolbox.Core.Hierarchy;
using Serilog;
using Xbim.Common;
using Xbim.Ifc;

namespace IfcToolbox.Core.Analyse
{
    public class EntityAnalyse
    {
        public static void AnalyseEntityFrequency(string filePath, bool logDetail = false, bool propsAndType = false)
        {
            using (var model = IfcStore.Open(filePath))
            {
                var entities = model.Instances.OfType<IPersistEntity>();
                var frequencyAnalyse = new EntityFrequencyAnalyse();
                frequencyAnalyse.AddOccurences(entities);
                if (logDetail)
                {
                    //frequencyAnalyse.IgnoreLessThan(300);
                    frequencyAnalyse.Sort();
                    frequencyAnalyse.LogDetails(true, propsAndType, propsAndType);
                }
            }
        }

        public static void AnalyseHierarchy(string filePath, bool logDetail = false)
        {
            using (var model = IfcStore.Open(filePath))
            {
                Log.Information(HierarchyReader.GetFullHierarchy(model, true, true).Show(true));
                Log.Information(HierarchyReader.GetTypedHierarchy(model, true).Show(true));
                //Log.Information(HierarchyReader.GetSpatialHierarchy(model, "IfcSite").Show(true));
                //Log.Information(HierarchyReader.GetSpatialHierarchy(model, "IfcBuildingStorey").Show(true));
            }
        }
    }
}
