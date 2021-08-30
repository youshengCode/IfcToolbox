namespace IfcToolbox.Tools.Configurations
{
    public class ConfigOptimize : IConfigOptimize
    {
        public bool KeepLabel { get; set; }
        public bool DeleteOld { get; set; } = true;
        public bool LogDetail { get; set; }

        public bool PrecisionOpen { get; set; } = true;
        public int Precision { get; set; } = 15;
        public bool OptimizePoint { get; set; }
        public bool OptimizePointList { get; set; }

        public bool MergeOpen { get; set; } = true;
        public bool MergeOnlyResources { get; set; }
        public bool MergeReversedEntities { get; set; }

        public string Suffix { get; set; } = "Optimized";
    }
}
