using System.Collections.Generic;

namespace IfcToolbox.Tools.Processors
{
    public class ProcessorResultFactory
    {
        public static IProcessorResult CreateNew()
        {
            var processorResult = new ProcessorResult();
            processorResult.FilePaths = new List<string>();
            return processorResult;
        }
    }
}
