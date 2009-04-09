namespace Arc.Infrastructure.Dependencies.Registration
{
    public enum ServiceLifeStyle
    {
        Transient,
        OnePerRequest,
        OnePerThread,
        OnePerRequestOrThread,
        Singleton
    }
}