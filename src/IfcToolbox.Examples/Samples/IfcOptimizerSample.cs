using IfcToolbox.Tools.Configurations;
using IfcToolbox.Tools.Processors;
using Serilog;

namespace IfcToolbox.Examples.Samples
{
    class IfcOptimizerSample
    {
        public static void Optimize(string filePath)
        {
            Log.Information($"IfcOptimizer - Start");
            IConfigOptimize config = ConfigFactory.CreateConfigOptimize();
            config.PrecisionOpen = true;
            config.Precision = 4;
            config.OptimizePoint = true;
            config.OptimizePointList = true;
            config.MergeOpen = true;
            config.MergeOnlyResources = true;
            config.MergeReversedEntities = true;
            OptimizerProcessor.Process(filePath, config, true);
        }
    }

}
