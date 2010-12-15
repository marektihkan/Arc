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
using System.Linq.Expressions;

namespace Arc.Domain.Specifications
{
    /// <summary>
    /// Domain specification
    /// </summary>
    /// <typeparam name="T">Type of entity.</typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Gets the predicate.
        /// </summary>
        /// <value>The predicate.</value>
        Expression<Func<T, bool>> Predicate { get; }

        /// <summary>
        /// Adds and operator to this and other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        ISpecification<T> And(ISpecification<T> other);

        /// <summary>
        /// Determines whether specification is satisfied by item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// 	<c>true</c> if the specification is satisfied by the specified item; otherwise, <c>false</c>.
        /// </returns>
        bool IsSatisfiedBy(T item);

        /// <summary>
        /// Adds not operator to specification.
        /// </summary>
        /// <returns></returns>
        ISpecification<T> Not();

        /// <summary>
        /// Adds or operator to this and other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        ISpecification<T> Or(ISpecification<T> other);
    }
}