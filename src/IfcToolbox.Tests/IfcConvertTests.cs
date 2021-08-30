using IfcToolbox.Core.Convert;
using IfcToolbox.Core.Utilities;
using Xunit;

namespace IfcToolbox.Tests
{
    public class IfcConvertTests
    {
        [Fact]
        public static void ConvertToObjNoOption()
        {
            var filePath = LocalFiles.Ifc4_SampleHouse;
            var outputFolder = LocalFiles.TestOutputFolder;
            string outputFileName = ConsoleFile.GetOutputFileName(filePath, outputFolder, "_OBJ", ".obj");
            string logTextFileName = ConsoleFile.GetOutputFileName(outputFileName, outputFolder, "_Log", ".txt");
            var convertOptionWarp = new ConvertOptionsWrap();
            IfcConvert.Convert(filePath, outputFileName, convertOptionWarp, ConvertTargetFormat.OBJ, logTextFileName);
        }

        [Fact]
        public static void ConvertToObjWithOptions()
        {
            var filePath = LocalFiles.Ifc4_SampleHouse;
            var outputFolder = LocalFiles.TestOutputFolder;
            string outputFileName = ConsoleFile.GetOutputFileName(filePath, outputFolder, "_OBJwithOpt", ".obj");
            string logTextFileName = ConsoleFile.GetOutputFileName(outputFileName, outputFolder, "_Log", ".txt");
            var convertOptionWarp = new ConvertOptionsWrap();
            convertOptionWarp.YUp = true;
            convertOptionWarp.UseElementNames = true;
            IfcConvert.Convert(filePath, outputFileName, convertOptionWarp, ConvertTargetFormat.OBJ, logTextFileName);
        }

        [Fact]
        public static void ConvertToDae()
        {
            var filePath = LocalFiles.Ifc4_SampleHouse;
            var outputFolder = LocalFiles.TestOutputFolder;
            string outputFileName = ConsoleFile.GetOutputFileName(filePath, outputFolder, "_DAE", ".dae");
            string logTextFileName = ConsoleFile.GetOutputFileName(outputFileName, outputFolder, "_Log", ".txt");
            var convertOptionWarp = new ConvertOptionsWrap();
            convertOptionWarp.EnableLayersetSlicing = true;
            convertOptionWarp.UseElementTypes = true;
            IfcConvert.Convert(filePath, outputFileName, convertOptionWarp, ConvertTargetFormat.DAE, logTextFileName);
        }

        [Fact]
        public static void ConvertToStp()
        {
            var filePath = LocalFiles.Ifc4_SampleHouse;
            var outputFolder = LocalFiles.TestOutputFolder;
            string outputFileName = ConsoleFile.GetOutputFileName(filePath, outputFolder, "_STP", ".stp");
            string logTextFileName = ConsoleFile.GetOutputFileName(outputFileName, outputFolder, "_Log", ".txt");
            var convertOptionWarp = new ConvertOptionsWrap();
            convertOptionWarp.WeldVertices = true;
            IfcConvert.Convert(filePath, outputFileName, convertOptionWarp, ConvertTargetFormat.STP, logTextFileName);
        }

        [Fact]
        public static void ConvertToIgs()
        {
            var filePath = LocalFiles.Ifc4_SampleHouse;
            var outputFolder = LocalFiles.TestOutputFolder;
            string outputFileName = ConsoleFile.GetOutputFileName(filePath, outputFolder, "_IGS", ".igs");
            string logTextFileName = ConsoleFile.GetOutputFileName(outputFileName, outputFolder, "_Log", ".txt");
            var convertOptionWarp = new ConvertOptionsWrap();
            convertOptionWarp.UseWorldCoords = true;
            convertOptionWarp.ConvertBackUnits = true;
            IfcConvert.Convert(filePath, outputFileName, convertOptionWarp, ConvertTargetFormat.IGS, logTextFileName);
        }

        [Fact]
        public static void ConvertToXml()
        {
            var filePath = LocalFiles.Ifc4_SampleHouse;
            var outputFolder = LocalFiles.TestOutputFolder;
            string outputFileName = ConsoleFile.GetOutputFileName(filePath, outputFolder, "_XML", ".xml");
            string logTextFileName = ConsoleFile.GetOutputFileName(outputFileName, outputFolder, "_Log", ".txt");
            var convertOptionWarp = new ConvertOptionsWrap();
            convertOptionWarp.DisableBooleanResults = true;
            convertOptionWarp.LayersetFirst = true;
            IfcConvert.Convert(filePath, outputFileName, convertOptionWarp, ConvertTargetFormat.XML, logTextFileName);
        }

        [Fact]
        public static void ConvertToSvg()
        {
            var filePath = LocalFiles.Ifc4_SampleHouse;
            var outputFolder = LocalFiles.TestOutputFolder;
            string outputFileName = ConsoleFile.GetOutputFileName(filePath, outputFolder, "_SVG", ".svg");
            string logTextFileName = ConsoleFile.GetOutputFileName(outputFileName, outputFolder, "_Log", ".txt");
            var convertOptionWarp = new ConvertOptionsWrap();
            convertOptionWarp.AutoSection = true;
            convertOptionWarp.AutoElevation = true;
            IfcConvert.Convert(filePath, outputFileName, convertOptionWarp, ConvertTargetFormat.SVG, logTextFileName);
        }
    }
}
