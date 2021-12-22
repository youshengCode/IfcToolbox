using IfcToolbox.Core.Hierarchy;
using IfcToolbox.Tools.Processors;
using IfcToolbox.Tools.Helper;
using Serilog;
using System.Collections.Generic;
using System.Data;
using System.IO;
using IfcToolbox.Core.Validate;
using IfcToolbox.Core.Utilities;

namespace IfcToolbox.Examples.Samples
{
    public class IfcValidatorSample
    {
        public static void ValidatePropertyExistence(string filePath)
        {
            Log.Information($"IfcValidator - Start");
            var nodes = SamplePropertyHierarchyNodes();
            var result = ValidatorProcessor.Process(filePath, nodes, true);
            var tables = result.Value as IList<DataTable>;
            foreach (var table in tables)
            {
                string tableCsvPath = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + "_" + table.TableName) + ".csv";
                table.SaveAsCsv(tableCsvPath);

                Marslogger.Mark($"Total entity found : {PropertyExistenceCount.GetEntitiesCount(table)}");
                Marslogger.Mark($"Property existence checked : {PropertyExistenceCount.GetPropertiesCount(table)}");
                Marslogger.Mark($"Existence percentage : {PropertyExistenceCount.GetExistencePercentage(table)}%");
            }
        }

        private static IList<HierarchyNode> SamplePropertyHierarchyNodes()
        {
            IList<HierarchyNode> nodes = new List<HierarchyNode>();

            var ifcDoor = new HierarchyNode("IfcDoor", true);
            var ifcDoorPset = new HierarchyNode("Pset_DoorCommon", true);
            ifcDoorPset.Children.Add(new HierarchyNode("FireExit"));
            ifcDoorPset.Children.Add(new HierarchyNode("SmokeStop"));
            ifcDoorPset.Children.Add(new HierarchyNode("IsExternal"));
            ifcDoorPset.Children.Add(new HierarchyNode("SecurityRating"));
            ifcDoor.Children.Add(ifcDoorPset);

            var ifcWall = new HierarchyNode("IfcWall", true);
            var ifcWallPset = new HierarchyNode("Pset_WallCommon", true);
            ifcWallPset.Children.Add(new HierarchyNode("FireRating"));
            ifcWallPset.Children.Add(new HierarchyNode("AcousticRating"));
            ifcWallPset.Children.Add(new HierarchyNode("IsExternal"));
            ifcWallPset.Children.Add(new HierarchyNode("Reference"));
            ifcWall.Children.Add(ifcWallPset);
            var ifcWallQto = new HierarchyNode("Qto_WallBaseQuantities", true);
            ifcWallQto.Children.Add(new HierarchyNode("Height"));
            ifcWallQto.Children.Add(new HierarchyNode("Length"));
            ifcWallQto.Children.Add(new HierarchyNode("Width"));
            ifcWall.Children.Add(ifcWallQto);

            nodes.Add(ifcDoor);
            nodes.Add(ifcWall);
            return nodes;
        }
    }
}
