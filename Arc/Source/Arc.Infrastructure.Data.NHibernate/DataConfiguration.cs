using Arc.Infrastructure.Data.NHibernate.Listeners;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using Arc.Infrastructure.Registry;
using NHibernate;
using NHibernate.Event;

namespace Arc.Infrastructure.Data.NHibernate
{
    public class DataConfiguration : IServiceLocatorModule<IServiceLocator>
    {
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

                Requested.Service(typeof(INHibernateRepository<>))
                    .IsImplementedBy(typeof(Repository<>))
            );
        }
    }
}