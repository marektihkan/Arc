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
using Arc.Infrastructure.Dependencies.Registration;

namespace Arc.Infrastructure.Dependencies
{
    /// <summary>
    /// Finds requested services.
    /// </summary>
    public interface IServiceLocator : IDisposable
    {
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
        void Load(IServiceLocatorModule<IServiceLocator> configuration);

        /// <summary>
        /// Registers the specified bindings.
        /// </summary>
        /// <param name="registrations">The registrations.</param>
        void Register(params IRegistration[] registrations);
    }
}