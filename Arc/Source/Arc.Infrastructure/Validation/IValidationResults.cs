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

using System.Collections.Generic;

namespace Arc.Infrastructure.Validation
{
    /// <summary>
    /// Validation results.
    /// </summary>
    public interface IValidationResults
    {
        /// <summary>
        /// Gets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        bool IsValid { get; }

        /// <summary>
        /// Gets the first message for given tag.
        /// </summary>
        /// <param name="tag">The key.</param>
        /// <returns>First message for given tag or empty string.</returns>
        string GetFirstMessageFor(string tag);

        /// <summary>
        /// Gets the messages for given tag.
        /// </summary>
        /// <param name="tag">The key.</param>
        /// <returns>All messages for given tag or empty array.</returns>
        string[] GetMessagesFor(string tag);

        /// <summary>
        /// Gets the summary.
        /// </summary>
        /// <value>The summary.</value>
        string Summary { get; }

        /// <summary>
        /// Gets all errors.
        /// </summary>
        /// <value>All errors.</value>
        KeyValuePair<string, string>[] AllErrors { get; }
    }
}