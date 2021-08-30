using System.Collections.Generic;

namespace IfcToolbox.Core.Geo
{
    public class MapConversionData: IMapConversionData
    {
        public List<IReferencePoint> LocalPoints { get; set; }
        public List<IReferencePoint> MapPoints { get; set; }
        public double LocalToMapUnitScale { get; set; }
    }
}
