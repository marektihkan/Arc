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

using NHibernate;

namespace Arc.Infrastructure.Data.NHibernate
{
    /// <summary>
    /// Configuration for NHibernate.
    /// </summary>
    public interface INHibernateConfiguration
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>The configiuration.</value>
        global::NHibernate.Cfg.Configuration Config { get; set; }

        /// <summary>
        /// Builds the session factory.
        /// </summary>
        /// <returns></returns>
        ISessionFactory BuildSessionFactory();
    }
}