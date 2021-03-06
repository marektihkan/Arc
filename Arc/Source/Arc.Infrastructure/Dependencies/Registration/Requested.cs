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
    /// DSL for registering services to service locator.
    /// </summary>
    public static class Requested
    {
        /// <summary>
        /// Registers service interface to service locator.
        /// </summary>
        /// <typeparam name="TService">The type of the service interface.</typeparam>
        /// <returns></returns>
        public static IServiceBindingSyntax Service<TService>( )
        {
            return new RegistrationImpl(typeof(TService));
        }

        /// <summary>
        /// Registers service interface to service locator.
        /// </summary>
        /// <param name="type">The service interface type.</param>
        /// <returns></returns>
        public static IServiceBindingSyntax Service(Type type)
        {
            return new RegistrationImpl(type);
        }
    }
}