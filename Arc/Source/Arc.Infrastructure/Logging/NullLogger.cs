using System;

namespace Arc.Infrastructure.Logging
{
    public class NullLogger : ILogger
    {
        public void Debug(string message)
        {
        }

        public void Debug(string message, Exception exception)
        {
        }

        public void Information(string message)
        {
        }

        public void Information(string message, Exception exception)
        {
        }

        public void Warning(string message)
        {
        }

        public void Warning(string message, Exception exception)
        {
        }

        public void Error(string message)
        {
        }

        public void Error(string message, Exception exception)
        {
        }

        public void Fatal(string message)
        {
        }

        public void Fatal(string message, Exception exception)
        {
        }
    }
}