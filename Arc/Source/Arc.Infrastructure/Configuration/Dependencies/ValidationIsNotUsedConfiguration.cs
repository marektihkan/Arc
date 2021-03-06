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

using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using Arc.Infrastructure.Validation;

namespace Arc.Infrastructure.Configuration.Dependencies
{
    /// <summary>
    /// Configuration for validation when its not used.
    /// </summary>
    public class ValidationIsNotUsedConfiguration : IConfiguration<IServiceLocator>
    {
        /// <summary>
        /// Creates default configuration.
        /// </summary>
        /// <returns>Default configuration.</returns>
        public static ValidationIsNotUsedConfiguration Default()
        {
            return new ValidationIsNotUsedConfiguration();
        }

        /// <summary>
        /// Loads the validation configuration to service locator.
        /// </summary>
        /// <param name="handler">The service locator.</param>
        public void Load(IServiceLocator handler)
        {
            handler.Register(
                Requested.Service<IValidationService>().IsImplementedBy<NullValidationService>()
            );
        }
    }
}