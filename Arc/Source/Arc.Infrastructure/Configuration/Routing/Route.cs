using System;
using System.Web.Routing;

namespace Arc.Infrastructure.Configuration.Routing
{
    /// <summary>
    /// Web application route.
    /// </summary>
    public class Route : IRouteBuilder, INamedRouteBuilder
    {
        private readonly string _name;
        private string _url;
        private object _constraint;
        private object _default;
        private string[] _namespaces;

        /// <summary>
        /// Initializes a new instance of the <see cref="Route"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Route(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Specifies route name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static INamedRouteBuilder Named(string name)
        {
            return new Route(name);
        }

        /// <summary>
        /// Specifies route URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public IRouteBuilder Url(string url)
        {
            _url = url;
            return this;
        }

        /// <summary>
        /// Specifies route defaults.
        /// </summary>
        /// <param name="defaults">The defaults.</param>
        /// <returns></returns>
        public IRouteBuilder DefaultsAre(object defaults)
        {
            _default = defaults;
            return this;
        }

        /// <summary>
        /// Specifies route's constraints.
        /// </summary>
        /// <param name="constraint">The constraint.</param>
        /// <returns></returns>
        public IRouteBuilder ConstrainedBy(object constraint)
        {
            _constraint = constraint;
            return this;
        }

        /// <summary>
        /// Registers the specified route to routes.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="handler">The handler.</param>
        public void Register(RouteCollection routes, IRouteHandler handler)
        {
            if (routes == null) throw new ArgumentNullException("routes");
            if (handler == null) throw new ArgumentNullException("handler");

            routes.Add(_name, BuildRoute(handler));
        }

        private System.Web.Routing.Route BuildRoute(IRouteHandler handler)
        {
            var route = new System.Web.Routing.Route(_url, handler)
                            {
                                Defaults = new RouteValueDictionary(_default),
                                Constraints = new RouteValueDictionary(_constraint)
                            };

            if (_namespaces != null && _namespaces.Length > 0)
            {
                route.DataTokens = new RouteValueDictionary();
                route.DataTokens["Namespaces"] = _namespaces;
            }
            return route;
        }
    }
}