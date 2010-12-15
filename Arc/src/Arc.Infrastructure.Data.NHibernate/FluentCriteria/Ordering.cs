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
using MemberFinder=Arc.Infrastructure.Data.NHibernate.Specifications.MemberFinder;

namespace Arc.Infrastructure.Data.NHibernate.FluentCriteria
{
    /// <summary>
    /// Criteria ordering.
    /// </summary>
    public class Ordering
    {
        /// <summary>
        /// Creates ascending ordering with specified property.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="property">The property.</param>
        /// <returns></returns>
        public static Order Ascending<T>(Expression<Func<T, object>> property)
        {
            return Convert(property, true);
        }

        /// <summary>
        /// Creates descending ordering with specified property.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="property">The property.</param>
        /// <returns></returns>
        public static Order Descending<T>(Expression<Func<T, object>> property)
        {
            return Convert(property, false);
        }

        private static Order Convert<T>(Expression<Func<T, object>> expression, bool isAscending)
        {
            var member = MemberFinder.FindFromExpression(expression.Body);
            return string.IsNullOrEmpty(member) ? null : new Order(member, isAscending);
        }
    }
}