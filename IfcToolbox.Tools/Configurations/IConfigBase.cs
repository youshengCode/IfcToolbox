namespace IfcToolbox.Tools.Configurations
{
    public interface IConfigBase
    {
        bool KeepLabel { get; set; }
        bool DeleteOld { get; set; }
        bool LogDetail { get; set; }
        string Suffix { get; set; }
    }
}
