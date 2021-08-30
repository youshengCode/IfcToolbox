namespace IfcToolbox.Core.Convert
{
    public interface IConvertOptionsWrap
    {
        bool AutoElevation { get; set; }
        bool AutoSection { get; set; }
        bool BuildingLocalPlacement { get; set; }
        bool CenterModel { get; set; }
        bool CenterModelGeometry { get; set; }
        bool ConvertBackUnits { get; set; }
        bool OrientShells { get; set; }
        bool DisableBooleanResults { get; set; }
        bool DisableOpeningSubtractions { get; set; }
        bool DoorArcs { get; set; }
        bool EnableLayersetSlicing { get; set; }
        bool LayersetFirst { get; set; }
        bool Model { get; set; }
        bool Plan { get; set; }
        bool PrintSpaceAreas { get; set; }
        bool PrintSpaceNames { get; set; }
        bool SiteLocalPlacement { get; set; }
        bool SvgPoly { get; set; }
        bool SvgProject { get; set; }
        bool SvgXmlns { get; set; }
        bool UseElementGuids { get; set; }
        bool UseElementHierarchy { get; set; }
        bool UseElementNames { get; set; }
        bool UseElementNumericIds { get; set; }
        bool UseElementTypes { get; set; }
        bool UseMaterialNames { get; set; }
        bool UseWorldCoords { get; set; }
        bool WeldVertices { get; set; }
        bool YUp { get; set; }
        bool SectionHeightFromStorey { get; set; }

        string Bounds { get; set; }
        string IncludeEntities { get; set; }
        string ExcludeEntities { get; set; }
    }
}