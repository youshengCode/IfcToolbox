using System.IO;
using Xbim.Ifc;

namespace IfcToolbox.Core.Utilities
{
    public static class ConsoleFile
    {
        public static string GetOutputFileName(string inputFilePath, string outputFolder, string suffix = "_Modified", string newExtension = null)
        {
            string outputFileName = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputFilePath) + suffix + Path.GetExtension(inputFilePath));
            if (!string.IsNullOrEmpty(newExtension))
                outputFileName = Path.ChangeExtension(outputFileName, newExtension);
            return outputFileName;
        }

        public static string CreateLogFile(string sourceFilePath, string logContent)
        {
            string logFilePath = Path.ChangeExtension(sourceFilePath, ".txt");
            // Log file need clean up each time.
            if (File.Exists(logFilePath))
                File.Delete(logFilePath);
            File.WriteAllText(logFilePath, logContent);
            return logFilePath;
        }

        public static void CreateCopyIfcFile(string filePath, string outputFilePath)
        {
            using (var model = IfcStore.Open(filePath))
            {
                model.SaveAs(outputFilePath);
                Marslogger.Action($"File Copied and Saved - {Path.GetFileName(outputFilePath)}");
            }
        }

        public static void CopyOriginalIfcFile(string filePath, string outputFilePath, string suffix = "_Original")
        {
            using (var model = IfcStore.Open(filePath))
            {
                outputFilePath = Path.Combine(Path.GetDirectoryName(outputFilePath), Path.GetFileNameWithoutExtension(filePath) + suffix + Path.GetExtension(filePath));
                model.SaveAs(outputFilePath);
                Marslogger.Action("Copied original file");
            }
        }

        public static string RemoveSuffixFromName(string filePath, string suffix)
        {
            string outputFileName = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath).Replace(suffix, string.Empty) + Path.GetExtension(filePath));
            return outputFileName;
        }

        public static string AddSuffixToName(string filePath, string suffix)
        {
            string outputFileName = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + suffix + Path.GetExtension(filePath));
            return outputFileName;
        }

        public static string RemoveInvalidCharsInFileName(string fileName)
        {
            return string.Concat(fileName.Split(Path.GetInvalidFileNameChars()));
        }

        public static string CreateIndexedSuffix(string name, bool isMultipal, int index, string placeholder)
        {
            var suffix = RemoveInvalidCharsInFileName(name);
            if (string.IsNullOrEmpty(suffix))
            {
                if (isMultipal)
                    suffix = $"_{index}_{placeholder}";
                else
                    suffix = $"_{placeholder}";
            }
            else
            {
                if (isMultipal)
                    suffix = $"_{index}_{suffix}";
                else
                    suffix = $"_{suffix}";
            }
            return suffix;
        }

        public static string CreateIndexedSuffix(string name, bool isMultipal, int index, string placeholder,
            bool isNested, string parentName, bool isParentMultipal, int parentIndex, string parentPlaceholder)
        {
            if (isNested)
                if (isParentMultipal)
                {
                    var parentSuffix = CreateIndexedSuffix(parentName, isParentMultipal, parentIndex, parentPlaceholder);
                    var suffix = CreateIndexedSuffix(name, isMultipal, index, placeholder);
                    return parentSuffix + suffix;
                }
            return CreateIndexedSuffix(name, isMultipal, index, placeholder);
        }
    }
}
