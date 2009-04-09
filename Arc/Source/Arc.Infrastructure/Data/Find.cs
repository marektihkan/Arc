using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Arc.Domain.Specifications;
using Arc.Infrastructure.Dependencies;

namespace Arc.Infrastructure.Data
{
    /// <summary>
    /// Finds entites from repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public static class Find<TEntity> where TEntity : class 
    {
        private static IRepository<TEntity> Repository
        {
            get { return ServiceLocator.Resolve<IRepository<TEntity>>(); }
        }

        /// <summary>
        /// Finds entity by the identity.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <returns></returns>
        public static TEntity ByIdentity(object identity)
        {
            return Repository.GetEntityById(identity);
        }

        /// <summary>
        /// Finds entity by the specified specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns></returns>
        public static TEntity By(ISpecification<TEntity> specification)
        {
            return Repository.GetEntityBy(specification);
        }

        /// <summary>
        /// Finds entity by the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public static TEntity By(Expression<Func<TEntity, bool>> predicate)
        {
            return Repository.GetEntityBy(new Specification<TEntity>(predicate));
        }

        /// <summary>
        /// Finds all entities.
        /// </summary>
        /// <returns></returns>
        public static IList<TEntity> All()
        {
            return Repository.GetAllEntities();
        }

        /// <summary>
        /// Finds all entities by specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns></returns>
        public static IList<TEntity> AllBy(ISpecification<TEntity> specification)
        {
            return Repository.GetEntitiesBy(specification);
        }

        /// <summary>
        /// Finds all entities by predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public static IList<TEntity> AllBy(Expression<Func<TEntity, bool>> predicate)
        {
            return Repository.GetEntitiesBy(new Specification<TEntity>(predicate));
        }
    }
}