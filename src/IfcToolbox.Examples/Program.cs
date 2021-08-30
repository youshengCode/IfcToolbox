using IfcToolbox.Core.Utilities;
using System;

namespace IfcToolbox.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Marslogger.ConfigureConsoleLogger();
            Marslogger.Step("Starting...");
            SampleProcess.Start();
            Marslogger.Step("Finished. Press enter key to exit...", true);
        }
    }
}
