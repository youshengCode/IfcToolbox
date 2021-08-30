namespace IfcToolbox.Core.Convert
{
    public class ConvertOptionsWrap : IConvertOptionsWrap
    {
        // General 
        public bool Plan { get; set; }
        public bool Model { get; set; }
        public bool WeldVertices { get; set; }
        public bool UseWorldCoords { get; set; }
        public bool ConvertBackUnits { get; set; }
        public bool OrientShells { get; set; }
        public bool CenterModel { get; set; }
        public bool CenterModelGeometry { get; set; }

        public bool DisableOpeningSubtractions { get; set; }
        public bool DisableBooleanResults { get; set; }
        public bool EnableLayersetSlicing { get; set; }
        public bool LayersetFirst { get; set; }

        // Format specific
        public bool AutoSection { get; set; }
        public bool AutoElevation { get; set; }
        public bool SectionHeightFromStorey { get; set; }
        public bool SvgXmlns { get; set; }
        public bool SvgPoly { get; set; }
        public bool SvgProject { get; set; }
        public bool DoorArcs { get; set; }

        public bool UseElementNames { get; set; }
        public bool UseElementGuids { get; set; }
        public bool UseElementNumericIds { get; set; }
        public bool UseMaterialNames { get; set; }
        public bool UseElementTypes { get; set; }
        public bool UseElementHierarchy { get; set; }
        public bool SiteLocalPlacement { get; set; }
        public bool BuildingLocalPlacement { get; set; }
        public bool YUp { get; set; }

        public bool PrintSpaceNames { get; set; }
        public bool PrintSpaceAreas { get; set; }
        public string Bounds { get; set; }
        public string IncludeEntities { get; set; }
        public string ExcludeEntities { get; set; }

    }
}
