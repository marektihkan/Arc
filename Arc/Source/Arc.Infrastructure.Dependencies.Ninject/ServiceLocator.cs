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
using Arc.Infrastructure.Dependencies.Ninject.Registration;
using Arc.Infrastructure.Dependencies.Registration;
using Arc.Infrastructure.Utilities;
using Ninject.Core;
using Ninject.Core.Behavior;

namespace Arc.Infrastructure.Dependencies.Ninject
{
    /// <summary>
    /// Ninject adapter for service locator.
    /// </summary>
    public class ServiceLocator : IServiceLocator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocator"/> class.
        /// </summary>
        public ServiceLocator() : this(new StandardKernel())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocator"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public ServiceLocator(IKernel kernel)
        {
            Kernel = kernel;
        }


        internal IKernel Kernel { get; set; }


        /// <summary>
        /// Loads the specified module by name.
        /// Module should implement Ninject.IModule interface.
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        /// <exception cref="ArgumentException">moduleName</exception>
        public void Load(string moduleName)
        {
            var moduleType = Find.TypeWithInterface<IModule>(moduleName);
            var configuration = ResolveProvider<IModule>.WithRealType(moduleType);
                
            if (!Kernel.Components.ModuleManager.IsLoaded(configuration))
                Kernel.Load(configuration);
        }

        /// <summary>
        /// Loads the specified modules by name.
        /// Module should implement Ninject.IModule interface.
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
            return Kernel.Get(type);
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
            return Kernel.Get(service, global::Ninject.Core.Parameters.With.Parameters.ConstructorArguments(parameters.GetArguments()));
        }

        /// <summary>
        /// Releases the specified object.
        /// </summary>
        /// <param name="releasable">The releasable object.</param>
        public void Release(object releasable)
        {
            Kernel.Release(releasable);
        }

        public void Register(params IRegistration[] registrations)
        {
            //TODO: Registration

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
            Kernel.Dispose();   
        }
    }
}