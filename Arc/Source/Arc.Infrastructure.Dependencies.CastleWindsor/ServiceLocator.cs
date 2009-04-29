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
using Arc.Infrastructure.Dependencies.CastleWindsor.Extensions;
using Arc.Infrastructure.Dependencies.CastleWindsor.Registration;
using Arc.Infrastructure.Utilities;
using Castle.Core;
using Castle.Facilities.FactorySupport;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using IRegistration=Arc.Infrastructure.Dependencies.Registration.IRegistration;
using Arc.Infrastructure.Dependencies.CastleWindsor;

namespace Arc.Infrastructure.Dependencies.CastleWindsor
{
    /// <summary>
    /// Ninject adapter for service locator.
    /// </summary>
    public class ServiceLocator : IServiceLocator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocator"/> class.
        /// </summary>
        public ServiceLocator() : this(new WindsorContainer())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocator"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public ServiceLocator(IWindsorContainer container)
        {
            ComponentRegistrationExtensions.Kernel = container.Kernel;
            container.AddFacility("factory.support", new FactorySupportFacility());

            Container = container;
        }

        internal IWindsorContainer Container { get; set; }

        /// <summary>
        /// Loads the specified module by name.
        /// Module should implement <c>Arc.Dependencies.IServiceLocatorModule&lt;Castle.Windsor.IWindsorContainer&gt;</c>
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        /// <exception cref="ArgumentException">moduleName</exception>
        public void Load(string moduleName)
        {
            var moduleType = Find.TypeWithInterface<IServiceLocatorModule<IWindsorContainer>>(moduleName);
            var configuration = ResolveProvider<IServiceLocatorModule<IWindsorContainer>>.WithRealType(moduleType);
            configuration.Configure(Container);
        }

        /// <summary>
        /// Loads the specified modules by name.
        /// Module should implement <c>Arc.Dependencies.IServiceLocatorModule&lt;Castle.Windsor.IWindsorContainer&gt;</c>
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
        public void Load(IServiceLocatorModule<IServiceLocator> configuration)
        {
            configuration.Configure(this);
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
            return Container.Resolve(type);
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
            return Container.Resolve(service, parameters.GetArguments());
        }

        /// <summary>
        /// Releases the specified object.
        /// </summary>
        /// <param name="releasable">The releasable object.</param>
        public void Release(object releasable)
        {
            Container.Release(releasable);
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
            Container.Dispose();
        }
    }
}