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