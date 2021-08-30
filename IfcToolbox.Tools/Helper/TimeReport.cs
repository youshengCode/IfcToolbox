using IfcToolbox.Core.Utilities;
using Serilog;
using System.IO;

namespace IfcToolbox.Tools.Helper
{
    public class TimeReport
    {
        public TimeReport(string filePath)
        {
            FileName = Path.GetFileName(filePath);
            ProductCount = TimeEstimator.ProductCount(filePath);
            EntityCount = TimeEstimator.EntityCount(filePath);
        }

        public string FileName { get; set; }
        public int ProductCount { get; set; }
        public int EntityCount { get; set; }
        public double RealProcessingTime { get; set; }
        public double EstimateProcessingTime { get; set; }

        public void AddProcessingTime(double realProcessingTime, double estimateProcessingTime)
        {
            RealProcessingTime = realProcessingTime;
            EstimateProcessingTime = estimateProcessingTime;
        }

        public void LogDetail()
        {
            Log.Information($"{FileName} - {ProductCount} IfcProducts, {EntityCount} IfcEntity");
            Log.Information($"Process Estimate Time - {EstimateProcessingTime} seconds");
            Marslogger.Mark($"Real Processing Time - {RealProcessingTime} seconds");
        }
    }
}
