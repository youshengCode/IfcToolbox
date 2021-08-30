using IfcToolbox.Core.Editors;
using IfcToolbox.Core.Hierarchy;
using IfcToolbox.Core.Utilities;
using IfcToolbox.Tools.Configurations;
using System.Collections.Generic;
using Xbim.Ifc;

namespace IfcToolbox.Tools.Processors
{
    public class SplitterProcessor
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
            var result = TreesReader.GetSpatialTrees(model);
            return result;
        }

        public static IProcessorResult Process(string filePath, IConfigSplit config, bool consoleMode = false)
        {
            if (consoleMode)
                Marslogger.Step($"{filePath} in processing");
            var processorResult = ProcessorResultFactory.CreateNew();
            using (var watch = new Superwatch())
            using (var model = IfcStore.Open(filePath))
            {
                if (consoleMode)
                    Marslogger.Step("Processing...");
                // Already added the suffix to name in the Split methode.
                var filePathsWithSuffix = Split(model, config, filePath);
                processorResult.FilePaths = filePathsWithSuffix;
                processorResult.Success = true;
                return processorResult;
            }
        }

        public static List<string> Split(IfcStore model, IConfigSplit config, string sourceFilePath)
        {
            switch (config.SplitStrategy)
            {
                case SplitStrategy.ByObjectType:
                    return SubModelGeneration.SplitByObjectType(model, config.KeepLabel, sourceFilePath, config.SelectedItems, config.Suffix);
                case SplitStrategy.ByProduct:
                    return SubModelGeneration.SplitByProduct(model, config.KeepLabel, sourceFilePath, config.SelectedItems, config.Suffix);
                case SplitStrategy.DataOnly:
                    return SubModelGeneration.SplitDataOnly(model, config.KeepLabel, sourceFilePath, config.Suffix);
                case SplitStrategy.ByBuildingStorey:
                    return SubModelGeneration.SplitByBuildingStorey(model, config.KeepLabel, sourceFilePath, config.SelectedItems, config.BuildingStoreyPlaceholder, config.BuildingPlaceholder);
                case SplitStrategy.ByBuilding:
                    return SubModelGeneration.SplitByBuilding(model, config.KeepLabel, sourceFilePath, config.SelectedItems, config.BuildingPlaceholder);
                case SplitStrategy.BySite:
                    return SubModelGeneration.SplitBySite(model, config.KeepLabel, sourceFilePath, config.SelectedItems, config.SitePlaceholder);
                default:
                    return new List<string>();
            }
        }
    }
}
