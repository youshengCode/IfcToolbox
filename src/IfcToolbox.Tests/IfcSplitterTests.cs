using IfcToolbox.Core.Utilities;
using IfcToolbox.Tools.Configurations;
using IfcToolbox.Tools.Processors;
using System.Collections.Generic;
using Xbim.Ifc;
using Xunit;

namespace IfcToolbox.Tests
{
    public class IfcSplitterTests
    {
        [Fact]
        public static void SplitByObjectType()
        {
            var filePath = LocalFiles.Ifc4_SampleHouse;
            var outputFolder = LocalFiles.TestOutputFolder;
            string outputFileName = ConsoleFile.GetOutputFileName(filePath, outputFolder, "");
            ConsoleFile.CreateCopyIfcFile(filePath, outputFileName);
            IConfigSplit config = ConfigFactory.CreateConfigSplit();
            config.SplitStrategy = SplitStrategy.ByObjectType;
            config.SelectedItems = new List<string> { "Chair - Dining" };
            config.Suffix = "SplitByObjectType";
            using var model = IfcStore.Open(outputFileName);
            SplitterProcessor.Split(model, config, outputFileName);
        }

        [Fact]
        public static void SplitByProduct()
        {
            var filePath = LocalFiles.Ifc4_SampleHouse;
            var outputFolder = LocalFiles.TestOutputFolder;
            string outputFileName = ConsoleFile.GetOutputFileName(filePath, outputFolder, "");
            ConsoleFile.CreateCopyIfcFile(filePath, outputFileName);
            IConfigSplit config = ConfigFactory.CreateConfigSplit();
            config.SplitStrategy = SplitStrategy.ByProduct;
            config.SelectedItems = new List<string> { "137" }; // Roof - ifc4_SampleHouse
            config.Suffix = "SplitByProduct";
            using var model = IfcStore.Open(outputFileName);
            SplitterProcessor.Split(model, config, outputFileName);
        }

        [Fact]
        public static void SplitDataOnly()
        {
            var filePath = LocalFiles.Ifc4_SampleHouse;
            var outputFolder = LocalFiles.TestOutputFolder;
            string outputFileName = ConsoleFile.GetOutputFileName(filePath, outputFolder, "");
            ConsoleFile.CreateCopyIfcFile(filePath, outputFileName);
            IConfigSplit config = ConfigFactory.CreateConfigSplit();
            config.SplitStrategy = SplitStrategy.DataOnly;
            config.Suffix = "SplitDataOnly";
            using var model = IfcStore.Open(outputFileName);
            SplitterProcessor.Split(model, config, outputFileName);
        }

        [Fact]
        public static void SplitBySite()
        {
            var filePath = LocalFiles.Ifc4_SampleHouse;
            var outputFolder = LocalFiles.TestOutputFolder;
            string outputFileName = ConsoleFile.GetOutputFileName(filePath, outputFolder, "");
            ConsoleFile.CreateCopyIfcFile(filePath, outputFileName);
            IConfigSplit config = ConfigFactory.CreateConfigSplit();
            config.SplitStrategy = SplitStrategy.BySite;
            config.SelectedItems = new List<string> { "82887" };
            using var model = IfcStore.Open(outputFileName);
            SplitterProcessor.Split(model, config, outputFileName);
        }

        [Fact]
        public static void SplitByBuilding()
        {
            var filePath = LocalFiles.Ifc4_SampleHouse;
            var outputFolder = LocalFiles.TestOutputFolder;
            string outputFileName = ConsoleFile.GetOutputFileName(filePath, outputFolder, "");
            ConsoleFile.CreateCopyIfcFile(filePath, outputFileName);
            IConfigSplit config = ConfigFactory.CreateConfigSplit();
            config.SplitStrategy = SplitStrategy.ByBuilding;
            config.SelectedItems = new List<string> { "118" };
            using var model = IfcStore.Open(outputFileName);
            SplitterProcessor.Split(model, config, outputFileName);
        }

        [Fact]
        public static void SplitByBuildingStorey()
        {
            var filePath = LocalFiles.Ifc4_SampleHouse;
            var outputFolder = LocalFiles.TestOutputFolder;
            string outputFileName = ConsoleFile.GetOutputFileName(filePath, outputFolder, "");
            ConsoleFile.CreateCopyIfcFile(filePath, outputFileName);
            IConfigSplit config = ConfigFactory.CreateConfigSplit();
            config.SplitStrategy = SplitStrategy.ByBuildingStorey;
            config.SelectedItems = new List<string> { "137", "131" };
            using var model = IfcStore.Open(outputFileName);
            SplitterProcessor.Split(model, config, outputFileName);
        }
    }
}
