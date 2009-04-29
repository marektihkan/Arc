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

using Arc.Infrastructure.Data.NHibernate.Listeners;
using NHibernate;
using NHibernate.Event;

namespace Arc.Infrastructure.Data.NHibernate
{
    /// <summary>
    /// Configuration for NHibernate.
    /// </summary>
    public class NHibernateConfiguration : INHibernateConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateConfiguration"/> class.
        /// </summary>
        public NHibernateConfiguration()
        {
            var configuration = new global::NHibernate.Cfg.Configuration();
            configuration.SetListener(ListenerType.PreInsert, new PreInsertEventListener());
            configuration.SetListener(ListenerType.PreUpdate, new PreUpdateEventListener());
            Config = configuration.Configure();
        }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>The configiuration.</value>
        public global::NHibernate.Cfg.Configuration Config { get; set; }

        /// <summary>
        /// Builds the session factory.
        /// </summary>
        /// <returns></returns>
        public ISessionFactory BuildSessionFactory( )
        {
            return Config.BuildSessionFactory();
        }
    }
}