namespace IfcToolbox.Core.Geo
{
    public class MapConversionParameters: IMapConversionParameters
    {
        public double? Eastings { get; set; }
        public double? Northings { get; set; }
        public double? OrthogonalHeight { get; set; }
        public double? Scale { get; set; }
        public double? XAxisAbscissa { get; set; }
        public double? XAxisOrdinate { get; set; }
    }
}
