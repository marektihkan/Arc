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
        T Save<T>(T savable) where T : class;

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="deletable">The deletable entity.</param>
        void Delete<T>(T deletable) where T : class;

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

    
    /// <summary>
    /// Repository for concrete type of entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IRepository<TEntity> : IRepository where TEntity : class
    {
        /// <summary>
        /// Gets the entity by identity.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <returns>Entity which matches to specified identity.</returns>
        TEntity GetEntityById(object identity);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>List of all entities.</returns>
        IList<TEntity> GetAllEntities();

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="savable">The savable entity.</param>
        /// <returns>Saved entity.</returns>
        TEntity Save(TEntity savable);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="deletable">The deletable entity.</param>
        void Delete(TEntity deletable);
    }
}