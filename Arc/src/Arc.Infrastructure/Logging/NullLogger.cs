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