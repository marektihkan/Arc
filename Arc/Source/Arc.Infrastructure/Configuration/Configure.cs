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

using Arc.Infrastructure.Configuration.Syntax;

namespace Arc.Infrastructure.Configuration
{
    /// <summary>
    /// DSL for configuring Arc application.
    /// </summary>
    public class Configure
    {
        private static readonly IServiceLocatorProviderConfiguration _serviceLocatorProviderConfiguration;

        /// <summary>
        /// Initializes the <see cref="Configure"/> class.
        /// </summary>
        static Configure()
        {
            _serviceLocatorProviderConfiguration = new ServiceLocatorProviderConfiguration();
        }


        /// <summary>
        /// Gets the service locator provider configuration.
        /// </summary>
        /// <value>The service locator provider configuration.</value>
        public static IServiceLocatorProviderConfiguration ServiceLocator
        {
            get
            {
                return _serviceLocatorProviderConfiguration;
            }
        }
    }
}