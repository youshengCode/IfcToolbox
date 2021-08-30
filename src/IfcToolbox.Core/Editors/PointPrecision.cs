using System;
using System.Collections.Generic;
using System.Linq;

namespace IfcToolbox.Core.Editors
{
    public static class PointPrecision
    {
        public static List<double> Optimize(int precision, List<double> coordinates)
        {
            List<double> newCoordiantes = new List<double>();
            foreach (var item in coordinates)
                newCoordiantes.Add(Math.Round(item, precision));
            return newCoordiantes;
        }

        public static bool NeedOptimize(Xbim.Ifc4.Interfaces.IIfcCartesianPoint point, int precision)
        {
            var values = point.Coordinates.Select(o => (double)o.Value).ToList();
            return NeedOptimize(values, precision);
        }
        public static bool NeedOptimize(Xbim.Ifc2x3.Interfaces.IIfcCartesianPoint point, int precision)
        {
            var values = point.Coordinates.Select(o => (double)o.Value).ToList();
            return NeedOptimize(values, precision);
        }

        private static bool NeedOptimize(List<double> coordinates, int precision)
        {
            if (!coordinates.Any()) return false;
            if (coordinates.Count() < 3)
            {
                if (GetDoublePlaces(coordinates[0]) > precision || GetDoublePlaces(coordinates[1]) > precision)
                    return true;
            }
            else
            {
                if (GetDoublePlaces(coordinates[0]) > precision || GetDoublePlaces(coordinates[1]) > precision || GetDoublePlaces(coordinates[2]) > precision)
                    return true;
            }
            return false;
        }
        private static int GetDoublePlaces(double value)
        {
            bool start = false;
            int count = 0;
            foreach (var s in value.ToString())
            {
                if (s == '.')
                    start = true;
                else if (start)
                    count++;
            }
            return count;
        }
    }
}
