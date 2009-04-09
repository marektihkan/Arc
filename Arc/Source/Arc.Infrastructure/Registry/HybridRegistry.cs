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
        /// <summary>
        /// Initializes a new instance of the <see cref="HybridRegistry"/> class.
        /// </summary>
        public HybridRegistry()
        {
            RealMap = (HttpContext.Current != null) ? HttpContext.Current.Items : new HybridDictionary();
        }

        private IDictionary RealMap { get; set; }

        /// <summary>
        /// Gets the map where items are stored.
        /// </summary>
        /// <value>The map.</value>
        protected override IDictionary Map
        {
            get { return RealMap; }
        }
    }
}