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
using NHibernate.SqlCommand;

namespace Arc.Infrastructure.Data.NHibernate.FluentCriteria
{
    /// <summary>
    /// Joining extensions for criteria.
    /// </summary>
    public static class CriteriaJoinExtensions
    {
        
        /// <summary>
        /// Adds join to the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <param name="alias">The alias.</param>
        /// <param name="joinType">Type of the join.</param>
        /// <returns>Criteria.</returns>
        public static DetachedCriteria Join(this DetachedCriteria criteria, Expression<Func<object>> alias, JoinType joinType)
        {
            var aliasContainer = Alias.Convert(alias);
            return criteria.CreateAlias(aliasContainer.AliasPath, aliasContainer.AliasName, joinType);
        }

        /// <summary>
        /// Adds inner join to the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <param name="alias">The alias.</param>
        /// <returns>Criteria.</returns>
        public static DetachedCriteria InnerJoin(this DetachedCriteria criteria, Expression<Func<object>> alias)
        {
            return criteria.Join(alias, JoinType.InnerJoin);
        }

        /// <summary>
        /// Adds left outer join to the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <param name="alias">The alias.</param>
        /// <returns>Criteria</returns>
        public static DetachedCriteria LeftJoin(this DetachedCriteria criteria, Expression<Func<object>> alias)
        {
            return criteria.Join(alias, JoinType.LeftOuterJoin);
        }

        /// <summary>
        /// Adds right outer join to the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <param name="alias">The alias.</param>
        /// <returns>Criteria</returns>
        public static DetachedCriteria RightJoin(this DetachedCriteria criteria, Expression<Func<object>> alias)
        {
            return criteria.Join(alias, JoinType.RightOuterJoin);
        }

        /// <summary>
        /// Adds full join to the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <param name="alias">The alias.</param>
        /// <returns>Criteria</returns>
        public static DetachedCriteria FullJoin(this DetachedCriteria criteria, Expression<Func<object>> alias)
        {
            return criteria.Join(alias, JoinType.FullJoin);
        }
    }
}