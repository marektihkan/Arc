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