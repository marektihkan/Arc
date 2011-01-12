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
using System.Collections.Generic;
using System.Linq;
using Arc.Domain.Specifications;
using NHibernate;
using NHibernate.Linq;

namespace Arc.Infrastructure.Data.NHibernate
{
    /// <summary>
    /// Repository.
    /// </summary>
    public class Repository : INHibernateRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        /// <summary>
        /// Gets the NHibernate session.
        /// </summary>
        /// <value>The session.</value>
        public ISession Session
        {
            get { return (ISession) _unitOfWork.Session; }
        }

        /// <summary>
        /// Gets the entity by identity.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity.</typeparam>
        /// <param name="identity">The identity.</param>
        /// <returns>
        /// Entity which matches to specified identity.
        /// </returns>
        public TEntity GetEntityById<TEntity>(object identity) where TEntity : class
        {
            return Session.Get<TEntity>(identity);
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity.</typeparam>
        /// <returns>List of all entities of specified type.</returns>
        public IList<TEntity> GetAllEntities<TEntity>() where TEntity : class
        {
            return QueryOver<TEntity>().List<TEntity>();
        }

        /// <summary>
        /// Gets the entity by specification.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity.</typeparam>
        /// <param name="specification">The specification.</param>
        /// <returns>Entity which match to specification.</returns>
        public TEntity GetEntityBy<TEntity>(ISpecification<TEntity> specification) where TEntity : class 
        {
            return QueryOver<TEntity>().Where(specification.Predicate).SingleOrDefault();
        }

        /// <summary>
        /// Gets the entities by specification.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity.</typeparam>
        /// <param name="specification">The specification.</param>
        /// <returns>
        /// List of entities which match to specification.
        /// </returns>
        public IList<TEntity> GetEntitiesBy<TEntity>(ISpecification<TEntity> specification) where TEntity : class 
        {
            return QueryOver<TEntity>().Where(specification.Predicate).List();
        }

        public IQueryable<TEntity> Query<TEntity>()
        {
            return Session.Query<TEntity>();
        }

        /// <summary>
        /// Counts results of the specified specification.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="specification">The specification.</param>
        /// <returns>Count of results.</returns>
        public long Count<TEntity>(ISpecification<TEntity> specification) where TEntity : class
        {
            return QueryOver<TEntity>().Where(specification.Predicate).RowCountInt64();
        }

        /// <summary>
        /// Entity query.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public IQueryOver<TEntity, TEntity> QueryOver<TEntity>() where TEntity : class
        {
            return Session.QueryOver<TEntity>();
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity.</typeparam>
        /// <param name="savable">The savable entity.</param>
        /// <returns>Saved entity.</returns>
        public TEntity Save<TEntity>(TEntity savable) 
        {
            if (savable == null)
                return default(TEntity);

            Session.SaveOrUpdate(savable);
            return savable;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity.</typeparam>
        /// <param name="deletable">The deletable entity.</param>
        public void Delete<TEntity>(TEntity deletable)  
        {
            if (deletable == null)
                return;

            Session.Delete(deletable);
        }

        /// <summary>
        /// Clears unit of work.
        /// </summary>
        public void Clear()
        {
            Session.Clear();
        }

        /// <summary>
        /// Evicts the specified evitable.
        /// </summary>
        /// <param name="evitable">The evitable.</param>
        public void Evict(object evitable)
        {
            Session.Evict(evitable);
        }
    }
}