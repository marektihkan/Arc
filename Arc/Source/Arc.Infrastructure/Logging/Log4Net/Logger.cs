#region License

// Copyright (c) 2008-2009 Marek Tihkan (marektihkan@gmail.com)
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//     * Neither the name of Marek Tihkan nor the names of its
//     contributors may be used to endorse or promote products derived from this
//     software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
// THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

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