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
using NHibernate.Criterion;

namespace Arc.Infrastructure.Data.NHibernate.FluentCriteria
{
    /// <summary>
    /// Criteria extensions for ordering.
    /// </summary>
    public static class CriteriaOrderingExtensions
    {
        /// <summary>
        /// Adds ascending ordering.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static DetachedCriteria AscendingOrdering<T>(this DetachedCriteria criteria, Expression<Func<T, object>> expression)
        {
            criteria.AddOrder(Ordering.Ascending(expression));
            return criteria;
        }

        /// <summary>
        /// Adds descending ordering.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static DetachedCriteria DescendingOrdering<T>(this DetachedCriteria criteria, Expression<Func<T, object>> expression)
        {
            criteria.AddOrder(Ordering.Descending(expression));
            return criteria;
        }
    }
}