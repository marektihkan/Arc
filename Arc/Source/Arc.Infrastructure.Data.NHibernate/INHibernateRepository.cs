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

using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace Arc.Infrastructure.Data.NHibernate
{
    /// <summary>
    /// Repository with NHibernate spesifics.
    /// </summary>
    public interface INHibernateRepository : IRepository
    {
        /// <summary>
        /// Gets the NHibernate session.
        /// </summary>
        /// <value>The session.</value>
        ISession Session { get; }

        /// <summary>
        /// Gets the entity by criteria.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Entity which matches to specified criteria.</returns>
        T GetEntityBy<T>(ICriteria criteria) where T : class;

        /// <summary>
        /// Gets the entity by criteria.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Entity which match to criteria.</returns>
        T GetEntityBy<T>(DetachedCriteria criteria) where T : class;

        /// <summary>
        /// Gets the entities by criteria.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns>List of entities which matches to specified criteria.</returns>
        IList<T> GetEntitiesBy<T>(ICriteria criteria) where T : class;

        /// <summary>
        /// Gets the entities by criteria.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Entities which match to criteria.</returns>
        IList<T> GetEntitiesBy<T>(DetachedCriteria criteria) where T : class;

        /// <summary>
        /// Creates the criteria.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <returns>Criteria for specified entity type.</returns>
        ICriteria CreateCriteria<T>() where T : class;

        /// <summary>
        /// Counts results of the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Count of results.</returns>
        long Count(DetachedCriteria criteria);

        /// <summary>
        /// Counts results of the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Count of results.</returns>
        long Count(ICriteria criteria);
    }

    /// <summary>
    /// Repository with NHibernate specifics.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface INHibernateRepository<TEntity> : INHibernateRepository, IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets the entity by criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Entity which matches to specified criteria.</returns>
        TEntity GetEntityBy(ICriteria criteria);

        /// <summary>
        /// Gets the entities by criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>List of entities which matches to specified criteria.</returns>
        IList<TEntity> GetEntitiesBy(ICriteria criteria);

        /// <summary>
        /// Creates the criteria.
        /// </summary>
        /// <returns>Criteria for specified entity type.</returns>
        ICriteria CreateCriteria();
    }
}