namespace Arc.Infrastructure.Dependencies.Registration
{
    public interface IServiceLifeStyleSyntax
    {
        IRegistration IsTransient();
        IRegistration IsOnePerRequest();
        IRegistration IsOnePerThread();
        IRegistration IsSingelton();
        IRegistration Is(ServiceLifeStyle lifeStyle);
    }
}