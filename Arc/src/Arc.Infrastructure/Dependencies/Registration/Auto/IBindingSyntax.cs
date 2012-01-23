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

namespace Arc.Infrastructure.Dependencies.Registration.Auto
{
    /// <summary>
    /// Binding syntax.
    /// </summary>
    public interface IBindingSyntax
    {
        /// <summary>
        /// Binds to self.
        /// </summary>
        /// <returns>ServiceLocator.</returns>
        AutoRegistration BindToSelf();

        /// <summary>
        /// Binds to first interface.
        /// </summary>
        /// <returns>ServiceLocator.</returns>
        AutoRegistration BindToFirstInterface();

        /// <summary>
        /// Binds to the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria. (interface)</param>
        /// <returns>ServiceLocator.</returns>
        AutoRegistration BindToInterface(Func<Type, bool> criteria);

        /// <summary>
        /// Binds to the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria. (interface, realType)</param>
        /// <returns></returns>
        AutoRegistration BindToInterface(Func<Type, Type, bool> criteria);

		/// <summary>
		/// Binds all to the specified criteria.
		/// </summary>
		/// <param name="criteria">The criteria. (interface)</param>
		/// <returns></returns>
		AutoRegistration BindToInterfaces(Func<Type, bool> criteria);
    }
}