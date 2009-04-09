using System;

namespace Arc.Infrastructure.Logging
{
    /// <summary>
    /// Null logger.
    /// </summary>
    public class NullLogger : ILogger
    {
        /// <summary>
        /// Does nothing.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(string message)
        {
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Debug(string message, Exception exception)
        {
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Information(string message)
        {
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Information(string message, Exception exception)
        {
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Warning(string message)
        {
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Warning(string message, Exception exception)
        {
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error(string message)
        {
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Error(string message, Exception exception)
        {
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Fatal(string message)
        {
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Fatal(string message, Exception exception)
        {
        }
    }
}