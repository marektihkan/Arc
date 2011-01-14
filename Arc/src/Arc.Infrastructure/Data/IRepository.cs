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
    /// Generic repository.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Gets the entity by identity.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="identity">The identity.</param>
        /// <returns>Entity which matches to specified identity.</returns>
        T GetEntityById<T>(object identity) where T : class;

        /// <summary>
        /// Gets the entity by specification.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="specification">The specification.</param>
        /// <returns>Entity which match to specification.</returns>
        T GetEntityBy<T>(ISpecification<T> specification) where T : class;

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <returns>List of all entities of specified type.</returns>
        IList<T> GetAllEntities<T>() where T : class;

        /// <summary>
        /// Gets the entities by specification.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="specification">The specification.</param>
        /// <returns>List of entities which match to specification.</returns>
        IList<T> GetEntitiesBy<T>(ISpecification<T> specification) where T : class;

        IQueryable<TEntity> Query<TEntity>();

        /// <summary>
        /// Counts results of the specified specification.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="specification">The specification.</param>
        /// <returns>Count of results.</returns>
        long Count<T>(ISpecification<T> specification) where T : class;

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="savable">The savable entity.</param>
        /// <returns>Saved entity.</returns>
        T Save<T>(T savable);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="deletable">The deletable entity.</param>
        void Delete<T>(T deletable);

        /// <summary>
        /// Clears unit of work.
        /// </summary>
        void Clear();

        /// <summary>
        /// Evicts the specified evitable.
        /// </summary>
        /// <param name="evitable">The evitable.</param>
        void Evict(object evitable);
    }
}