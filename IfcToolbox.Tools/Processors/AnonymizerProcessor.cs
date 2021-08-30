using IfcToolbox.Core.Editors;
using IfcToolbox.Core.Hierarchy;
using IfcToolbox.Core.Utilities;
using IfcToolbox.Tools.Configurations;
using Xbim.Common;
using Xbim.Common.Delta;
using Xbim.Ifc;

namespace IfcToolbox.Tools.Processors
{
    public class AnonymizerProcessor
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
            var result = TreesReader.GetOnlyTypedNodes(model, false);
            return result;
        }

        public static IProcessorResult Process(string filePath, IConfigAnonymize config, bool consoleMode = false)
        {
            if (consoleMode)
                Marslogger.Step($"{filePath} in processing");
            var processorResult = ProcessorResultFactory.CreateNew();
            var generatedFilePath = ConsoleFile.AddSuffixToName(filePath, "_" + config.Suffix);
            using var watch = new Superwatch();
            using var model = IfcStore.Open(filePath);
            using (var txn = model.BeginTransaction("Modification"))
            {
                if (consoleMode)
                    Marslogger.Step("Processing...");
                using var log = new TransactionLog(txn);

                Anonymize(model, config);

                txn.Commit();
                processorResult.Success = true;
                if (config.LogDetail && consoleMode)
                    Marslogger.PrintChanges(log, config.LogDetail);

                var logFilePath = ConsoleFile.CreateLogFile(generatedFilePath, Marslogger.CreateLog(log).ToString());
                processorResult.FilePaths.Add(logFilePath);
            }
            model.SaveAs(generatedFilePath);
            processorResult.FilePaths.Add(generatedFilePath);
            return processorResult;
        }

        public static void Anonymize(IModel model, IConfigAnonymize config)
        {
            if (config.AnonymeProductInfo)
                Anonymization.AnonymeProduct(model, config.Rules, config.ReplaceInName, config.ReplaceInObjectType, config.ReplaceInTypeProps, config.ReplaceInProductProps);
            if (config.AnonymeUserInfo)
            {
                Anonymization.AnonymeOwnerHistory(model);
                Anonymization.AnonymeAddressInfo(model, config.RemovePostalAddress, config.RemoveTelecomAddress);
                Anonymization.AnonymeAuthorInfo(model, config.RemoveActorRole, config.RemovePerson, config.RemoveOrganization, config.RemovePersonAndOrganization);
                Anonymization.AnonymeApplicationInfo(model, config.RemoveApplication);
                Anonymization.AnonymeFileName(model, config.ClearHeaderFileName);
            }
        }
    }
}
