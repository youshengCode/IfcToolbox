namespace IfcToolbox.Core.Editors
{
    public class PointProxy
    {
        public object ProxyDim { get; set; }
        public double ProxyX { get; set; }
        public double ProxyY { get; set; }
        public double ProxyZ { get; set; }
        public Xbim.Ifc2x3.Interfaces.IIfcCartesianPoint OriginalPoint { get; set; }

        public PointProxy(Xbim.Ifc2x3.Interfaces.IIfcCartesianPoint point)
        {
            OriginalPoint = point;
            ProxyDim = point.Dim.Value;
            ProxyX = point.Coordinates[0];
            ProxyY = point.Coordinates[1];
            if (point.Coordinates.Count > 2)
                ProxyZ = point.Coordinates[2];
        }
    }

}
