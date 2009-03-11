using System;
using System.IO;

namespace ArcWizard.Infrastructure
{
    public class FileLogger : ILogger
    {
        private const string LOG_FILE_NAME = "Arc.Template.log";
        private readonly string _logPath;

        public FileLogger(string logPath)
        {
            _logPath = logPath + "\\" + LOG_FILE_NAME;
        }

        public void WriteLine(string message)
        {
            var streamWriter = File.AppendText(_logPath);
            streamWriter.WriteLine(DateTime.Now.ToLongTimeString() + "\t" + message);
            streamWriter.Close();
        }
    }
}