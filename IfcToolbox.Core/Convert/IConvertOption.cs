using System.Collections.Generic;

namespace IfcToolbox.Core.Convert
{
    public interface IConvertOption
    {
        string CItext { get; set; }
        bool IsFormatRelated { get; set; }
        bool HasArgs { get; set; }
        string Name { get; set; }
        IEnumerable<ConvertTargetFormat> RelatedFormats { get; set; }
        bool IsPostOption { get; set; }
    }
}