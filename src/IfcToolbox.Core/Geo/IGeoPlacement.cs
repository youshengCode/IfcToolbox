using System.Collections.Generic;

namespace IfcToolbox.Core.Geo
{
    public interface IGeoPlacement
    {
        IList<double> LocationXYZ { get; set; }
        IList<double> RotationX { get; set; }
        IList<double> RotationZ { get; set; }
        bool GeoReferencing { get; set; }
        int RefEntityLable { get; set; }

        bool Equals(IGeoPlacement other);
    }

}
