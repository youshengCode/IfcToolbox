namespace IfcToolbox.Core.Geo
{
    public interface IMapConversionParameters
    {
        double? Eastings { get; set; }
        double? Northings { get; set; }
        double? OrthogonalHeight { get; set; }
        double? Scale { get; set; }
        double? XAxisAbscissa { get; set; }
        double? XAxisOrdinate { get; set; }
    }
}
