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

using NHibernate.Event;

namespace Arc.Infrastructure.Data.NHibernate.Listeners
{
    /// <summary>
    /// NHibernate pre update event lister for validation.
    /// </summary>
    public class PreUpdateEventListener : BaseValidationListener, IPreUpdateEventListener
    {
        /// <summary>
        /// Validates entity.
        /// </summary>
        /// <param name="event"></param>
        /// <returns>False; It should not be vetoed.</returns>
        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            Validate(@event.Entity, @event.Persister.EntityMetamodel.Type);
            return false;
        }
    }
}