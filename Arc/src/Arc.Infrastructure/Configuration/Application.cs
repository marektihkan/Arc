using System;
using System.Linq;
using Arc.Domain.Dsl;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Utilities;

namespace Arc.Infrastructure.Configuration
{
    public class Application
    {
        public Application(IServiceLocator serviceLocator)
        {
            ServiceLocator.InnerServiceLocator = serviceLocator;
        }

        public static Application ServiceLocatorIs<TServiceLocator>() where TServiceLocator : IServiceLocator
        {
            return ServiceLocatorIs(typeof(TServiceLocator));
        }

        public static Application ServiceLocatorIs(Type type)
        {
            return ServiceLocatorIs(ResolveProvider<IServiceLocator>.WithRealType(type));
        }

        public static Application ServiceLocatorIs(IServiceLocator serviceLocator)
        {
            return new Application(serviceLocator);
        }

        public Application Load(params IConfiguration<IServiceLocator>[] configurations)
        {
            configurations
                .Where(configuration => configuration != null)
                .Each(configuration => configuration.Load(ServiceLocator.InnerServiceLocator));
            return this;
        }

        public Application Apply(params IConvention<IServiceLocator>[] conventions)
        {
            conventions
                .Where(convention => convention != null)
                .Each(convention => convention.Apply(ServiceLocator.InnerServiceLocator));
            return this;
        }
    }
}