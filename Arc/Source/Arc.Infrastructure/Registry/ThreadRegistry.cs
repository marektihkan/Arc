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