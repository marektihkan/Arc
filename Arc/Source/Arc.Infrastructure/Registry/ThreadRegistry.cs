using System;
using System.Collections;
using System.Collections.Specialized;

namespace Arc.Infrastructure.Registry
{
    /// <summary>
    /// Registry in thread context.
    /// </summary>
    public class ThreadRegistry : BaseRegistry, IThreadRegistry
    {
        [ThreadStatic] 
        private IDictionary _map = new HybridDictionary();

        /// <summary>
        /// Gets the map where items are stored.
        /// </summary>
        /// <value>The map.</value>
        protected override IDictionary Map
        {
            get { return _map; }
        }
    }
}