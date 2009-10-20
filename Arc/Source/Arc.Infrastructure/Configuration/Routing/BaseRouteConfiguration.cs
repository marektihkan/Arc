#region License
//
//   Copyright 2009 Marek Tihkan
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License
//
#endregion

using System.Collections.Generic;
using System.Web.Routing;
using Arc.Domain.Dsl;

namespace Arc.Infrastructure.Configuration.Routing
{
    /// <summary>
    /// Base routes configuration for web application.
    /// </summary>
    public abstract class BaseRoutesConfiguration : IConfiguration<RouteCollection>
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
        protected void Map(params IRouteBuilder[] routes)
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

            _ignoredRoutes.Each(x => IgnoreRoute(x, routes));
            _routes.Each(x => RegisterRoute(x, routes));
        }


        protected abstract void IgnoreRoute(IRouteBuilder route, RouteCollection routes);
        protected abstract void RegisterRoute(IRouteBuilder route, RouteCollection routes);
        protected abstract void Configure();
    }
}