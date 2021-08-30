using IfcToolbox.Core.Convert;

namespace IfcToolbox.Tools.Configurations
{
    public interface IConfigConvert
    {
        IConvertOptionsWrap ConvertOptions { get; set; }
        ConvertTargetFormat TargetFormat { get; set; }
        bool UseExternalResource { get; set; }
        string ExternalWorkingDirectory { get; set; }
    }
}
