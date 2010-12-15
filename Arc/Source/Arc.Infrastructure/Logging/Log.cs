using System;
using Arc.Infrastructure.Dependencies;

namespace Arc.Infrastructure.Logging
{
    public static class Log
    {
        /// <summary>
        /// Registers debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Debug(string message)
        {
            Provider.Debug(message);
        }

        /// <summary>
        /// Registers debug message with exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Debug(string message, Exception exception)
        {
            Provider.Debug(message, exception);
        }

        /// <summary>
        /// Registers information message.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Information(string message)
        {
            Provider.Information(message);
        }

        /// <summary>
        /// Registers information message with exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Information(string message, Exception exception)
        {
            Provider.Information(message, exception);
        }

        /// <summary>
        /// Registers warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Warning(string message)
        {
            Provider.Warning(message);
        }

        /// <summary>
        /// Registers warning message with exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Warning(string message, Exception exception)
        {
            Provider.Warning(message, exception);
        }

        /// <summary>
        /// Registers error message.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Error(string message)
        {
            Provider.Error(message);
        }

        /// <summary>
        /// Registers error message with exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Error(string message, Exception exception)
        {
            Provider.Error(message, exception);
        }

        /// <summary>
        /// Registers fatal message.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Fatal(string message)
        {
            Provider.Fatal(message);
        }

        /// <summary>
        /// Registers fatal message with exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Fatal(string message, Exception exception)
        {
            Provider.Fatal(message, exception);
        }

        private static ILogger Provider { get { return ServiceLocator.Resolve<ILogger>(); } } 
    }
}