using System.Collections.Generic;

namespace IfcToolbox.Tools.Configurations
{
    public class ConfigSplit : IConfigSplit
    {
        public bool KeepLabel { get; set; } = true;
        public bool DeleteOld { get; set; } = true;
        public bool LogDetail { get; set; }

        public SplitStrategy SplitStrategy { get; set; }

        public IEnumerable<string> SelectedItems { get; set; }
        public string Suffix { get; set; } = "Splitted";

        public string BuildingStoreyPlaceholder { get; set; } = "Level";
        public string BuildingPlaceholder { get; set; } = "Building";
        public string SitePlaceholder { get; set; } = "Site";
    }
}
