using System;
using System.Collections;
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

        private const string Key = "Arc.Infrastructure.Registry.HybridRegistry";

        /// <summary>
        /// Gets the map where items are stored.
        /// </summary>
        /// <value>The map.</value>
        protected override IDictionary Map
        {
            get
            {
                return IsHttpContextAvailable() ? GetHttpContextRegistry() : GetThreadRegistry();
            }
        }

        private bool IsHttpContextAvailable()
        {
            return HttpContext.Current != null;
        }

        private IDictionary GetThreadRegistry()
        {
            if (_map == null)
            {
                _map = new Hashtable();
            }
            return _map;
        }

        private IDictionary GetHttpContextRegistry()
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