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

namespace Arc.Infrastructure.Dependencies
{
    /// <summary>
    /// Finds requested services.
    /// </summary>
    public interface IServiceLocator : IDisposable
    {
        /// <summary>
        /// Loads the specified module by name.
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        void Load(string moduleName);

        /// <summary>
        /// Loads the specified modules by name.
        /// </summary>
        /// <param name="moduleNames">The module names.</param>
        void Load(params string[] moduleNames);

        /// <summary>
        /// Loads the specified configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        void Load(IDependencyConfiguration configuration);

        /// <summary>
        /// Registers service to implementation.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        void Register<TService, TImplementation>(); //where TImplementation : TService; NOTE: It can't be mocked because of System.Reflection.Emit bug

        /// <summary>
        /// Registers service to implementation in specified scope.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="scope">The scope.</param>
        void Register<TService, TImplementation>(IScope scope); //where TImplementation : TService; NOTE: It can't be mocked because of System.Reflection.Emit bug

        /// <summary>
        /// Registers service to implementation.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="implementation">The implementation.</param>
        void Register(Type service, Type implementation);

        /// <summary>
        /// Registers service to implementation in specified scope.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="implementation">The implementation.</param>
        /// <param name="scope">The scope.</param>
        void Register(Type service, Type implementation, IScope scope);

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
        /// Resolves the service with specified dependency.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="name">The dependency name.</param>
        /// <param name="value">The value.</param>
        /// <returns>Requested service.</returns>
        TService ResolveWith<TService>(string name, object value);

        /// <summary>
        /// Resolves the service with specified dependency.
        /// </summary>
        /// <param name="type">The type of the service.</param>
        /// <param name="name">The dependency name.</param>
        /// <param name="value">The value.</param>
        /// <returns>Requested service.</returns>
        object ResolveWith(Type type, string name, object value);

        /// <summary>
        /// Gets the scope factory.
        /// </summary>
        /// <value>The scope factory.</value>
        IScopeFactory Scopes { get; }

        /// <summary>
        /// Releases the specified object.
        /// </summary>
        /// <param name="releasable">The releasable object.</param>
        void Release(object releasable);
    }
}