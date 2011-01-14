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

using System.Collections.Generic;
using System.Linq;
using Arc.Domain.Specifications;

namespace Arc.Infrastructure.Data
{
    /// <summary>
    /// Specification extensions
    /// </summary>
    public static class SpecificationExtensions
    {
        /// <summary>
        /// Adds specification to the specified query.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="specification">The specification.</param>
        /// <returns></returns>
        public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> query, ISpecification<TEntity> specification)
        {
            return query.Where(specification.Predicate);
        }

        /// <summary>
        /// Adds specifiaction to the specified collection.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="specification">The specification.</param>
        /// <returns></returns>
        public static IEnumerable<TEntity> Where<TEntity>(this IEnumerable<TEntity> collection, ISpecification<TEntity> specification)
        {
            return collection.Where(specification.Predicate.Compile());
        }
    }
}