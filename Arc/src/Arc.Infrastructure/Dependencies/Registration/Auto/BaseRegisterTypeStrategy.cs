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

namespace Arc.Infrastructure.Dependencies.Registration.Auto
{
    /// <summary>
    /// Register type strategy base.
    /// </summary>
    public abstract class BaseRegisterTypeStrategy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRegisterTypeStrategy"/> class.
        /// </summary>
        protected BaseRegisterTypeStrategy()
        {
            Scope = ServiceLifeStyle.Transient;
        }

        /// <summary>
        /// Gets or sets the scope.
        /// </summary>
        /// <value>The scope.</value>
        public ServiceLifeStyle Scope { get; set; }

        /// <summary>
        /// Registers the specified service.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="implementation">The implementation.</param>
        /// <param name="locator">The locator.</param>
        protected void Register(Type service, Type implementation, IServiceLocator locator)
        {
            locator.Register(
                Requested.Service(service)
                    .IsImplementedBy(implementation)
                    .LifeStyle.Is(Scope));
        }
    }
}