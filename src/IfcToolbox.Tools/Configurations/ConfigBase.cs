namespace IfcToolbox.Tools.Configurations
{
    public class ConfigBase : IConfigBase
    {
        public bool KeepLabel { get; set; }
        public bool DeleteOld { get; set; } = true;
        public bool LogDetail { get; set; }
        public string Suffix { get; set; } = "Modified";
    }
}
