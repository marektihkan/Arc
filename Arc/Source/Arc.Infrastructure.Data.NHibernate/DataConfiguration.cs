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
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using Arc.Infrastructure.Registry;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Event;

namespace Arc.Infrastructure.Data.NHibernate
{
    /// <summary>
    /// Configuration for data access with NHibernate.
    /// </summary>
    public class DataConfiguration : IServiceLocatorModule<IServiceLocator>
    {
        private DataConfiguration()
        {
        }

        private DataConfiguration(FluentConfiguration configuration)
        {
            NHConfiguration = configuration;
        }

        
        /// <summary>
        /// Creates default data configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static DataConfiguration Default(FluentConfiguration configuration)
        {
            return new DataConfiguration(configuration);
        }

        /// <summary>
        /// Creates data configuration with validation listeners.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static DataConfiguration WithValidation(FluentConfiguration configuration)
        {
            configuration.ExposeConfiguration(x =>
                                                  {
                                                      x.SetListener(ListenerType.PreInsert, new PreInsertEventListener());
                                                      x.SetListener(ListenerType.PreUpdate, new PreUpdateEventListener());
                                                  });
            return Default(configuration);
        }


        /// <summary>
        /// Gets or sets the NHibernate configuration.
        /// </summary>
        /// <value>The NHibernate configuration.</value>
        public FluentConfiguration NHConfiguration { get; private set; }

        /// <summary>
        /// Configures the specified service locator.
        /// </summary>
        /// <param name="serviceLocator">The service locator.</param>
        public void Configure(IServiceLocator serviceLocator)
        {
            ConfigureNHibernate(serviceLocator);

            serviceLocator.Register(
                Requested.Service<IRegistry>().IsImplementedBy<HybridRegistry>(),
                     
                Requested.Service<ISessionFactory>()
                    .IsConstructedBy(x => x.Resolve<INHibernateConfiguration>().BuildSessionFactory())
                    .LifeStyle.IsSingelton(),

                Requested.Service<IUnitOfWorkFactory>()
                    .IsImplementedBy<UnitOfWorkFactory>()
                    .LifeStyle.IsSingelton(),

                Requested.Service<IUnitOfWork>()
                    .IsConstructedBy(x => x.Resolve<IUnitOfWorkFactory>().Create()),

                Requested.Service(typeof(IRepository<>))
                    .IsImplementedBy(typeof(Repository<>)),

                Requested.Service(typeof(INHibernateRepository<>))
                    .IsImplementedBy(typeof(Repository<>))
            );

            
        }

        private void ConfigureNHibernate(IServiceLocator locator)
        {
            if (NHConfiguration != null)
            {
                locator.Register(
                    Requested.Service<INHibernateConfiguration>()
                        .IsConstructedBy(x => new NHibernateConfiguration(NHConfiguration))
                        .LifeStyle.IsSingelton());
            }
            else
            {
                locator.Register(
                    Requested.Service<INHibernateConfiguration>()
                        .IsImplementedBy<NHibernateConfiguration>()
                        .LifeStyle.IsSingelton());
            }
        }
    }
}