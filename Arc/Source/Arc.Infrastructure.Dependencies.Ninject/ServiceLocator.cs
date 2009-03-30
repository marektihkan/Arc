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
using Arc.Infrastructure.Utilities;
using Ninject.Core;
using Ninject.Core.Behavior;

namespace Arc.Infrastructure.Dependencies.Ninject
{
    /// <summary>
    /// Ninject adapter for service locator.
    /// </summary>
    public class ServiceLocator : IServiceLocator, IServiceLocatorConfiguration
    {
        private readonly IScopeFactory _scopeFactory = new ScopeFactory();


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


        private IKernel Kernel { get; set; }

        /// <summary>
        /// Gets the scope factory.
        /// </summary>
        /// <value>The scope factory.</value>
        public IScopeFactory Scopes
        {
            get { return _scopeFactory; }
        }

        /// <summary>
        /// Gets the service locator's configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IServiceLocatorConfiguration Configuration
        {
            get { return this; }
        }


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
        /// Registers service to implementation.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        public void Register<TService, TImplementation>() //where TImplementation : TService
        {
            Register(typeof(TService), typeof(TImplementation));
        }

        /// <summary>
        /// Registers service to implementation in specified scope.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="scope">The scope.</param>
        public void Register<TService, TImplementation>(IScope scope) //where TImplementation : TService
        {
            Register(typeof(TService), typeof(TImplementation), scope);
        }

        /// <summary>
        /// Registers service to implementation.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="implementation">The implementation.</param>
        public void Register(Type service, Type implementation)
        {
            Register(service, implementation, Scopes.Transient);
        }

        /// <summary>
        /// Registers service to implementation in specified scope.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="implementation">The implementation.</param>
        /// <param name="scope">The scope.</param>
        public void Register(Type service, Type implementation, IScope scope)
        {
            var scopeBehavior = scope.Implementation as IBehavior;
            
            //NOTE: Workaround for ninject inline module loeading bug.
            var binding = Kernel.Components.BindingFactory.Create(service);
            binding.Behavior = scopeBehavior;
            binding.Provider = Kernel.Components.ProviderFactory.Create(implementation);

            Kernel.AddBinding(binding);

            //var configuration = new InlineModule(x => x.Bind(service).To(implementation).Using(scopeBehavior));
            //NOTE: It could override configuration, not throw exception.
            //Should.Do(() => Kernel.Load(configuration)).On<InvalidOperationException>(delegate { });
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