using System.Web.Routing;

namespace Arc.Infrastructure.Configuration.Routing
{
    /// <summary>
    /// Route builder.
    /// </summary>
    public interface IRouteBuilder
    {
        /// <summary>
        /// Specifies route defaults.
        /// </summary>
        /// <param name="defaults">The defaults.</param>
        /// <returns></returns>
        IRouteBuilder DefaultsAre(object defaults);

        /// <summary>
        /// Specifies route's constraints.
        /// </summary>
        /// <param name="constraint">The constraint.</param>
        /// <returns></returns>
        IRouteBuilder ConstrainedBy(object constraint);

        /// <summary>
        /// Registers the specified route to route collection.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="handler">The handler.</param>
        void Register(RouteCollection routes, IRouteHandler handler);
    }
}