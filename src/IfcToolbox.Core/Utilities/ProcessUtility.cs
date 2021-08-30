using Serilog;
using System.Diagnostics;
using System.IO;

namespace IfcToolbox.Core.Utilities
{
    public class ProcessUtility
    {
        public static void ProcessStart(string source, string target, string workingDirectory, string executableName, string optionPrompt = null, bool logDetail = false)
        {
            var info = new ProcessStartInfo();
            info.FileName = $"\"{Path.Combine(workingDirectory, executableName)}\"";
            info.WorkingDirectory = workingDirectory;
            info.Arguments = $"\"{source}\" \"{target}\" {optionPrompt}";

            info.RedirectStandardInput = false;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;

            using (var proc = new Process())
            {
                proc.StartInfo = info;
                proc.Start();
                string message = proc.StandardOutput.ReadToEnd();
                if (logDetail)
                    Log.Information(message);
            }
        }
    }
}
