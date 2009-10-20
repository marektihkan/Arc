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

namespace Arc.Infrastructure.Configuration.Routing
{
    /// <summary>
    /// Web application route.
    /// </summary>
    public class Route : IRouteBuilder, INamedRouteBuilder
    {
        private readonly RouteDataContract _data = new RouteDataContract();

        /// <summary>
        /// Initializes a new instance of the <see cref="Route"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Route(string name)
        {
            _data.Name = name;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>The data.</value>
        public RouteDataContract Data
        {
            get { return _data;}
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
            _data.Url = url;
            return this;
        }

        /// <summary>
        /// Specifies route defaults.
        /// </summary>
        /// <param name="defaults">The defaults.</param>
        /// <returns></returns>
        public IRouteBuilder DefaultsAre(object defaults)
        {
            _data.Defaults = defaults;
            return this;
        }

        /// <summary>
        /// Specifies route's constraints.
        /// </summary>
        /// <param name="constraint">The constraint.</param>
        /// <returns></returns>
        public IRouteBuilder ConstrainedBy(object constraint)
        {
            _data.Constraint = constraint;
            return this;
        }

        /// <summary>
        /// Route data.
        /// </summary>
        public class RouteDataContract
        {
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the URL.
            /// </summary>
            /// <value>The URL.</value>
            public string Url { get; set; }

            /// <summary>
            /// Gets or sets the defaults.
            /// </summary>
            /// <value>The defaults.</value>
            public object Defaults { get; set; }

            /// <summary>
            /// Gets or sets the constraint.
            /// </summary>
            /// <value>The constraint.</value>
            public object Constraint { get; set; }

            /// <summary>
            /// Gets or sets the namespaces.
            /// </summary>
            /// <value>The namespaces.</value>
            public string[] Namespaces { get; set; }
        }
    }
}