namespace Arc.Infrastructure.Configuration.Routing
{
    /// <summary>
    /// Route builder with route name.
    /// </summary>
    public interface INamedRouteBuilder
    {
        /// <summary>
        /// Specifies route URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        IRouteBuilder Url(string url);
    }
}