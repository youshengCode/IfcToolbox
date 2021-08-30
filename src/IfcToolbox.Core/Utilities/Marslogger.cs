using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Linq;
using System.Text;
using Xbim.Common;
using Xbim.Common.Delta;

namespace IfcToolbox.Core.Utilities
{
    public class Marslogger
    {
        public static void ConfigureConsoleLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .CreateLogger();
        }

        public static void Mark(object info)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{DateTime.Now.ToString("HH:mm:ss")} MAK] {info} ");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void Action(string action, string className = null)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (className == null)
                Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")} ACT] {action}");
            else
                Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")} ACT] {action} >>> {className}");
            Console.ResetColor();
        }

        public static void Step(string action, bool finalStep = false)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")} STP] {action}");
            Console.ResetColor();
            if (finalStep)
            {
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            }
        }

        public static void PrintChanges(TransactionLog log, bool logDetail = false)
        {
            Action("Modification", "Serilog");
            if (logDetail)
            {
                foreach (var change in log.Changes)
                {
                    switch (change.ChangeType)
                    {
                        case ChangeType.New:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(@"New entity: {0}", change.CurrentEntity);
                            Console.ResetColor();
                            break;
                        case ChangeType.Deleted:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine(@"Deleted entity: {0}", change.OriginalEntity);
                            Console.ResetColor();
                            break;
                        case ChangeType.Modified:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(@"Changed Entity: #{0}={1}", change.Entity.EntityLabel, change.Entity.ExpressType.ExpressNameUpper);
                            foreach (var prop in change.ChangedProperties)
                                Console.WriteLine(@"        Property '{0}' changed from {1} to {2}", prop.Name, prop.OriginalValue, prop.CurrentValue);
                            Console.ResetColor();
                            break;
                        default:
                            break;
                    }
                }
            }
            Log.Information("[New entity total] {0}", log.Changes.Where(o => o.ChangeType == ChangeType.New).Count().ToString());
            Log.Information("[Changed entity total] {0}", log.Changes.Where(o => o.ChangeType == ChangeType.Modified).Count().ToString());
            Log.Information("[Deleted entity total] {0}", log.Changes.Where(o => o.ChangeType == ChangeType.Deleted).Count().ToString());
        }

        public static StringBuilder CreateLog(TransactionLog log)
        {
            StringBuilder logContent = new StringBuilder();
            logContent.AppendLine($"[SUMMARY]");
            logContent.AppendLine($"New entity >> {log.Changes.Where(o => o.ChangeType == ChangeType.New).Count()}");
            logContent.AppendLine($"Changed entity >> {log.Changes.Where(o => o.ChangeType == ChangeType.Modified).Count()}");
            logContent.AppendLine($"Deleted entity >> {log.Changes.Where(o => o.ChangeType == ChangeType.Deleted).Count()}");
            logContent.AppendLine();

            foreach (var change in log.Changes)
            {
                switch (change.ChangeType)
                {
                    case ChangeType.New:
                        logContent.AppendLine($"New entity: {change.CurrentEntity}");
                        break;
                    case ChangeType.Deleted:
                        logContent.AppendLine($"Deleted entity: {change.OriginalEntity}");
                        break;
                    case ChangeType.Modified:
                        logContent.AppendLine($"Changed Entity: #{change.Entity.EntityLabel}={change.Entity.ExpressType.ExpressNameUpper}");
                        foreach (var prop in change.ChangedProperties)
                            logContent.AppendLine($"        Property '{prop.Name}' changed from {prop.OriginalValue} to {prop.CurrentValue}");
                        break;
                    default:
                        break;
                }
            }
            return logContent;
        }
    }
}
