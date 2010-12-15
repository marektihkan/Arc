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
using Arc.Domain.Specifications;
using Arc.Infrastructure.Data.NHibernate.Specifications;
using NHibernate.Criterion;

namespace Arc.Infrastructure.Data.NHibernate.FluentCriteria
{
    /// <summary>
    /// Helper class for creating criteria.
    /// </summary>
    public static class Criteria
    {
        /// <summary>
        /// Creates criterion with specified type and criteria.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Criterion.</returns>
        public static ICriterion With<T>(Expression<Func<T, bool>> criteria)
        {
            return CriterionConverter.Convert(new Specification<T>(criteria));
        }

        /// <summary>
        /// Creates empty criteria for specified type.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <returns>Empty criteria.</returns>
        public static DetachedCriteria For<T>()
        {
            return DetachedCriteria.For<T>();
        }

        /// <summary>
        /// Creates empty criteria for specified type with alias.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="alias">The alias.</param>
        /// <returns>Empty criteria.</returns>
        public static DetachedCriteria For<T>(Expression<Func<object>> alias)
        {
            var aliasContainer = Alias.Convert(alias);
            return DetachedCriteria.For<T>(aliasContainer.AliasName);
        }
    }
}