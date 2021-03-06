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
using System.Collections;
using System.Web;

namespace Arc.Infrastructure.Registry
{
    /// <summary>
    /// Web request registry.
    /// </summary>
    public class WebRequestRegistry : BaseRegistry, IWebRequestRegistry
    {
        private const string Key = "Arc.Infrastructure.Registry.WebRequestRegistry";

        /// <summary>
        /// Initializes a new instance of the <see cref="WebRequestRegistry"/> class.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="HttpContext"/> is not currently available.</exception>
        public WebRequestRegistry()
        {
            if (HttpContext.Current == null)
                throw new InvalidOperationException("HttpContext is not currently available.");
        }

        /// <summary>
        /// Gets the map where items are stored.
        /// </summary>
        /// <value>The map.</value>
        protected override IDictionary Map
        {
            get
            {
                var registry = HttpContext.Current.Items[Key] as IDictionary;
                if (registry == null)
                {
                    registry = new Hashtable();
                    HttpContext.Current.Items[Key] = registry;
                }
                return registry;
            }
        }
    }
}