using IfcToolbox.Tools.Configurations;
using IfcToolbox.Tools.Processors;
using Serilog;
using System.Collections.Generic;

namespace IfcToolbox.Examples.Samples
{
    public class IfcSplitterSample
    {
        public static void SplitByBuildingStorey(string filePath)
        {
            Log.Information($"IfcSplitter - Start");
            IConfigSplit config = ConfigFactory.CreateConfigSplit();
            config.LogDetail = true;
            config.SplitStrategy = SplitStrategy.ByBuildingStorey;
            config.SelectedItems = new List<string> { "137", "131" };
            SplitterProcessor.Process(filePath, config, true);
        }
    }
}
