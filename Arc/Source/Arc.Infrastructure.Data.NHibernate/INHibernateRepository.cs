using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace Arc.Infrastructure.Data.NHibernate
{
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