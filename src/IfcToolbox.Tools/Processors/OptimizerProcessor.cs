using IfcToolbox.Core.Editors;
using IfcToolbox.Core.Merge;
using IfcToolbox.Core.Utilities;
using IfcToolbox.Tools.Configurations;
using Serilog;
using Xbim.Common;
using Xbim.Common.Delta;
using Xbim.Ifc;

namespace IfcToolbox.Tools.Processors
{
    public class OptimizerProcessor
    {
        public static IProcessorResult Process(string filePath, IConfigOptimize config, bool consoleMode = false)
        {
            if (consoleMode)
                Marslogger.Step($"{filePath} in processing");
            var processorResult = ProcessorResultFactory.CreateNew();
            using (var watch = new Superwatch())
            using (var model = IfcStore.Open(filePath))
            {
                using (var txn = model.BeginTransaction("Modification"))
                {
                    if (consoleMode)
                    {
                        Log.Information($"IFC Schema - {model.SchemaVersion}");
                        Marslogger.Step("Processing...");
                    }
                    using (var log = new TransactionLog(txn))
                    {
                        GeometryOptimization(model, config);
                        MergeDuplication(model, config);

                        txn.Commit();
                        processorResult.Success = true;
                        if (config.LogDetail && consoleMode)
                            Marslogger.PrintChanges(log, config.LogDetail);
                    }
                }
                var generatedFilePath = ConsoleFile.AddSuffixToName(filePath, "_" + config.Suffix);
                InsertCopy.SaveAs(model, generatedFilePath, config.DeleteOld, config.KeepLabel);
                processorResult.FilePaths.Add(generatedFilePath);
                return processorResult;
            }
        }

        public static void GeometryOptimization(IModel model, IConfigOptimize config)
        {
            if (model.SchemaVersion == Xbim.Common.Step21.XbimSchemaVersion.Ifc4
                || model.SchemaVersion == Xbim.Common.Step21.XbimSchemaVersion.Ifc4x1)
            {
                if (config.OptimizePoint)
                {
                    var mergedMap = PointOptimization.OptimizePoints(model, model.Instances.OfType<Xbim.Ifc4.Interfaces.IIfcCartesianPoint>(), config.PrecisionOpen, config.Precision);
                    if (config.LogDetail)
                        PointOptimization.LogMergeMap(mergedMap);
                }
                if (config.OptimizePointList)
                {
                    var mergedMap = PointOptimization.OptimizePointLists(model, config.PrecisionOpen, config.Precision);
                    if (config.LogDetail)
                        PointOptimization.LogMergeMap(mergedMap);
                }
            }
            else if (model.SchemaVersion == Xbim.Common.Step21.XbimSchemaVersion.Ifc2X3)
            {
                if (config.OptimizePoint)
                {
                    var mergedMap = PointOptimization.OptimizePoints(model, model.Instances.OfType<Xbim.Ifc2x3.Interfaces.IIfcCartesianPoint>(), config.PrecisionOpen, config.Precision);
                    if (config.LogDetail)
                        PointOptimization.LogMergeMap(mergedMap);
                }
            }
        }
        public static void MergeDuplication(IModel model, IConfigOptimize config)
        {
            if (!config.MergeOpen)
                return;
            if (config.MergeReversedEntities)
            {
                IEntitiyMergeStrategy strategyRE = new MergeStrategyRE(); // Reverse Entities
                strategyRE.Merge(model, config.LogDetail);
                IEntitiyMergeStrategy strategyUT = new MergeStrategyUT(); // Upper Types
                strategyUT.Merge(model, config.LogDetail);
                return;
            }
            if (config.MergeOnlyResources)
            {
                IEntitiyMergeStrategy strategyOR = new MergeStrategyOR(); // Only Resources
                strategyOR.Merge(model, config.LogDetail);
                IEntitiyMergeStrategy strategyUT = new MergeStrategyUT(); // Upper Types
                strategyUT.Merge(model, config.LogDetail);
                return;
            }
        }

    }
}
