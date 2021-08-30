using IfcToolbox.Core.Convert;

namespace IfcToolbox.Tools.Configurations
{
    public class ConfigConvert : IConfigConvert
    {
        public IConvertOptionsWrap ConvertOptions { get; set; }
        public ConvertTargetFormat TargetFormat { get; set; }

        public bool UseExternalResource { get; set; }
        public string ExternalWorkingDirectory { get; set; }
    }
}
