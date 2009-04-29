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

using Arc.Infrastructure.Configuration.Dependencies;
using Arc.Infrastructure.Dependencies;

namespace Arc.Infrastructure.Configuration.Syntax
{
    /// <summary>
    /// Service locator configuration.
    /// </summary>
    public interface IServiceLocatorConfiguration
    {
        /// <summary>
        /// Imports module to service locator.
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        /// <returns></returns>
        IServiceLocatorConfiguration With(string moduleName);

        /// <summary>
        /// Imports module to service locator.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <returns></returns>
        IServiceLocatorConfiguration With(IServiceLocatorModule<IServiceLocator> module);

        /// <summary>
        /// Imports module to service locator.
        /// </summary>
        /// <typeparam name="TConfiguration">The type of the configuration.</typeparam>
        /// <returns></returns>
        IServiceLocatorConfiguration With<TConfiguration>() where TConfiguration : IServiceLocatorModule<IServiceLocator>;

        /// <summary>
        /// Imports convention to service locator.
        /// </summary>
        /// <param name="convention">The convention.</param>
        /// <returns></returns>
        IServiceLocatorConfiguration With(IConvention<IServiceLocator> convention);
    }
}