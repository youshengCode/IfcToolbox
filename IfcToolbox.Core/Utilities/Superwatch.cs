using System;
using System.Diagnostics;

namespace IfcToolbox.Core.Utilities
{
    public class Superwatch : IDisposable
    {
        static Stopwatch Watch = new Stopwatch();
        static Superwatch()
        {
            Watch.Start();
        }

        TimeSpan Start;
        public Superwatch()
        {
            Start = Watch.Elapsed;
        }

        public void Dispose()
        {
            TimeSpan elapsed = Watch.Elapsed - Start;
            Marslogger.Action($"Process completed in : {elapsed.Hours}:{elapsed.Minutes}:{elapsed.Seconds}", "SuperWatch");
        }
    }
}
