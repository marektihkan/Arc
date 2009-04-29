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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace Arc.Infrastructure.Validation.EnterpriseLibrary
{
    /// <summary>
    /// Validation results adapter for Enterprise Library Validation Block.
    /// </summary>
    public class ValidationResultsAdapter : IValidationResults
    {
        private readonly ValidationResults _errors;


        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResultsAdapter"/> class.
        /// </summary>
        /// <param name="errors">The validation errors.</param>
        public ValidationResultsAdapter(ValidationResults errors)
        {
            _errors = errors;
        }


        /// <summary>
        /// Gets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public bool IsValid
        {
            get { return _errors.IsValid; }
        }

        /// <summary>
        /// Gets the first message for given tag.
        /// </summary>
        /// <param name="tag">The key.</param>
        /// <returns>
        /// First message for given tag or empty string.
        /// </returns>
        public string GetFirstMessageFor(string tag)
        {
            var firstError = _errors.Where(x => x.Tag == tag).FirstOrDefault();
            return (firstError == null) ? string.Empty : firstError.Message;
        }

        /// <summary>
        /// Gets the messages for given tag.
        /// </summary>
        /// <param name="tag">The key.</param>
        /// <returns>
        /// All messages for given tag or empty array.
        /// </returns>
        public string[] GetMessagesFor(string tag)
        {
            var messages = _errors.Where(x => x.Tag == tag).Select(x => x.Message);
            return messages.ToArray();
        }

        /// <summary>
        /// Gets all errors.
        /// </summary>
        /// <value>All errors.</value>
        public KeyValuePair<string, string>[] AllErrors
        {
            get
            {
                return _errors.Select(x => new KeyValuePair<string, string>(x.Tag, x.Message)).ToArray();
            }
        }

        /// <summary>
        /// Gets the summary.
        /// </summary>
        /// <value>The summary.</value>
        public string Summary
        {
            get
            {
                var summary = new StringBuilder();

                foreach (var error in _errors)
                {
                    summary.Append(error.Tag);
                    summary.Append(": ");
                    summary.Append(error.Message);
                    summary.Append(Environment.NewLine);
                }
                return summary.ToString();
            }
        }
    }
}