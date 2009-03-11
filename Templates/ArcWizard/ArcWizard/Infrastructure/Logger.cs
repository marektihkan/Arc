using System;
using ArcWizard.Core;

namespace ArcWizard.Infrastructure
{
    public class Logger
    {
        private static ILogger InnerLogger { get; set; }

        public static void Configure(Configuration configuration)
        {
            try
            {
                InnerLogger = new FileLogger(configuration.RootPath);
                WriteLine("Logging to " + configuration.RootPath);
            }
            catch (Exception e)
            {
                InnerLogger = new MessageBoxLogger();
                WriteLine("Logger configuration was unsuccessful: " + e.Message);
            }
        }

        public static void WriteLine(string message)
        {
            InnerLogger.WriteLine(message);
        }
    }
}