using Arc.Infrastructure.Dependencies.Registration;
using StructureMap.Attributes;

namespace Arc.Infrastructure.Dependencies.StructureMap.Registration
{
    public static class LifeStyleFactory
    {
        public static InstanceScope Create(ServiceLifeStyle lifeStyle)
        {
            switch (lifeStyle)
            {
                case ServiceLifeStyle.Transient:
                    return InstanceScope.PerRequest;
                case ServiceLifeStyle.Singleton:
                    return InstanceScope.Singleton;
                case ServiceLifeStyle.OnePerThread:
                    return InstanceScope.ThreadLocal;
                case ServiceLifeStyle.OnePerRequest:
                    return InstanceScope.HttpContext;
                case ServiceLifeStyle.OnePerRequestOrThread:
                    return InstanceScope.Hybrid;
                default:
                    return InstanceScope.PerRequest;
            }
        }
    }
}