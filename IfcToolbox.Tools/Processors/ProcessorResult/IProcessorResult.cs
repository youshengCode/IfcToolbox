using System.Collections.Generic;

namespace IfcToolbox.Tools.Processors
{
    public interface IProcessorResult
    {
        bool Success { get; set; }
        IList<string> FilePaths { get; set; }
        object Value { get; set; }
        string GetFirstFilePath();
    }
}
