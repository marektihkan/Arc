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
        /// Gets the data.
        /// </summary>
        /// <value>The data.</value>
        Route.RouteDataContract Data { get; }
    }
}