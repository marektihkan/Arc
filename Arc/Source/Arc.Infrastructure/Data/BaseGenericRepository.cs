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

namespace Arc.Infrastructure.Data
{
    /// <summary>
    /// Base repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TRepository">The type of the repository.</typeparam>
    public abstract class BaseGenericRepository<TEntity, TRepository> where TRepository : IRepository<TEntity> where TEntity : class
    {
        private readonly TRepository _repository;


        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected BaseGenericRepository(TRepository repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Gets the inner repository.
        /// </summary>
        /// <value>The inner repository.</value>
        protected TRepository InnerRepository
        {
            get { return _repository; }
        }

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
        protected IUnitOfWork UnitOfWork
        {
            get { return InnerRepository.UnitOfWork; }
        }
    }
}