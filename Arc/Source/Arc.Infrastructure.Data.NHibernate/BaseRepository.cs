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

namespace Arc.Infrastructure.Data.NHibernate
{
    /// <summary>
    /// Base repository for NHibernate aware repositories.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class BaseRepository<TEntity> : BaseGenericRepository<TEntity, INHibernateRepository<TEntity>> where TEntity : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        protected BaseRepository(INHibernateRepository<TEntity> repository) : base(repository)
        {
        }
    }
}