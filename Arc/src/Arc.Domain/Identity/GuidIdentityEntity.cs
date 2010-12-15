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
    /// GUID identity base for entities.
    /// </summary>
    public class GuidIdentityEntity : IEntity<Guid>, IVersioned
    {
        private Guid _id;
        private int _version;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuidIdentityEntity"/> class.
        /// </summary>
        public GuidIdentityEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuidIdentityEntity"/> class.
        /// </summary>
        /// <param name="identity">The identity.</param>
        public GuidIdentityEntity(Guid identity)
        {
            _id = identity;
        }


        /// <summary>
        /// Gets the entity's identity.
        /// </summary>
        /// <value>The identity.</value>
        public virtual Guid Id
        {
            get { return _id; }
            protected set { _id = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is transient.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is transient; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsTransient
        {
            get { return Id.Equals(Guid.Empty); }
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            var other = obj as IEntity<Guid>;
            return (other == null || IsTransient) ? false : Id.Equals(other.Id);
        }

        /// <summary>
        /// Gets the version number.
        /// </summary>
        /// <value>The version number.</value>
        public virtual int Version
        {
            get { return _version; }
            protected set { _version = value; }
        }
    }
}