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
using System.Collections;
using System.Collections.Generic;
using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Dependencies.Registration;

namespace Arc.Infrastructure.Dependencies
{
    /// <summary>
    /// Finds requested services.
    /// </summary>
    public interface IServiceLocator : IDisposable
    {
		/// <summary>
		/// Resolves all services for given type
		/// </summary>
		/// <typeparam name="TService">The type of the service.</typeparam>
		/// <returns></returns>
		IEnumerable<TService> ResolveAll<TService>();

		/// <summary>
		/// Resolves all services for given type
		/// </summary>
		/// <returns></returns>
		IEnumerable ResolveAll(Type service);

        /// <summary>
        /// Resolves requested service.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns>Requested service.</returns>
        TService Resolve<TService>();

        /// <summary>
        /// Resolves requested service.
        /// </summary>
        /// <param name="type">The service type.</param>
        /// <returns>Requested service.</returns>
        object Resolve(Type type);

        /// <summary>
        /// Resolves service with the specified parameters.
        /// <code>
        /// serviceLocator.Resolve&lt;IService&gt;(With.Parameters.ConstructorArgument("name", value));
        /// </code>
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        TService Resolve<TService>(IParameters parameters);

        /// <summary>
        /// Resolves service with specified parameters.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        object Resolve(Type service, IParameters parameters);

        /// <summary>
        /// Releases the specified object.
        /// </summary>
        /// <param name="releasable">The releasable object.</param>
        void Release(object releasable);

        /// <summary>
        /// Loads the specified module by name.
        /// It should load module for concrete implementation of service locator.
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        void Load(string moduleName);

        /// <summary>
        /// Loads the specified service locator modules by name.
        /// It should load module for concrete implementation of service locator.
        /// </summary>
        /// <param name="moduleNames">The module names.</param>
        void Load(params string[] moduleNames);

        /// <summary>
        /// Loads the specified configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        void Load(IConfiguration<IServiceLocator> configuration);

        /// <summary>
        /// Registers the specified bindings.
        /// </summary>
        /// <param name="registrations">The registrations.</param>
        void Register(params IRegistration[] registrations);
    }
}