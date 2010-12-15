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
using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Dependencies.Registration;

namespace Arc.Infrastructure.Dependencies
{
    /// <summary>
    /// Locates services by type. 
    /// </summary>
    public static class ServiceLocator
    {
        private static IServiceLocator _locator;

        /// <summary>
        /// Gets or sets the inner service locator.
        /// </summary>
        /// <value>The inner service locator.</value>
        public static IServiceLocator InnerServiceLocator
        {
            get { return _locator; }
            set { _locator = value; }
        }

        /// <summary>
        /// Loads the specified module by name.
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        /// <exception cref="ArgumentException">moduleName</exception>
        public static void Load(string moduleName)
        {
            InnerServiceLocator.Load(moduleName);
        }

        /// <summary>
        /// Loads the specified modules by name.
        /// </summary>
        /// <param name="moduleNames">The module names.</param>
        public static void Load(params string[] moduleNames)
        {
            InnerServiceLocator.Load(moduleNames);
        }

        /// <summary>
        /// Loads the specified configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public static void Load(IConfiguration<IServiceLocator> configuration)
        {
            InnerServiceLocator.Load(configuration);
        }

        /// <summary>
        /// Registers the specified bindings.
        /// </summary>
        /// <param name="registrations">The registrations.</param>
        public static void Register(params IRegistration[] registrations)
        {
            InnerServiceLocator.Register(registrations);
        }


        /// <summary>
        /// Resolves requested service.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns>Requested service.</returns>
        public static TService Resolve<TService>()
        {
            return InnerServiceLocator.Resolve<TService>();
        }

        /// <summary>
        /// Resolves requested service.
        /// </summary>
        /// <param name="type">The service type.</param>
        /// <returns>Requested service.</returns>
        public static object Resolve(Type type)
        {
            return InnerServiceLocator.Resolve(type);
        }

        /// <summary>
        /// Resolves service with the specified parameters.
        /// <code>
        /// serviceLocator.Resolve&lt;IService&gt;(With.Parameters.ConstructorArgument("name", value));
        /// </code>
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static TService Resolve<TService>(IParameters parameters)
        {
            return InnerServiceLocator.Resolve<TService>(parameters);   
        }

        /// <summary>
        /// Resolves service with specified parameters.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static object Resolve(Type service, IParameters parameters)
        {
            return InnerServiceLocator.Resolve(service, parameters);   
        }

        /// <summary>
        /// Releases the specified object.
        /// </summary>
        /// <param name="releasable">The releasable object.</param>
        public static void Release(object releasable)
        {
            InnerServiceLocator.Release(releasable);
        }
    }
}