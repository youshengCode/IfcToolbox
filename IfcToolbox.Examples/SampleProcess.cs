using IfcToolbox.Core.Analyse;
using IfcToolbox.Core.Utilities;
using IfcToolbox.Examples.Batch;
using IfcToolbox.Examples.Samples;
using IfcToolbox.Tests;
using IfcToolbox.Tools.Processors;

namespace IfcToolbox.Examples
{
    public static class SampleProcess
    {
        // ATTENTION: Do not forget to replace your own local Output Folder
        private static string OutputFolder = LocalFiles.TestOutputFolder;

        public static void Start()
        {
            //EntityAnalyse.AnalyseEntityFrequency(LocalFiles.Ifc4_Revit_ARC, true);
            //IfcOptimizerSample.Optimize(LocalFiles.Ifc4_Revit_ARC.CopyToOutputFolder());

            //AnalyseProcessor.GetGeoReference(LocalFiles.Ifc4_Revit_ARC, null, true);
            //IfcRelocatorSample.RelocateToOrigin(LocalFiles.Ifc4_Revit_ARC.CopyToOutputFolder(), 3371);

            //EntityAnalyse.AnalyseHierarchy(LocalFiles.Ifc4_SampleHouse, true);
            //IfcSplitterSample.SplitByBuildingStorey(LocalFiles.Ifc4_SampleHouse.CopyToOutputFolder());

            //IfcConverterSample.ConvertToSvg(LocalFiles.Ifc4_SampleHouse.CopyToOutputFolder());
            //IfcConverterSample.ConvertToObj(LocalFiles.Ifc4_SampleHouse.CopyToOutputFolder());

            IfcAnonymizerSample.AnonymizeUserInfo(LocalFiles.Ifc4_SampleHouse.CopyToOutputFolder());
            //IfcAnonymizerSample.AnonymizeProductInfoWithRules(LocalFiles.Ifc4_SampleHouse.CopyToOutputFolder());

            //SimulationProcessingTime();
        }

        private static void SimulationProcessingTime()
        {
            //ProcessTimeEstimation.IfcOptimizer_TimeEstimate(OutputFolder);
            //ProcessTimeEstimation.IfcRelocator_TimeEstimate(OutputFolder);
            //ProcessTimeEstimation.IfcSplitter_TimeEstimate(OutputFolder);
            //ProcessTimeEstimation.IfcConverter_TimeEstimate(OutputFolder);
        }

        private static string CopyToOutputFolder(this string filePath)
        {
            string copiedIfc = ConsoleFile.GetOutputFileName(filePath, OutputFolder, "");
            ConsoleFile.CreateCopyIfcFile(filePath, copiedIfc);
            return copiedIfc;
        }
    }
}
