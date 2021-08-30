using System.Collections.Generic;
using System.Linq;

namespace IfcToolbox.Core.Geo
{
    public class GeoReference : IGeoReference
    {
        public List<IPostalAddress> PostalAddress { get; set; } = new List<IPostalAddress>();
        public List<IGeodeticCoordinates> GeodeticCoordinates { get; set; } = new List<IGeodeticCoordinates>();
        public List<IProjectCoordinates> ProjectCoordinates { get; set; } = new List<IProjectCoordinates>();
        public IWorldCoordinates WorldCoordinates { get; set; }
        public IMapConvensionCRS MapConvensionCRS { get; set; }

        public void RemoveUncompleted()
        {
            var emptyAddress = PostalAddress.Where(x => x.IsComplet == false).ToList();
            foreach (var item in emptyAddress)
                PostalAddress.Remove(item);
            if (PostalAddress.Count == 0)
                PostalAddress = null;

            var emptyGCS = GeodeticCoordinates.Where(x => x.IsComplet == false).ToList();
            foreach (var item in emptyGCS)
                GeodeticCoordinates.Remove(item);
            if (GeodeticCoordinates.Count == 0)
                GeodeticCoordinates = null;

            var emptyPCS = ProjectCoordinates.Where(x => x.IsComplet == false).ToList();
            foreach (var item in emptyPCS)
                ProjectCoordinates.Remove(item);
            if (ProjectCoordinates.Count == 0)
                ProjectCoordinates = null;

            if (!WorldCoordinates.IsComplet)
                WorldCoordinates = null;
            if (!MapConvensionCRS.IsComplet)
                MapConvensionCRS = null;
        }
    }

    #region GeoInfo Classes
    public class GeoInfoBase: IGeoInfoBase
    {
        public bool IsComplet { get; set; } = false;
        public IList<string> Reference_Object { get; set; } = new List<string>();
        public IList<string> Instance_Object { get; set; } = new List<string>();
    }
    public class PostalAddress : GeoInfoBase, IPostalAddress
    {
        public IList<string> AddressLines { get; set; }
        public string Postalcode { get; set; }
        public string Town { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }
    public class GeodeticCoordinates : GeoInfoBase, IGeodeticCoordinates
    {
        public double? Latitude { get; set; } = null;
        public double? Longitude { get; set; } = null;
        public double? Elevation { get; set; } = null; 
    }
    public class ProjectCoordinates : GeoInfoBase, IProjectCoordinates
    {
        public IGeoPlacement Placement { get; set; }
    }
    public class WorldCoordinates : GeoInfoBase, IWorldCoordinates
    {
        public IGeoPlacement Placement { get; set; }
        public IList<double> TrueNorthXY { get; set; } = new List<double>();
    }
    public class MapConvensionCRS : GeoInfoBase, IMapConvensionCRS
    {
        public double? Eastings { get; set; } = null;
        public double? Northings { get; set; } = null;
        public double? OrthogonalHeight { get; set; } = null;
        public double? Scale { get; set; } = null;
        public double? XAxisAbscissa { get; set; } = null;
        public double? XAxisOrdinate { get; set; } = null;

        public string CRS_Name { get; set; }
        public string CRS_Description { get; set; }
        public string CRS_GeodeticDatum { get; set; }
        public string CRS_VerticalDatum { get; set; }
        public string CRS_ProjectionName { get; set; }
        public string CRS_ProjectionZone { get; set; }
    }
    #endregion
}
