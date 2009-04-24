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
using Arc.Infrastructure.Configuration.Dependencies;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Utilities;

namespace Arc.Infrastructure.Configuration.Syntax
{
    /// <summary>
    /// ServiceLocator for service locator provider.
    /// </summary>
    public class ServiceLocatorProviderConfiguration : IServiceLocatorProviderConfiguration, IServiceLocatorConfiguration
    {
        private IServiceLocator _locator;


        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <param name="providerFullName">Full name of the provider.</param>
        /// <returns></returns>
        public IServiceLocatorConfiguration ProviderTo(string providerFullName)
        {
            return ProviderTo(ResolveProvider<IServiceLocator>.Named(providerFullName));
        }

        /// <summary>
        /// Sets provider to specified value.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public IServiceLocatorConfiguration ProviderTo(IServiceLocator provider)
        {
            _locator = provider;
            Infrastructure.Dependencies.ServiceLocator.InnerServiceLocator = _locator;
            return this;
        }

        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <typeparam name="TServiceLocator">The type of the service locator.</typeparam>
        /// <returns></returns>
        public IServiceLocatorConfiguration ProviderTo<TServiceLocator>() where TServiceLocator : IServiceLocator
        {
            return ProviderTo(typeof(TServiceLocator));
        }

        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <param name="provider">The provider type.</param>
        /// <returns></returns>
        public IServiceLocatorConfiguration ProviderTo(Type provider)
        {
            return ProviderTo(ResolveProvider<IServiceLocator>.WithRealType(provider));
        }

        /// <summary>
        /// Imports module to service locator.
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        /// <returns></returns>
        public IServiceLocatorConfiguration With(string moduleName)
        {
            if (!string.IsNullOrEmpty(moduleName))
                Infrastructure.Dependencies.ServiceLocator.Load(moduleName);
            return this;
        }

        /// <summary>
        /// Imports module to service locator.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <returns></returns>
        public IServiceLocatorConfiguration With(IServiceLocatorModule<IServiceLocator> module)
        {
            if (module != null)
                Infrastructure.Dependencies.ServiceLocator.Load(module);
            return this;
        }

        /// <summary>
        /// Imports module to service locator.
        /// </summary>
        /// <typeparam name="TConfiguration">The type of the configuration.</typeparam>
        /// <returns></returns>
        public IServiceLocatorConfiguration With<TConfiguration>() where TConfiguration : IServiceLocatorModule<IServiceLocator>
        {
            var configuration = ResolveProvider<IServiceLocatorModule<IServiceLocator>>.WithRealType(typeof(TConfiguration));
            configuration.Configure(ServiceLocator);
            return this;
        }

        /// <summary>
        /// Imports convention to service locator.
        /// </summary>
        /// <param name="convention">The convention.</param>
        /// <returns></returns>
        public IServiceLocatorConfiguration With(IConvention<IServiceLocator> convention)
        {
            if (convention != null)
                convention.Apply(_locator);
            return this;
        }

        /// <summary>
        /// Gets the service locator.
        /// </summary>
        /// <value>The service locator.</value>
        public IServiceLocator ServiceLocator
        {
            get { return _locator; }
        }
    }
}