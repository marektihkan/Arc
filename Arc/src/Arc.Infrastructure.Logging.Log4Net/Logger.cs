#region License
//
//   Copyright 2009 Marek Tihkan
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License
//
#endregion

using System;
using log4net;

namespace Arc.Infrastructure.Logging.Log4Net
{
    /// <summary>
    /// Logging service adapter for Log4Net.
    /// </summary>
    public class Logger : ILogger
    {
        private readonly ILog _logger;


        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="logger">The Log4Net logger.</param>
        public Logger(ILog logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Gets the inner logger.
        /// </summary>
        /// <value>The inner logger.</value>
        protected ILog InnerLogger
        {
            get { return _logger; }
        }

        /// <summary>
        /// Registers debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(string message)
        {
            InnerLogger.Debug(message);
        }

        /// <summary>
        /// Registers debug message with exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Debug(string message, Exception exception)
        {
            InnerLogger.Debug(message, exception);
        }

        /// <summary>
        /// Registers information message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Information(string message)
        {
            InnerLogger.Info(message);
        }

        /// <summary>
        /// Registers information message with exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Information(string message, Exception exception)
        {
            InnerLogger.Info(message, exception);
        }

        /// <summary>
        /// Registers warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Warning(string message)
        {
            InnerLogger.Warn(message);
        }

        /// <summary>
        /// Registers warning message with exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Warning(string message, Exception exception)
        {
            InnerLogger.Warn(message, exception);
        }

        /// <summary>
        /// Registers error message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error(string message)
        {
            InnerLogger.Error(message);
        }

        /// <summary>
        /// Registers error message with exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Error(string message, Exception exception)
        {
            InnerLogger.Error(message, exception);
        }

        /// <summary>
        /// Registers fatal message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Fatal(string message)
        {
            InnerLogger.Fatal(message);
        }

        /// <summary>
        /// Registers fatal message with exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Fatal(string message, Exception exception)
        {
            InnerLogger.Fatal(message, exception);
        }
    }
}