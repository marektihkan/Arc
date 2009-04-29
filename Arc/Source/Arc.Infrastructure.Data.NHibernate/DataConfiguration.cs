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

using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using Arc.Infrastructure.Registry;
using NHibernate;

namespace Arc.Infrastructure.Data.NHibernate
{
    /// <summary>
    /// Configuration for data access with NHibernate.
    /// </summary>
    public class DataConfiguration : IServiceLocatorModule<IServiceLocator>
    {
        /// <summary>
        /// Configures the specified service locator.
        /// </summary>
        /// <param name="serviceLocator">The service locator.</param>
        public void Configure(IServiceLocator serviceLocator)
        {
            serviceLocator.Register(
                Requested.Service<IRegistry>().IsImplementedBy<HybridRegistry>(),

                Requested.Service<INHibernateConfiguration>()
                    .IsImplementedBy<NHibernateConfiguration>()
                    .LifeStyle.IsSingelton(),
                     
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
    }
}