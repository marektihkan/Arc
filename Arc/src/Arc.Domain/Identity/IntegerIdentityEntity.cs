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
    /// Integer identity base for entities.
    /// </summary>
    public class IntegerIdentityEntity : IEntity<int>, IVersioned
    {
        private int _id;
        private int _version;
        private int _transientHashCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerIdentityEntity"/> class.
        /// </summary>
        public IntegerIdentityEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerIdentityEntity"/> class.
        /// </summary>
        /// <param name="identity">The identity.</param>
        public IntegerIdentityEntity(int identity)
        {
            _id = identity;
        }


        /// <summary>
        /// Gets the entity's identity.
        /// </summary>
        /// <value>The identity.</value>
        public virtual int Id
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
            get { return _id == 0; }
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

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        /// </exception>
        public override bool Equals(object obj)
        {
            return Equals(obj as IEntity<int>);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        /// </exception>
        public virtual bool Equals(IEntity<int> obj)
        {
            if (obj == null) return false;

            if (IsTransient) return ReferenceEquals(this, obj);

			var objType = obj.GetUnproxiedType();
			var type = GetUnproxiedType();

            return obj.Id == Id && objType == type;
        }

		public virtual Type GetUnproxiedType()
		{
			return GetType();
		}

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            if (!IsTransient) return Id;
            
            if (_transientHashCode == 0)
            {
                _transientHashCode = base.GetHashCode();
            }
            return _transientHashCode;
        }
    }
}