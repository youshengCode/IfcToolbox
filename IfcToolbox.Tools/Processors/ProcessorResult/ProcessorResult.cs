using System.Collections.Generic;
using System.Linq;

namespace IfcToolbox.Tools.Processors
{
    public class ProcessorResult : IProcessorResult
    {
        public bool Success { get; set; } = false;
        public IList<string> FilePaths { get; set; }
        public object Value { get; set; }

        public string GetFirstFilePath()
        {
            if (Success)
                if (FilePaths.Any())
                    return FilePaths.First();
            return null;
        }
    }
}
