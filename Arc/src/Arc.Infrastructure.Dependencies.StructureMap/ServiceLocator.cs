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
using Arc.Infrastructure.Dependencies.StructureMap.Registration;
using Arc.Infrastructure.Utilities;
using StructureMap;
using StructureMap.Pipeline;

namespace Arc.Infrastructure.Dependencies.StructureMap
{
    /// <summary>
    /// Ninject adapter for service locator.
    /// </summary>
    public class ServiceLocator : IServiceLocator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocator"/> class.
        /// </summary>
        public ServiceLocator() : this(new Container())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocator"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public ServiceLocator(IContainer container)
        {
            Container = container;
        }

        internal IContainer Container { get; private set; }

        /// <summary>
        /// Loads the specified module by name.
        /// Module should implement <c>Arc.Dependencies.IServiceLocatorModule&lt;StructureMap.IContainer&gt;</c>
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        /// <exception cref="ArgumentException">moduleName</exception>
        public void Load(string moduleName)
        {
            var moduleType = Find.TypeWithInterface<IConfiguration<IContainer>>(moduleName);   
            var configuration = ResolveProvider<IConfiguration<IContainer>>.WithRealType(moduleType);
            configuration.Load(Container);
        }

        /// <summary>
        /// Loads the specified modules by name.
        /// Module should implement <c>Arc.Dependencies.IServiceLocatorModule&lt;StructureMap.IContainer&gt;</c>
        /// </summary>
        /// <param name="moduleNames">The module names.</param>
        public void Load(params string[] moduleNames)
        {
            foreach (var module in moduleNames)
            {
                Load(module);
            }
        }

        /// <summary>
        /// Loads the specified configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public void Load(IConfiguration<IServiceLocator> configuration)
        {
            configuration.Load(this);
        }

        /// <summary>
        /// Resolves requested service.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns>Requested service.</returns>
        public TService Resolve<TService>()
        {
            return (TService)Resolve(typeof(TService));
        }

        /// <summary>
        /// Resolves requested service.
        /// </summary>
        /// <param name="type">The service type.</param>
        /// <returns>Requested service.</returns>
        public object Resolve(Type type)
        {
            return Container.GetInstance(type);
        }

        /// <summary>
        /// Resolves the specified parameters.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public TService Resolve<TService>(IParameters parameters)
        {
            return (TService) Resolve(typeof(TService), parameters);
        }

        /// <summary>
        /// Resolves service with specified parameters.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public object Resolve(Type service, IParameters parameters)
        {
            return Container.GetInstance(service, new ExplicitArguments(parameters.Arguments));
        }

        /// <summary>
        /// Releases the specified object.
        /// </summary>
        /// <param name="releasable">The releasable object.</param>
        public void Release(object releasable)
        {
        }

        /// <summary>
        /// Registers the specified bindings.
        /// </summary>
        /// <param name="registrations">The registrations.</param>
        public void Register(params IRegistration[] registrations)
        {
            foreach (var registration in registrations)
            {
                RegistrationStrategyFactory.Create(registration, this).Register();
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposeAll"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposeAll)
        {
        }
    }
}