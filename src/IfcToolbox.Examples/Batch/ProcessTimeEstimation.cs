using IfcToolbox.Core.Convert;
using IfcToolbox.Core.Utilities;
using IfcToolbox.Examples.Samples;
using IfcToolbox.Tests;
using IfcToolbox.Tools.Configurations;
using IfcToolbox.Tools.Helper;
using IfcToolbox.Tools.Processors;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xbim.Ifc;

namespace IfcToolbox.Examples.Batch
{
    public class ProcessTimeEstimation
    {
        public static List<string> GetAllTestFiles()
        {
            List<string> files = new List<string>();
            files.Add(LocalFiles.Ifc4_CubeAdvancedBrep); // NO site NO level
            files.Add(LocalFiles.Ifc4_WallElementedCase); // NO building
            files.Add(LocalFiles.Ifc4_Revit_ARC);
            files.Add(LocalFiles.Ifc4_Revit_STR); // NO building NO level
            files.Add(LocalFiles.Ifc4_Revit_MEP);
            files.Add(LocalFiles.Ifc2x3_Duplex_Architecture);
            files.Add(LocalFiles.Ifc2s3_Duplex_Electrical);
            files.Add(LocalFiles.Ifc2x3_Duplex_Mechanical);
            files.Add(LocalFiles.Ifc2x3_Duplex_Plumbing);
            files.Add(LocalFiles.Ifc2x3_Duplex_MEP);
            files.Add(LocalFiles.Ifc2x3_SampleCastle);
            files.Add(LocalFiles.Ifc4_SampleHouse);
            return files;
        }

        public static List<TimeReport> IfcOptimizer_TimeEstimate(string outputFolder)
        {
            List<string> files = GetAllTestFiles();
            List<TimeReport> reports = new List<TimeReport>();
            foreach (var file in files)
            {
                var report = new TimeReport(file);
                var estimateTime = TimeEstimator.ForOptimizerAsSeconds(file);
                var realTime = GetRealTime(file, outputFolder);
                report.AddProcessingTime(realTime, estimateTime);
                report.LogDetail();
                reports.Add(report);
            }
            reports.ToDataTable().SaveAsCsv(ConsoleFile.GetOutputFileName("IfcOptimizer_TimeEstimate", outputFolder, "", ".csv"));
            return reports;

            double GetRealTime(string inputFileName, string outputFolder)
            {
                Log.Information($"IfcOptimizer - Start");
                string copiedIfcFile = ConsoleFile.GetOutputFileName(inputFileName, outputFolder);
                ConsoleFile.CreateCopyIfcFile(inputFileName, copiedIfcFile);

                Stopwatch Watch = new Stopwatch();
                Watch.Start();
                TimeSpan Start = Watch.Elapsed;

                IConfigOptimize config = ConfigFactory.CreateConfigOptimize();
                config.PrecisionOpen = true;
                config.Precision = 4;
                config.OptimizePoint = true;
                config.OptimizePointList = true;
                config.MergeOpen = true;
                config.MergeOnlyResources = true;
                config.MergeReversedEntities = true;
                OptimizerProcessor.Process(copiedIfcFile, config);

                TimeSpan elapsed = Watch.Elapsed - Start;
                return elapsed.TotalSeconds;
            }
        }

        public static List<TimeReport> IfcRelocator_TimeEstimate(string outputFolder)
        {
            Dictionary<string, int> files = new Dictionary<string, int>();
            files.Add(LocalFiles.Ifc2x3_Duplex_Architecture, 38274); // ifcSite 38274
            files.Add(LocalFiles.Ifc4_Revit_ARC, 3371); // ifcSite 3371

            List<TimeReport> reports = new List<TimeReport>();
            foreach (var file in files)
            {
                var report = new TimeReport(file.Key);
                var estimateTime = 1;
                var realTime = GetRealTime(file.Key, outputFolder, file.Value);
                report.AddProcessingTime(realTime, estimateTime);
                report.LogDetail();
                reports.Add(report);
            }
            reports.ToDataTable().SaveAsCsv(ConsoleFile.GetOutputFileName("IfcRelocator_TimeEstimate", outputFolder, "", ".csv"));
            return reports;

            double GetRealTime(string inputFileName, string outputFolder, int entityLable)
            {
                Log.Information($"IfcRelocator - Start");
                string copiedIfcFile = ConsoleFile.GetOutputFileName(inputFileName, outputFolder);
                ConsoleFile.CreateCopyIfcFile(inputFileName, copiedIfcFile);

                Stopwatch Watch = new Stopwatch();
                Watch.Start();
                TimeSpan Start = Watch.Elapsed;

                IfcRelocatorSample.RelocateToOrigin(copiedIfcFile, entityLable);

                TimeSpan elapsed = Watch.Elapsed - Start;
                return elapsed.TotalSeconds;
            }
        }

        public static List<TimeReport> IfcSplitter_TimeEstimate(string outputFolder)
        {
            List<string> files = GetAllTestFiles();
            List<TimeReport> reports = new List<TimeReport>();
            foreach (var file in files)
            {
                var report = new TimeReport(file);
                var estimateTime = TimeEstimator.ForSplitterAsSeconds(file);
                var realTime = GetRealTime(file, outputFolder);
                report.AddProcessingTime(realTime, estimateTime);
                report.LogDetail();
                reports.Add(report);
            }
            reports.ToDataTable().SaveAsCsv(ConsoleFile.GetOutputFileName("IfcSplitter_TimeEstimate", outputFolder, "", ".csv"));
            return reports;

            double GetRealTime(string inputFileName, string outputFolder)
            {
                Log.Information($"IfcSplitter - Start");
                string copiedIfcFile = ConsoleFile.GetOutputFileName(inputFileName, outputFolder);
                ConsoleFile.CreateCopyIfcFile(inputFileName, copiedIfcFile);

                Stopwatch Watch = new Stopwatch();
                Watch.Start();
                TimeSpan Start = Watch.Elapsed;

                IConfigSplit config = ConfigFactory.CreateConfigSplit();
                config.SplitStrategy = SplitStrategy.DataOnly;
                using (var model = IfcStore.Open(copiedIfcFile))
                    SplitterProcessor.Split(model, config, copiedIfcFile);

                TimeSpan elapsed = Watch.Elapsed - Start;
                return elapsed.TotalSeconds;
            }
        }

        public static List<TimeReport> IfcConverter_TimeEstimate(string outputFolder)
        {
            List<string> files = GetAllTestFiles();
            List<TimeReport> reports = new List<TimeReport>();
            foreach (var file in files)
            {
                var report = new TimeReport(file);
                var estimateTime = TimeEstimator.ForConverterAsSeconds(file);
                var realTime = GetRealTime(file, outputFolder);
                report.AddProcessingTime(realTime, estimateTime);
                report.LogDetail();
                reports.Add(report);
            }
            reports.ToDataTable().SaveAsCsv(ConsoleFile.GetOutputFileName("IfcConverter_TimeEstimate", outputFolder, "", ".csv"));
            return reports;

            double GetRealTime(string inputFileName, string outputFolder)
            {
                Log.Information($"IfcConverter - Start");
                string copiedIfcFile = ConsoleFile.GetOutputFileName(inputFileName, outputFolder);
                ConsoleFile.CreateCopyIfcFile(inputFileName, copiedIfcFile);

                Stopwatch Watch = new Stopwatch();
                Watch.Start();
                TimeSpan Start = Watch.Elapsed;

                var convertOptionWarp = new ConvertOptionsWrap();
                var config = ConfigFactory.CreateConfigConvert(convertOptionWarp, ConvertTargetFormat.OBJ);
                ConverterProcessor.Process(copiedIfcFile, config);

                TimeSpan elapsed = Watch.Elapsed - Start;
                return elapsed.TotalSeconds;
            }
        }
    }
}
