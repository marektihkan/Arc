using Arc.Infrastructure.Data;
using Arc.Infrastructure.Dependencies.CastleWindsor.Extensions;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Arc.Infrastructure.Dependencies.CastleWindsor
{
    public class DataConfiguration : IServiceLocatorModule<IWindsorContainer>
    {
        public void Configure(IWindsorContainer container)
        {
            container.Register(
                Component.For<IUnitOfWork>()
                    .FactoryMethod(context => context.Resolve<IUnitOfWorkFactory>().Create())
                    .LifeStyle.PerWebRequest
                );
        }
    }
}