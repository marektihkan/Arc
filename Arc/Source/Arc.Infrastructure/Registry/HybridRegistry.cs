using System.Collections;
using System.Collections.Specialized;
using System.Web;

namespace Arc.Infrastructure.Registry
{
    public class HybridRegistry : BaseRegistry, IHybridRegistry
    {
        public HybridRegistry()
        {
            RealMap = (HttpContext.Current != null) ? HttpContext.Current.Items : new HybridDictionary();
        }

        private IDictionary RealMap { get; set; }

        protected override IDictionary Map
        {
            get { return RealMap; }
        }
    }
}