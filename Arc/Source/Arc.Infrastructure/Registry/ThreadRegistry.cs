using System;
using System.Collections;
using System.Collections.Specialized;

namespace Arc.Infrastructure.Registry
{
    public class ThreadRegistry : BaseRegistry, IThreadRegistry
    {
        [ThreadStatic] 
        private IDictionary _map = new HybridDictionary();

        protected override IDictionary Map
        {
            get { return _map; }
        }
    }
}