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

using Arc.Domain.Identity;
using Arc.Infrastructure.Dependencies;

namespace Arc.Infrastructure.Data
{
    /// <summary>
    /// Active record pattern extensions for entities.
    /// </summary>
    public static class ActiveRecordExtensions
    {
        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="saveable">The saveable.</param>
        public static void Save(this ISaveable saveable)
        {
            Repository.Save(saveable);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="deletable">The deletable.</param>
        public static void Delete(this IDeletable deletable)
        {
            Repository.Delete(deletable);
        }

        private static IRepository Repository
        {
            get { return ServiceLocator.Resolve<IRepository>(); }
        }
    }
}