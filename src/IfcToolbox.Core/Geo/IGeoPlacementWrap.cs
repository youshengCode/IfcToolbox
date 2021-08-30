namespace IfcToolbox.Core.Geo
{
    public interface IGeoPlacementWrap
    {
        string PlacementX { get; set; }
        string PlacementY { get; set; }
        string PlacementZ { get; set; }
        string RefDirection1 { get; set; }
        string RefDirection2 { get; set; }
        string RefDirection3 { get; set; }
        string Axis1 { get; set; }
        string Axis2 { get; set; }
        string Axis3 { get; set; }

        IGeoPlacement ToGeoPlacement(int refEntityLable = 0);
    }
}
