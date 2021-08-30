namespace IfcToolbox.Tools.Configurations
{
    public interface IConfigOptimize : IConfigBase
    {
        bool MergeOpen { get; set; }
        bool MergeOnlyResources { get; set; }
        bool MergeReversedEntities { get; set; }

        bool PrecisionOpen { get; set; }
        int Precision { get; set; }

        bool OptimizePoint { get; set; }
        bool OptimizePointList { get; set; }
    }
}
