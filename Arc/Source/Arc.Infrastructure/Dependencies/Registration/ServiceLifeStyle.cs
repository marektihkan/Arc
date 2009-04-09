namespace Arc.Infrastructure.Dependencies.Registration
{
    /// <summary>
    /// Service life style.
    /// </summary>
    public enum ServiceLifeStyle
    {
        /// <summary>
        /// Transient.
        /// </summary>
        Transient,
        /// <summary>
        /// One per web request.
        /// </summary>
        OnePerRequest,
        /// <summary>
        /// One per thread.
        /// </summary>
        OnePerThread,
        /// <summary>
        /// One per web request (if web context exists) or thread.
        /// </summary>
        OnePerRequestOrThread,
        /// <summary>
        /// Singleton.
        /// </summary>
        Singleton
    }
}