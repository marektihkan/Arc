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

using System;
using System.Web.Mvc;
using System.Web.Routing;
using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;

namespace Arc.Infrastructure.Presentation.Mvc
{
    /// <summary>
    /// Configuration for MVC application.
    /// </summary>
    public class PresentationConfiguration : IConfiguration<IServiceLocator>
    {
        private readonly Type _routeConfigurationType;

        /// <summary>
        /// Initializes a new instance of the <see cref="PresentationConfiguration"/> class.
        /// </summary>
        /// <param name="routeConfigurationType">Type of the route configuration.</param>
        public PresentationConfiguration(Type routeConfigurationType)
        {
            _routeConfigurationType = routeConfigurationType;
        }


        /// <summary>
        /// Creates default configuration.
        /// </summary>
        /// <returns>Default configuration.</returns>
        public static PresentationConfiguration Default()
        {
            return new PresentationConfiguration(null);
        }

        /// <summary>
        /// Creates presentation configuratiob with routing.
        /// </summary>
        /// <typeparam name="TRoutesConfiguration">The type of the routes configuration.</typeparam>
        /// <returns></returns>
        public static PresentationConfiguration WithRouting<TRoutesConfiguration>()
            where TRoutesConfiguration : IConfiguration<RouteCollection>
        {
            return new PresentationConfiguration(typeof(TRoutesConfiguration));
        }

        /// <summary>
        /// Loads presentation configuration to service locator.
        /// </summary>
        /// <param name="handler">The handler.</param>
        public void Load(IServiceLocator handler)
        {
            RegisterControllerFactory(handler);

            if (_routeConfigurationType != null)
            {
                RegisterRouteConfiguration(handler);
            }
        }

        private void RegisterControllerFactory(IServiceLocator handler)
        {
            handler.Register(
                Requested.Service<IControllerFactory>()
                    .IsImplementedBy<ControllerFactory>()
                    .LifeStyle.IsSingelton()
                );
        }

        private void RegisterRouteConfiguration(IServiceLocator handler)
        {
            handler.Register(
                Requested.Service<IConfiguration<RouteCollection>>()
                    .IsImplementedBy(_routeConfigurationType)
                    .LifeStyle.IsSingelton()
                );
        }
    }
}