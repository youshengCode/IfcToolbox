using IfcToolbox.Core.Hierarchy;
using IfcToolbox.Core.Utilities;
using IfcToolbox.Core.Validate;
using Serilog;
using System.Collections.Generic;
using Xbim.Ifc;

namespace IfcToolbox.Tools.Processors
{
    public class ValidatorProcessor
    {
        public static IProcessorResult Process(string filePath, IList<HierarchyNode> nodes, bool consoleMode = false)
        {
            if (consoleMode)
                Marslogger.Step($"{filePath} in processing");
            using (var watch = new Superwatch())
            using (var model = IfcStore.Open(filePath))
            {
                if (consoleMode)
                {
                    Log.Information($"IFC Schema - {model.SchemaVersion}");
                    Marslogger.Step("Processing...");
                }
                var result = ProcessorResultFactory.CreateNew();
                try
                {
                    var dataTables = PropertyExistence.AnalyseProperties(model, nodes);
                    result.Value = dataTables;
                    result.Success = true;
                }
                catch (System.Exception)
                {
                    result.Success = false;
                }
                return result;
            }
        }
    }
}
