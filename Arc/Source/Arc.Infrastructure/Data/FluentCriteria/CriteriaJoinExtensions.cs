#region License

// Copyright (c) 2008-2009 Marek Tihkan (marektihkan@gmail.com)
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//     * Neither the name of Marek Tihkan nor the names of its
//     contributors may be used to endorse or promote products derived from this
//     software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
// THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;
using System.Linq.Expressions;
using Arc.Infrastructure.Data.NHibernate.Specifications;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace Arc.Infrastructure.Data.FluentCriteria
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