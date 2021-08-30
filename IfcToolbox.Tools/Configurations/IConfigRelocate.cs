using IfcToolbox.Core.Geo;
using System.Collections.Generic;

namespace IfcToolbox.Tools.Configurations
{
    public interface IConfigRelocate : IConfigBase
    {
        bool AlignProjectCoordinates { get; set; }
        bool AlignWorldCoordinates { get; set; }
        List<IGeoPlacement> ProjectPlacements { get; set; }
        IGeoPlacement WorldPlacement { get; set; }
    }
}
