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
}