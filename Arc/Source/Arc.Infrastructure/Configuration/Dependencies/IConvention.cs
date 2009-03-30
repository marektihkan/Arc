namespace Arc.Infrastructure.Configuration.Dependencies
{
    /// <summary>
    /// Convention for configuration.
    /// </summary>
    public interface IConvention<TConventionHandler>
    {
        /// <summary>
        /// Applies this convention.
        /// </summary>
        void Apply(TConventionHandler handler);
    }
}