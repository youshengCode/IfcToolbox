using IfcToolbox.Core.Editors;
using IfcToolbox.Core.Utilities;
using IfcToolbox.Tools.Configurations;
using Serilog;
using Xbim.Common;
using Xbim.Common.Delta;
using Xbim.Ifc;

namespace IfcToolbox.Tools.Processors
{
    public class RelocatorProcessor
    {
        public static IProcessorResult Process(string filePath, IConfigRelocate config, bool consoleMode = false)
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
                        AlignCoordinates(model, config);

                        txn.Commit();
                        processorResult.Success = true;
                        if (config.LogDetail && consoleMode)
                            Marslogger.PrintChanges(log, config.LogDetail);
                    }
                }
                var generatedFilePath = ConsoleFile.AddSuffixToName(filePath, "_" + config.Suffix);
                processorResult.FilePaths.Add(generatedFilePath);
                model.SaveAs(generatedFilePath);
                return processorResult;
            }
        }

        public static void AlignCoordinates(IModel model, IConfigRelocate config)
        {
            if (model.SchemaVersion == Xbim.Common.Step21.XbimSchemaVersion.Ifc4
                || model.SchemaVersion == Xbim.Common.Step21.XbimSchemaVersion.Ifc4x1)
            {
                PointAlignment.AlignCoordinates_Ifc4(model, config.AlignWorldCoordinates, config.AlignProjectCoordinates,
                    config.WorldPlacement, config.ProjectPlacements, config.LogDetail);
            }
            else if (model.SchemaVersion == Xbim.Common.Step21.XbimSchemaVersion.Ifc2X3)
            {
                PointAlignment.AlignCoordinates_Ifc2x3(model, config.AlignWorldCoordinates, config.AlignProjectCoordinates,
                    config.WorldPlacement, config.ProjectPlacements, config.LogDetail);
            }
        }
    }
}
