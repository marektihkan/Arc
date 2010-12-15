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
    /// Empty validation results.
    /// </summary>
    public class EmptyValidationResults : IValidationResults
    {
        /// <summary>
        /// This is always valid.
        /// </summary>
        public bool IsValid
        {
            get { return true; }
        }

        /// <summary>
        /// Gets the first message for given tag.
        /// </summary>
        /// <param name="tag">The key.</param>
        /// <returns>
        /// Empty string.
        /// </returns>
        public string GetFirstMessageFor(string tag)
        {
            return string.Empty;
        }

        /// <summary>
        /// Gets the messages for given tag.
        /// </summary>
        /// <param name="tag">The key.</param>
        /// <returns>
        /// Empty array.
        /// </returns>
        public string[] GetMessagesFor(string tag)
        {
            return new string[0];
        }

        /// <summary>
        /// Gets the summary.
        /// </summary>
        /// <value>Empty string.</value>
        public string Summary
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// Gets all errors.
        /// </summary>
        /// <value>All errors.</value>
        public KeyValuePair<string, string>[] AllErrors
        {
            get { return null; }
        }
    }
}