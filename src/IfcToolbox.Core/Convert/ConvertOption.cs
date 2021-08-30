using System.Collections.Generic;

namespace IfcToolbox.Core.Convert
{
    public class ConvertOption : IConvertOption
    {
        public string Name { get; set; }
        public string CItext { get; set; }
        public bool HasArgs { get; set; }
        public bool IsFormatRelated { get; set; }
        public IEnumerable<ConvertTargetFormat> RelatedFormats { get; set; }
        public bool IsPostOption { get; set; }
    }

    public static class ConvertOptionExtension
    {
        public static IConvertOption RegistAsPostOption(this IConvertOption convertOption)
        {
            convertOption.IsPostOption = true;
            return convertOption;
        }
    }
}
