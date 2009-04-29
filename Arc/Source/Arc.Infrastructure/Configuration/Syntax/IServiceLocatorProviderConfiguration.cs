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
using Arc.Infrastructure.Dependencies;

namespace Arc.Infrastructure.Configuration.Syntax
{
    /// <summary>
    /// ServiceLocator for service locator provider.
    /// </summary>
    public interface IServiceLocatorProviderConfiguration
    {
        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <param name="providerFullName">Full name of the provider.</param>
        /// <returns></returns>
        IServiceLocatorConfiguration ProviderTo(string providerFullName);

        /// <summary>
        /// Sets provider to specified value.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        IServiceLocatorConfiguration ProviderTo(IServiceLocator provider);

        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <typeparam name="TServiceLocator">The type of the service locator.</typeparam>
        /// <returns></returns>
        IServiceLocatorConfiguration ProviderTo<TServiceLocator>() where TServiceLocator : IServiceLocator;

        /// <summary>
        /// Sets provider to specified type.
        /// </summary>
        /// <param name="provider">The provider type.</param>
        /// <returns></returns>
        IServiceLocatorConfiguration ProviderTo(Type provider);
    }
}