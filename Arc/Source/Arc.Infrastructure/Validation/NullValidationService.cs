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

namespace Arc.Infrastructure.Validation
{
    /// <summary>
    /// Null validation service.
    /// </summary>
    public class NullValidationService : IValidationService
    {
        /// <summary>
        /// Validates the specified validatable.
        /// </summary>
        /// <param name="validatable">The validatable.</param>
        /// <returns>Empty validation results.</returns>
        public IValidationResults Validate(object validatable)
        {
            return new EmptyValidationResults();
        }

        /// <summary>
        /// Validates the specified validatable.
        /// </summary>
        /// <typeparam name="T">Validatable type.</typeparam>
        /// <param name="validatable">The validatable.</param>
        /// <returns>Empty validation results.</returns>
        public IValidationResults Validate<T>(object validatable)
        {
            return new EmptyValidationResults();
        }

        /// <summary>
        /// Validates the specified validatable.
        /// </summary>
        /// <param name="validatable">The validatable.</param>
        /// <param name="validationType">Type of the validation.</param>
        /// <returns>Empty validation results.</returns>
        public IValidationResults Validate(object validatable, Type validationType)
        {
            return new EmptyValidationResults();
        }
    }
}