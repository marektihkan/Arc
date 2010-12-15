using System;
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
            foreach (var configuration in configurations)
            {
                if (configuration != null)
                    configuration.Load(ServiceLocator.InnerServiceLocator);    
            }
            return this;
        }
       
        public Application Apply(params IConvention<IServiceLocator>[] conventions)
        {
            foreach (var convention in conventions)
            {
                if (convention != null)
                    convention.Apply(ServiceLocator.InnerServiceLocator);   
            }
            return this;
        }

    }
}