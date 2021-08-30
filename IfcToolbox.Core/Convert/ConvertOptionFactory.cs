using System.Collections.Generic;

namespace IfcToolbox.Core.Convert
{
    public class ConvertOptionFactory
    {
        public static IConvertOption CreateConvertOption(string name, string cItext, ConvertTargetFormat format1, ConvertTargetFormat format2, ConvertTargetFormat format3, bool hasArgs = false)
        {
            return CreateConvertOption(name, cItext, new List<ConvertTargetFormat> { format1, format2, format3 }, hasArgs);
        }

        public static IConvertOption CreateConvertOption(string name, string cItext, ConvertTargetFormat format1, ConvertTargetFormat format2, bool hasArgs = false)
        {
            return CreateConvertOption(name, cItext, new List<ConvertTargetFormat> { format1, format2 }, hasArgs);
        }

        public static IConvertOption CreateConvertOption(string name, string cItext, ConvertTargetFormat format1, bool hasArgs = false)
        {
            return CreateConvertOption(name, cItext, new List<ConvertTargetFormat> { format1 }, hasArgs);
        }

        public static IConvertOption CreateConvertOption(string name, string cItext, IEnumerable<ConvertTargetFormat> relatedFormats, bool hasArgs = false)
        {
            return CreateConvertOptionBasic(name, cItext, true, relatedFormats, hasArgs);
        }

        public static IConvertOption CreateGeneralConvertOption(string name, string cItext, bool hasArgs = false)
        {
            return CreateConvertOptionBasic(name, cItext, false, null, hasArgs);
        }

        public static IConvertOption CreateConvertOptionBasic(string name, string cItext, bool isFormatRelated = false, IEnumerable<ConvertTargetFormat> relatedFormats = null, bool hasArgs = false)
        {
            var option = new ConvertOption();
            option.Name = name;
            option.CItext = cItext;
            option.IsFormatRelated = isFormatRelated;
            option.RelatedFormats = relatedFormats;
            option.HasArgs = hasArgs;
            return option;
        }
    }
}
