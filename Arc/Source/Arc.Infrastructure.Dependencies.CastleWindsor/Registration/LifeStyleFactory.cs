using System.Web;
using Arc.Infrastructure.Dependencies.Registration;
using Castle.Core;

namespace Arc.Infrastructure.Dependencies.CastleWindsor.Registration
{
    internal static class LifeStyleFactory
    {
        public static LifestyleType Create(ServiceLifeStyle lifeStyle)
        {
            switch (lifeStyle)
            {
                case ServiceLifeStyle.Transient:
                    return LifestyleType.Transient;
                case ServiceLifeStyle.Singleton:
                    return LifestyleType.Singleton;
                case ServiceLifeStyle.OnePerThread:
                    return LifestyleType.Thread;
                case ServiceLifeStyle.OnePerRequest:
                    return LifestyleType.PerWebRequest;
                case ServiceLifeStyle.OnePerRequestOrThread:
                    return (HttpContext.Current != null) ? LifestyleType.PerWebRequest : LifestyleType.Thread;
                default:
                    return LifestyleType.Transient;
            }           
        }
    }
}