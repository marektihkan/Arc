using System.Collections.Generic;
using System.Web.Routing;
using Arc.Domain.Dsl;

namespace Arc.Infrastructure.Configuration.Routing
{
    /// <summary>
    /// Base routes configuration for web application.
    /// </summary>
    public abstract class BaseRoutesConfiguration : IRoutesConfiguration
    {
        private readonly IList<IRouteBuilder> _routes = new List<IRouteBuilder>();
        private readonly IList<IRouteBuilder> _ignoredRoutes = new List<IRouteBuilder>();

        /// <summary>
        /// Ignores the specified routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        protected void Ignore(params IRouteBuilder[] routes)
        {
            routes.Each(x => _ignoredRoutes.Add(x));
        }

        /// <summary>
        /// Registers the specified routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        protected void Register(params IRouteBuilder[] routes)
        {
            routes.Each(x => _routes.Add(x));
        }

        /// <summary>
        /// Loads the specified routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        public void Load(RouteCollection routes)
        {
            Configure();
            _routes.Each(x => x.Register(routes, GetRouteHandler()));
        }

        protected abstract IRouteHandler GetRouteHandler();
        protected abstract void Configure();
    }
}