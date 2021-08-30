using IfcToolbox.Core.Geo;
using System.Collections.Generic;

namespace IfcToolbox.Tools.Configurations
{
    public class ConfigRelocate : IConfigRelocate
    {
        public bool KeepLabel { get; set; }
        public bool DeleteOld { get; set; } = true;
        public bool LogDetail { get; set; }

        public bool AlignWorldCoordinates { get; set; }
        public bool AlignProjectCoordinates { get; set; }
        public IGeoPlacement WorldPlacement { get; set; }
        public List<IGeoPlacement> ProjectPlacements { get; set; } = new List<IGeoPlacement>();

        public string Suffix { get; set; } = "Moved";
    }
}
