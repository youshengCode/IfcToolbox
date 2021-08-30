using System.Collections.Generic;

namespace IfcToolbox.Core.Geo
{
    public static class GeoFactory
    {
        public static IGeoPlacement CreateGeoPlacement(object plcm)
        {
            if (plcm is Xbim.Ifc4.Interfaces.IIfcAxis2Placement plcm_ifc4)
                return new GeoPlacement(plcm_ifc4);
            else if (plcm is Xbim.Ifc2x3.Interfaces.IIfcAxis2Placement plcm_ifc2x3)
                return new GeoPlacement(plcm_ifc2x3);
            else
                return null;
        }
        public static IGeoPlacement CreateGeoPlacement(List<double> locationXYZ, List<double> rotationX, List<double> rotationZ, int refEntityLable = 0)
        {
            return new GeoPlacement(locationXYZ, rotationX, rotationZ, refEntityLable);
        }

        public static IGeoReference CreateGeoReference() { return new GeoReference(); }
        public static IPostalAddress CreatePostalAddress() { return new PostalAddress(); }
        public static IGeodeticCoordinates CreateGeodeticCoordinates() { return new GeodeticCoordinates(); }
        public static IProjectCoordinates CreateProjectCoordinates() { return new ProjectCoordinates(); }
        public static IWorldCoordinates CreateWorldCoordinates() { return new WorldCoordinates(); }
        public static IMapConvensionCRS CreateMapConvensionCRS() { return new MapConvensionCRS(); }

    }
}
