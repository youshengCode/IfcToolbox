using System.Linq;
using Xbim.Common;
using Xbim.Ifc;

namespace IfcToolbox.Tools.Helper
{
    public class TimeEstimator
    {
        public static double ForOptimizerAsSeconds(string filePath)
        {
            var x = EntityCount(filePath);
            var a = 1.181489443796918e-16;
            var b = -2.1716498121791546e-10;
            var c = 0.00013858749214326269;
            var d = -9.74217071419708;
            return CubicCurveFitting(x, a, b, c, d);
        }

        public static double ForSplitterAsSeconds(string filePath)
        {
            var x = EntityCount(filePath);
            var a = 5.799865275762501e-17;
            var b = -1.0373008541396738e-10;
            var c = 0.00006884701268530628;
            var d = -3.183658176811491;
            return CubicCurveFitting(x, a, b, c, d);
        }

        public static double ForConverterAsSeconds(string filePath)
        {
            var x = EntityCount(filePath);
            var a = 1.181489443796918e-16;
            var b = -2.1716498121791546e-10;
            var c = 0.00013858749214326269;
            var d = -9.74217071419708;
            return CubicCurveFitting(x, a, b, c, d) * 2;
        }

        private static double CubicCurveFitting(int x, double a, double b, double c, double d)
        {
            // Curve Fitting result of test files
            // http://zizhujy.apphb.com/zh-CN/Plotter
            var result = a * x * x * x + b * x * x + c * x + d;
            if (result < 0)
                result = 0.1;
            return result;
        }

        public static int ProductCount(string filePath)
        {
            using (var model = IfcStore.Open(filePath))
            {
                int count = 0;
                if (model.SchemaVersion == Xbim.Common.Step21.XbimSchemaVersion.Ifc4 || model.SchemaVersion == Xbim.Common.Step21.XbimSchemaVersion.Ifc4x1)
                    count = model.Instances.OfType<Xbim.Ifc4.Interfaces.IIfcProduct>().ToList().Count();
                else if (model.SchemaVersion == Xbim.Common.Step21.XbimSchemaVersion.Ifc2X3)
                    count = model.Instances.OfType<Xbim.Ifc2x3.Interfaces.IIfcProduct>().ToList().Count();
                return count;
            }
        }
        public static int EntityCount(string filePath)
        {
            using (var model = IfcStore.Open(filePath))
            {
                return model.Instances.OfType<IPersistEntity>().Count();
            }
        }

        public static double LessThanTwoSeconds(string filePath)
        {
            return 2;
        }
    }
}
