using Arc.Infrastructure.Data;
using Arc.Infrastructure.Registry;
using StructureMap;
using StructureMap.Attributes;

namespace Arc.Infrastructure.Dependencies.StructureMap
{
    public class DataConfiguration : IServiceLocatorModule<IContainer>
    {
        public void Configure(IContainer container)
        {
            container.Configure(x =>
                x.ForRequestedType<IRegistry>()
                    .TheDefaultIsConcreteType<WebRequestRegistry>());

            container.Configure(x =>
                x.BuildInstancesOf<IUnitOfWork>()
                    .AddInstances(y => y.ConstructedBy(context => context.GetInstance<IUnitOfWorkFactory>().Create()))
                    .CacheBy(InstanceScope.HttpContext));

//            container.Configure(x =>
//                x.ForRequestedType<IUnitOfWorkFactory>()
//                    .AddConcreteType<UnitOfWorkFactory>()
//                    .CacheBy(InstanceScope.Singleton));
//
//            container.Configure(x =>
//                x.ForRequestedType(typeof(IRepository<>))
//                    .TheDefaultIsConcreteType(typeof(Repository<>)));


            //            Bind<NHibernate.Cfg.ServiceLocator>()
            //                .ToMethod(x =>
            //                {
            //                    var configuration = new NHibernate.Cfg.ServiceLocator();
            //                    configuration.SetListener(ListenerType.PreInsert, new PreInsertEventListener());
            //                    configuration.SetListener(ListenerType.PreUpdate, new PreUpdateEventListener());
            //                    return configuration.Configure();
            //                })
            //                .Using<SingletonBehavior>();
            //
            //
            //            Bind<ISessionFactory>()
            //                .ToMethod(x => Kernel.Get<NHibernate.Cfg.ServiceLocator>().BuildSessionFactory())
            //                .Using<SingletonBehavior>();
            //
        }
    }
}