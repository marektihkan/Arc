using System.Web;
using Arc.Infrastructure.Dependencies.Registration;
using Ninject.Core.Behavior;

namespace Arc.Infrastructure.Dependencies.Ninject.Registration
{
    internal static class LifeStyleFactory
    {
        public static IBehavior Create(ServiceLifeStyle lifeStyle)
        {
            switch (lifeStyle)
            {
                case ServiceLifeStyle.Transient:
                    return new TransientBehavior();
                case ServiceLifeStyle.Singleton:
                    return new SingletonBehavior();
                case ServiceLifeStyle.OnePerThread:
                    return new OnePerThreadBehavior();
                case ServiceLifeStyle.OnePerRequest:
                    return new OnePerRequestBehavior();
                case ServiceLifeStyle.OnePerRequestOrThread:
                    return (HttpContext.Current != null) ? (IBehavior) new OnePerRequestBehavior() : new OnePerThreadBehavior();
                default:
                    return new TransientBehavior();
            }           
        }
    }
}