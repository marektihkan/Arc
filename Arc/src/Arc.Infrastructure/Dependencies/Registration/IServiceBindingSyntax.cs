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

namespace Arc.Infrastructure.Dependencies.Registration
{
    /// <summary>
    /// Configuration syntax for binding service to implementation.
    /// </summary>
    public interface IServiceBindingSyntax
    {
        /// <summary>
        /// Service is implemented by specified type.
        /// </summary>
        /// <typeparam name="TImplementation">Type of implementation.</typeparam>
        /// <returns></returns>
        IRegistration IsImplementedBy<TImplementation>();

        /// <summary>
        /// Service is implemented by specified type.
        /// </summary>
        /// <param name="type">The type of implementation.</param>
        /// <returns></returns>
        IRegistration IsImplementedBy(Type type);

        /// <summary>
        /// Service is constructed by specified factory method.
        /// </summary>
        /// <param name="factoryMethod">The factory method.</param>
        /// <returns></returns>
        IRegistration IsConstructedBy(Func<IServiceLocator, object> factoryMethod);
    }
}