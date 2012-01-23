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

namespace Arc.Domain.Identity
{
    /// <summary>
    /// Marker interface for entities.
    /// </summary>
    /// <typeparam name="TIdentity">The type of the identity.</typeparam>
    public interface IEntity<TIdentity> : IEntity
    {
        /// <summary>
        /// Gets the entity's identity.
        /// </summary>
        /// <value>The identity.</value>
        TIdentity Id { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is transient.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is transient; otherwise, <c>false</c>.
        /// </value>
        bool IsTransient { get; }
    }

    /// <summary>
    /// Marker interface for entities.
    /// </summary>
    public interface IEntity
    {
		Type GetUnproxiedType();
    }
}