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

namespace Arc.Infrastructure.Dependencies.Registration
{
    /// <summary>
    /// Registration for service locator.
    /// </summary>
    public interface IRegistration
    {
        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>The type of the service.</value>
        Type ServiceType { get; set; }

        /// <summary>
        /// Gets or sets the life style scope.
        /// </summary>
        /// <value>The life style scope.</value>
        ServiceLifeStyle Scope { get; set; }

        /// <summary>
        /// Gets or sets the type of the implementation.
        /// </summary>
        /// <value>The type of the implementation.</value>
        Type ImplementationType { get; set; }

        /// <summary>
        /// Gets or sets the factory method.
        /// </summary>
        /// <value>The factory method.</value>
        Func<IServiceLocator, object> Factory { get; set; }

        /// <summary>
        /// Gets the life style builder.
        /// </summary>
        /// <value>The life style builder.</value>
        IServiceLifeStyleSyntax LifeStyle { get; }
    }
}