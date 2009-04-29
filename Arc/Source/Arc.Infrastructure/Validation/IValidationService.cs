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

namespace Arc.Infrastructure.Validation
{
    /// <summary>
    /// Validation service.
    /// </summary>
    public interface IValidationService
    {
        /// <summary>
        /// Validates the specified validatable.
        /// </summary>
        /// <param name="validatable">The validatable.</param>
        /// <returns>Validation results.</returns>
        IValidationResults Validate(object validatable);

        /// <summary>
        /// Validates the specified validatable.
        /// </summary>
        /// <typeparam name="T">Validatable type.</typeparam>
        /// <param name="validatable">The validatable.</param>
        /// <returns>Validation results.</returns>
        IValidationResults Validate<T>(object validatable);

        /// <summary>
        /// Validates the specified validatable.
        /// </summary>
        /// <param name="validatable">The validatable.</param>
        /// <param name="validationType">Type of the validation.</param>
        /// <returns>Validation results.</returns>
        IValidationResults Validate(object validatable, Type validationType);
    }
}