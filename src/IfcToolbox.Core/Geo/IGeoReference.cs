using System.Collections.Generic;

namespace IfcToolbox.Core.Geo
{
    public interface IGeoReference
    {
        List<IGeodeticCoordinates> GeodeticCoordinates { get; set; }
        IMapConvensionCRS MapConvensionCRS { get; set; }
        List<IPostalAddress> PostalAddress { get; set; }
        List<IProjectCoordinates> ProjectCoordinates { get; set; }
        IWorldCoordinates WorldCoordinates { get; set; }

        void RemoveUncompleted();
    }

    public interface IGeoInfoBase
    {
        bool IsComplet { get; set; } 
        IList<string> Reference_Object { get; set; } 
        IList<string> Instance_Object { get; set; }
    }

    // Human readable PostalAddress - IfcSite / IfcBuilding
    public interface IPostalAddress: IGeoInfoBase
    {
        IList<string> AddressLines { get; set; }
        string Postalcode { get; set; }
        string Town { get; set; }
        string Region { get; set; }
        string Country { get; set; }
    }

    // GCS (Geographic Coordinate System) in Geodesy - IfcSite
    public interface IGeodeticCoordinates : IGeoInfoBase
    {
        double? Latitude { get; set; }
        double? Longitude { get; set; }
        double? Elevation { get; set; } // orthometric heights
    }

    // PCS (Project Coordinate System) in a 3D cartesain coordinate system - IfcSite 
    public interface IProjectCoordinates : IGeoInfoBase
    {
        IGeoPlacement Placement { get; set; }
    }

    // WCS (World Coordinate System) in Computer Virual Space - IfcProject 
    public interface IWorldCoordinates : IGeoInfoBase
    {
        IGeoPlacement Placement { get; set; }
        IList<double> TrueNorthXY { get; set; }
    }

    // CRS (Coordinate Reference System) with MapConvension in Real World - IfcProject 
    public interface IMapConvensionCRS : IMapConversionParameters, IGeoInfoBase
    {
        string CRS_Description { get; set; }
        string CRS_GeodeticDatum { get; set; }
        string CRS_Name { get; set; }
        string CRS_ProjectionName { get; set; }
        string CRS_ProjectionZone { get; set; }
        string CRS_VerticalDatum { get; set; }
    }
}
