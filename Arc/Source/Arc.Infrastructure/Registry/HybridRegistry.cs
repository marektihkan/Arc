using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web;

namespace Arc.Infrastructure.Registry
{
    /// <summary>
    /// Registry which adds itmes to web request context or thread.
    /// </summary>
    public class HybridRegistry : BaseRegistry, IHybridRegistry
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
                if (HttpContext.Current != null) return HttpContext.Current.Items;

                if (_map == null)
                {
                    _map = new Hashtable();
                }
                return _map;
            }
        }
    }
}