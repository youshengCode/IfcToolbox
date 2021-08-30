using System.Collections.Generic;
using System.Linq;
using Xbim.Common;

namespace IfcToolbox.Core.Editors
{
    public class PointFactory
    {
        public static Xbim.Ifc4.GeometryResource.IfcCartesianPoint CreatePoint(IModel model, Xbim.Ifc4.Interfaces.IIfcCartesianPoint point, bool withPrecision, int precision)
        {
            var values = point.Coordinates.Select(o => (double)o.Value).ToList();
            if (withPrecision)
                return CreatePoint_Ifc4(model, PointPrecision.Optimize(precision, values));
            else
                return CreatePoint_Ifc4(model, values);
        }
        public static Xbim.Ifc2x3.GeometryResource.IfcCartesianPoint CreatePoint(IModel model, Xbim.Ifc2x3.Interfaces.IIfcCartesianPoint point, bool withPrecision, int precision)
        {
            var values = point.Coordinates.Select(o => (double)o.Value).ToList();
            if (withPrecision)
                return CreatePoint_Ifc2x3(model, PointPrecision.Optimize(precision, values));
            else
                return CreatePoint_Ifc2x3(model, values);
        }

        public static Xbim.Ifc4.GeometryResource.IfcCartesianPoint CreatePoint_Ifc4(IModel model, IList<double> locationXYZ)
        {
            if (locationXYZ == null)
                return null;
            Xbim.Ifc4.GeometryResource.IfcCartesianPoint newPoint = model.Instances.New<Xbim.Ifc4.GeometryResource.IfcCartesianPoint>();
            if (locationXYZ.Count < 3)
                newPoint.SetXY(locationXYZ[0], locationXYZ[1]);
            else
                newPoint.SetXYZ(locationXYZ[0], locationXYZ[1], locationXYZ[2]);
            return newPoint;
        }
        public static Xbim.Ifc2x3.GeometryResource.IfcCartesianPoint CreatePoint_Ifc2x3(IModel model, IList<double> locationXYZ)
        {
            if (locationXYZ == null)
                return null;
            Xbim.Ifc2x3.GeometryResource.IfcCartesianPoint newPoint = model.Instances.New<Xbim.Ifc2x3.GeometryResource.IfcCartesianPoint>();
            if (locationXYZ.Count < 3)
                newPoint.SetXY(locationXYZ[0], locationXYZ[1]);
            else
                newPoint.SetXYZ(locationXYZ[0], locationXYZ[1], locationXYZ[2]);
            return newPoint;
        }

        public static Xbim.Ifc4.GeometryResource.IfcDirection CreateDirection(IModel model, Xbim.Ifc4.Interfaces.IIfcDirection point, bool withPrecision, int precision)
        {
            var values = point.DirectionRatios.Select(o => (double)o.Value).ToList();
            if (withPrecision)
                return CreateDirection_Ifc4(model, PointPrecision.Optimize(precision, values));
            else
                return CreateDirection_Ifc4(model, values);
        }
        public static Xbim.Ifc2x3.GeometryResource.IfcDirection CreateDirection(IModel model, Xbim.Ifc2x3.Interfaces.IIfcDirection point, bool withPrecision, int precision)
        {
            var values = point.DirectionRatios.ToList();
            if (withPrecision)
                return CreateDirection_Ifc2x3(model, PointPrecision.Optimize(precision, values));
            else
                return CreateDirection_Ifc2x3(model, values);
        }

        public static Xbim.Ifc4.GeometryResource.IfcDirection CreateDirection_Ifc4(IModel model, IList<double> rotations)
        {
            if (rotations == null)
                return null;
            Xbim.Ifc4.GeometryResource.IfcDirection direction = model.Instances.New<Xbim.Ifc4.GeometryResource.IfcDirection>();
            if (rotations.Count < 3)
                direction.SetXY(rotations[0], rotations[1]);
            else
                direction.SetXYZ(rotations[0], rotations[1], rotations[2]);
            return direction;
        }
        public static Xbim.Ifc2x3.GeometryResource.IfcDirection CreateDirection_Ifc2x3(IModel model, IList<double> rotations)
        {
            if (rotations == null)
                return null;
            Xbim.Ifc2x3.GeometryResource.IfcDirection direction = model.Instances.New<Xbim.Ifc2x3.GeometryResource.IfcDirection>();
            if (rotations.Count < 3)
                direction.SetXY(rotations[0], rotations[1]);
            else
                direction.SetXYZ(rotations[0], rotations[1], rotations[2]);
            return direction;
        }
    }
}
