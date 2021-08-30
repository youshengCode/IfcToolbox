using IfcToolbox.Core.Utilities;
using System;
using System.Collections.Generic;
using System.IO;

namespace IfcToolbox.Core.Convert
{
    public class IfcConvert
    {
        public static void Convert(string source, IConvertOptionsWrap optionsWrap, ConvertTargetFormat format, bool logDetail = false)
        {
            string target = Path.ChangeExtension(source, $".{format.ToString().ToLower()}");
            string logFilePath = Path.ChangeExtension(source, ".txt");
            Convert(source, target, optionsWrap, format, logFilePath, logDetail);
        }

        public static IEnumerable<string> Convert(string source, string target, IConvertOptionsWrap optionsWrap, ConvertTargetFormat format,
            string logFilePath = null, bool logDetail = false, string workingDirectory = null)
        {
            string executableName = ExecutableName;
            if (string.IsNullOrEmpty(workingDirectory))
                workingDirectory = ReflectionUtility.GetExecutingAssemblyDirectory;
            var optionPrompt = ConvertOptionService.GeneratePrompt(optionsWrap, format, logFilePath, true);

            ProcessUtility.ProcessStart(source, target, workingDirectory, executableName, optionPrompt, logDetail);

            var finalFiles = new List<string>();
            if (File.Exists(target))
                finalFiles.Add(target);
            // .mtl file generated with obj file.
            if (format == ConvertTargetFormat.OBJ)
            {
                var mtlFile = Path.ChangeExtension(target, ".mtl");
                if (File.Exists(mtlFile))
                    finalFiles.Add(mtlFile);
            }
            // add log file if log is not empty
            if (File.Exists(logFilePath))
            {
                if (!string.IsNullOrEmpty(File.ReadAllText(logFilePath)))
                    finalFiles.Add(logFilePath);
                else
                    File.Delete(logFilePath);
            }
            return finalFiles;
        }

        public static string ExecutableName
        {
            get
            {
                string executableName = "IfcConvert_x64.exe";
                if (!Environment.Is64BitOperatingSystem)
                    executableName = "IfcConvert_x32.exe";
                return executableName;
            }
        }

        public static string GetExcludeEntitiesDefault(ConvertTargetFormat format)
        {
            if (format == ConvertTargetFormat.SVG)
                return "IfcOpeningElement";
            else
                return "IfcOpeningElement IfcSpace";
        }
    }
}

