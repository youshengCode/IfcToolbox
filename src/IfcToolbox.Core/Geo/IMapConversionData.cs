using System.Collections.Generic;

namespace IfcToolbox.Core.Geo
{
    public interface IMapConversionData
    {
        // Points in LCS (Local Coordinate System)
        List<IReferencePoint> LocalPoints { get; set; }
        // Points in MCS (Map Coordinate System)
        List<IReferencePoint> MapPoints { get; set; }
        // Ex: if local is in mm, and the map is in m, the UnitScale will be 0.001.
        double LocalToMapUnitScale { get; set; }
    }
}
