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