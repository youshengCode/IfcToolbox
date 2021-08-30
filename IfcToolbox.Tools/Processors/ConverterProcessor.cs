using IfcToolbox.Core.Convert;
using IfcToolbox.Core.Hierarchy;
using IfcToolbox.Core.Utilities;
using IfcToolbox.Tools.Configurations;
using System.IO;
using System.Reflection;
using Xbim.Ifc;

namespace IfcToolbox.Tools.Processors
{
    public class ConverterProcessor
    {
        public static SpatialTrees Analyse(string filePath, IConfigBase config = null, bool consoleMode = false)
        {
            if (config == null)
                config = ConfigFactory.CreateConfigBase();
            if (consoleMode)
                Marslogger.Step($"{filePath} in processing");
            using var watch = new Superwatch();
            using var model = IfcStore.Open(filePath);
            if (consoleMode)
                Marslogger.Step("Processing...");
            var result = TreesReader.GetOnlyTypedNodes(model, true);
            return result;
        }

        public static IProcessorResult Process(string filePath, IConfigConvert config, bool consoleMode = false)
        {
            if (consoleMode)
                Marslogger.Step($"{filePath} in processing");
            var processorResult = ProcessorResultFactory.CreateNew();
            using (var watch = new Superwatch())
            {
                if (consoleMode)
                    Marslogger.Step("Processing...");

                if (!config.UseExternalResource)
                    ReflectionUtility.CopyEmbeddedResource(typeof(IfcConvert).GetTypeInfo().Assembly, IfcConvert.ExecutableName);

                string targetFilePath = Path.ChangeExtension(filePath, "." + config.TargetFormat.ToString().ToLower());
                string logFilePath = Path.ChangeExtension(filePath, ".txt");
                // Log file need clean up each time.
                if (File.Exists(logFilePath))
                    File.Delete(logFilePath);
                var finalFiles = IfcConvert.Convert(filePath, targetFilePath, config.ConvertOptions, config.TargetFormat, logFilePath, consoleMode, config.ExternalWorkingDirectory);
                
                foreach (var finalFile in finalFiles)
                    processorResult.FilePaths.Add(finalFile);
                processorResult.Success = true;

                return processorResult;
            }
        }
    }
}
