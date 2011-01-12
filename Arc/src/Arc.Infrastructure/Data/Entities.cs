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

using System.Linq;
using Arc.Infrastructure.Dependencies;

namespace Arc.Infrastructure.Data
{
    /// <summary>
    /// Context for entities.
    /// </summary>
    public class Entities
    {
        /// <summary>
        /// Gets all entities of specified type.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public static IQueryable<TEntity> All<TEntity>()
        {
            return ServiceLocator.Resolve<IRepository>().Query<TEntity>();
        }
    }
}