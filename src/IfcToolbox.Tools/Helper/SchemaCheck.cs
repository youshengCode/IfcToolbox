using System;
using System.Collections.Generic;
using System.IO;
using Xbim.Ifc;

namespace IfcToolbox.Tools.Helper
{
    public class SchemaCheck
    {
        public static SchemaCheckResult GetResult(List<string> files)
        {
            var result = new SchemaCheckResult();
            foreach (var file in files)
            {
                if (!Supported(file))
                {
                    result.SchemaPass = false;
                    result.UnsupportedFileNames.Add(Path.GetFileName(file));
                }
            }
            return result;
        }

        private static bool Supported(string filePath)
        {
            bool supported = false;
            try
            {
                using (var model = IfcStore.Open(filePath))
                {
                    switch (model.SchemaVersion)
                    {
                        case Xbim.Common.Step21.XbimSchemaVersion.Unsupported:
                            break;
                        case Xbim.Common.Step21.XbimSchemaVersion.Ifc4:
                            supported = true;
                            break;
                        case Xbim.Common.Step21.XbimSchemaVersion.Ifc4x1:
                            supported = true;
                            break;
                        case Xbim.Common.Step21.XbimSchemaVersion.Ifc2X3:
                            supported = true;
                            break;
                        case Xbim.Common.Step21.XbimSchemaVersion.Cobie2X4:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
                supported = false;
            }
            return supported;
        }
    }

    public class SchemaCheckResult
    {
        public bool SchemaPass { get; set; } = true;
        public List<string> UnsupportedFileNames { get; set; } = new List<string>();
    }
}
