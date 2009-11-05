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
using Arc.Domain.Specifications;
using Arc.Infrastructure.Data.NHibernate.FluentCriteria;
using NHibernate;
using NHibernate.Criterion;

namespace Arc.Infrastructure.Data.NHibernate
{
    /// <summary>
    /// Repository.
    /// </summary>
    public class Repository : IRepository
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
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="identity">The identity.</param>
        /// <returns>
        /// Entity which matches to specified identity.
        /// </returns>
        public T GetEntityById<T>(object identity) where T : class
        {
            return Session.Get<T>(identity);
        }

        /// <summary>
        /// Gets the entity by criteria.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns>
        /// Entity which matches to specified criteria.
        /// </returns>
        public T GetEntityBy<T>(ICriteria criteria) where T : class 
        {
            return (criteria == null) ? null : criteria.UniqueResult<T>();
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <returns>List of all entities of specified type.</returns>
        public IList<T> GetAllEntities<T>() where T : class
        {
            return CreateCriteria<T>().List<T>();
        }

        /// <summary>
        /// Gets the entities by criteria.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns>
        /// List of entities which matches to specified criteria.
        /// </returns>
        public IList<T> GetEntitiesBy<T>(ICriteria criteria) where T : class
        {
            return (criteria == null) ? new List<T>() : criteria.List<T>();
        }

        /// <summary>
        /// Gets the entity by specification.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="specification">The specification.</param>
        /// <returns>Entity which match to specification.</returns>
        public T GetEntityBy<T>(ISpecification<T> specification) where T : class 
        {
            var criteria = Criteria.For<T>().With(specification);
            return GetEntityBy<T>(criteria);
        }

        /// <summary>
        /// Gets the entities by specification.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="specification">The specification.</param>
        /// <returns>
        /// List of entities which match to specification.
        /// </returns>
        public IList<T> GetEntitiesBy<T>(ISpecification<T> specification) where T : class 
        {
            var criteria = Criteria.For<T>().With(specification);
            return GetEntitiesBy<T>(criteria);
        }

        /// <summary>
        /// Gets the entity by criteria.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Entity which match to criteria.</returns>
        public T GetEntityBy<T>(DetachedCriteria criteria) where T : class 
        {
            var executableCriteria = criteria.GetExecutableCriteria(Session);
            return GetEntityBy<T>(executableCriteria);
        }

        /// <summary>
        /// Gets the entities by criteria.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Entities which match to criteria.</returns>
        public IList<T> GetEntitiesBy<T>(DetachedCriteria criteria) where T : class 
        {
            var executableCriteria = criteria.GetExecutableCriteria(Session);
            return GetEntitiesBy<T>(executableCriteria);
        }

        /// <summary>
        /// Creates the criteria.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <returns>Criteria for specified entity type.</returns>
        public ICriteria CreateCriteria<T>() where T : class
        {
            return Session.CreateCriteria(typeof(T));
        }

        /// <summary>
        /// Counts results of the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Count of results.</returns>
        public long Count(DetachedCriteria criteria)
        {
            return Count(criteria.GetExecutableCriteria(Session));
        }

        /// <summary>
        /// Counts results of the specified specification.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="specification">The specification.</param>
        /// <returns>Count of results.</returns>
        public long Count<T>(ISpecification<T> specification) where T : class
        {
            var criteria = Criteria.For<T>().With(specification);
            return Count(criteria);
        }

        /// <summary>
        /// Counts results of the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Count of results.</returns>
        public long Count(ICriteria criteria)
        {
            criteria.SetProjection(Projections.RowCount());
            object count = criteria.UniqueResult();
            return Convert.ToInt64(count);
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="savable">The savable entity.</param>
        /// <returns>Saved entity.</returns>
        public T Save<T>(T savable) 
        {
            if (savable == null)
                return default(T);

            var session = Session;

            session.SaveOrUpdate(savable);
            session.Flush();
            
            return savable;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <typeparam name="T">Type of entity.</typeparam>
        /// <param name="deletable">The deletable entity.</param>
        public void Delete<T>(T deletable)  
        {
            if (deletable == null)
                return;

            var session = Session;

            session.Delete(deletable);
            session.Flush();
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

    /// <summary>
    /// Repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class Repository<TEntity> : Repository, INHibernateRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public Repository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        /// <summary>
        /// Gets the entity by identity.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <returns>
        /// Entity which matches to specified identity.
        /// </returns>
        public TEntity GetEntityById(object identity)
        {
            return GetEntityById<TEntity>(identity);
        }

        /// <summary>
        /// Gets the entity by criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>
        /// Entity which matches to specified criteria.
        /// </returns>
        public TEntity GetEntityBy(ICriteria criteria)
        {
            return GetEntityBy<TEntity>(criteria);
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>List of all entities.</returns>
        public IList<TEntity> GetAllEntities()
        {
            return GetAllEntities<TEntity>();
        }

        /// <summary>
        /// Gets the entities by criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>
        /// List of entities which matches to specified criteria.
        /// </returns>
        public IList<TEntity> GetEntitiesBy(ICriteria criteria)
        {
            return GetEntitiesBy<TEntity>(criteria);
        }

        /// <summary>
        /// Creates the criteria.
        /// </summary>
        /// <returns>Criteria for specified entity type.</returns>
        public ICriteria CreateCriteria()
        {
            return CreateCriteria<TEntity>();
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="savable">The savable entity.</param>
        /// <returns>Saved entity.</returns>
        public TEntity Save(TEntity savable)
        {
            return Save<TEntity>(savable);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="deletable">The deletable entity.</param>
        public void Delete(TEntity deletable)
        {
            Delete<TEntity>(deletable);
        }
    }
}