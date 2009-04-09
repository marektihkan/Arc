namespace Arc.Infrastructure.Dependencies.Registration
{
    /// <summary>
    /// Configuration syntax for setting service life style.
    /// </summary>
    public interface IServiceLifeStyleSyntax
    {
        /// <summary>
        /// Life style is transient.
        /// </summary>
        /// <returns></returns>
        IRegistration IsTransient();

        /// <summary>
        /// Life style is one per web request.
        /// </summary>
        /// <returns></returns>
        IRegistration IsOnePerRequest();

        /// <summary>
        /// Life style is one per thread.
        /// </summary>
        /// <returns></returns>
        IRegistration IsOnePerThread();

        /// <summary>
        /// Life style is singleton.
        /// </summary>
        /// <returns></returns>
        IRegistration IsSingelton();

        /// <summary>
        /// Life style is one per web request (if web context exists) or thread.
        /// </summary>
        /// <returns></returns>
        IRegistration IsOnePerRequestOrThread();

        /// <summary>
        /// Life style is spesified style.
        /// </summary>
        /// <param name="lifeStyle">The life style.</param>
        /// <returns></returns>
        IRegistration Is(ServiceLifeStyle lifeStyle);
    }
}