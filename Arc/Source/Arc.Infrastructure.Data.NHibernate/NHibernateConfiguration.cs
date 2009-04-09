using Arc.Infrastructure.Data.NHibernate.Listeners;
using NHibernate;
using NHibernate.Event;

namespace Arc.Infrastructure.Data.NHibernate
{
    public class NHibernateConfiguration : INHibernateConfiguration
    {
        public NHibernateConfiguration()
        {
            var configuration = new global::NHibernate.Cfg.Configuration();
            configuration.SetListener(ListenerType.PreInsert, new PreInsertEventListener());
            configuration.SetListener(ListenerType.PreUpdate, new PreUpdateEventListener());
            Config = configuration.Configure();
        }

        public global::NHibernate.Cfg.Configuration Config { get; set; }

        public ISessionFactory BuildSessionFactory( )
        {
            return Config.BuildSessionFactory();
        }
    }
}