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

namespace Arc.Infrastructure.Registry
{
    /// <summary>
    /// Registry in thread context.
    /// </summary>
    public class ThreadRegistry : BaseRegistry, IThreadRegistry
    {
        [ThreadStatic] 
        private IDictionary _map;

        /// <summary>
        /// Gets the map where items are stored.
        /// </summary>
        /// <value>The map.</value>
        protected override IDictionary Map
        {
            get
            {
                if (_map == null)
                {
                    _map = new Hashtable();
                }
                return _map;

            }
        }
    }
}