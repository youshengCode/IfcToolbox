using IfcToolbox.Core.Geo;
using IfcToolbox.Core.Utilities;
using IfcToolbox.Tools.Configurations;
using Serilog;
using Xbim.Ifc;

namespace IfcToolbox.Tools.Processors
{
    public class AnalyseProcessor
    {
        public static IGeoReference GetGeoReference(string filePath, IConfigBase config = null, bool consoleMode = false)
        {
            if (config == null)
                config = ConfigFactory.CreateConfigBase();
            if (consoleMode)
                Marslogger.Step($"{filePath} in processing");
            using var watch = new Superwatch();
            using var model = IfcStore.Open(filePath);
            if (consoleMode)
            {
                Log.Information($"IFC Schema - {model.SchemaVersion}");
                Marslogger.Step("Processing...");
            }
            var result = GeoAnalyser.GetGeoReference(model, config.LogDetail);
            return result;
        }
    }
}
