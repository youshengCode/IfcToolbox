using System.Collections.Generic;

namespace IfcToolbox.Core.Geo
{
    public class GeoPlacementWrap : IGeoPlacementWrap
    {
        public string PlacementX { get; set; }
        public string PlacementY { get; set; }
        public string PlacementZ { get; set; }
        public string RefDirection1 { get; set; }
        public string RefDirection2 { get; set; }
        public string RefDirection3 { get; set; }
        public string Axis1 { get; set; }
        public string Axis2 { get; set; }
        public string Axis3 { get; set; }

        public IGeoPlacement ToGeoPlacement(int refEntityLable = 0)
        {
            List<double> location = null;
            if (!string.IsNullOrEmpty(PlacementX) && !string.IsNullOrEmpty(PlacementY) && !string.IsNullOrEmpty(PlacementZ))
            {
                location = new List<double>();
                location.Add(double.Parse(PlacementX));
                location.Add(double.Parse(PlacementY));
                location.Add(double.Parse(PlacementZ));
            }
            List<double> refDirection = null;
            if (!string.IsNullOrEmpty(RefDirection1) && !string.IsNullOrEmpty(RefDirection2) && !string.IsNullOrEmpty(RefDirection3))
            {
                refDirection = new List<double>();
                refDirection.Add(double.Parse(RefDirection1));
                refDirection.Add(double.Parse(RefDirection2));
                refDirection.Add(double.Parse(RefDirection3));
            }
            List<double> axis = null;
            if (!string.IsNullOrEmpty(Axis1) && !string.IsNullOrEmpty(Axis2) && !string.IsNullOrEmpty(Axis3))
            {
                axis = new List<double>();
                axis.Add(double.Parse(Axis1));
                axis.Add(double.Parse(Axis2));
                axis.Add(double.Parse(Axis3));
            }
            return GeoFactory.CreateGeoPlacement(location, refDirection, axis, refEntityLable);
        }
    }
}
