using NHibernate;

namespace Arc.Infrastructure.Data.NHibernate
{
    public interface INHibernateConfiguration
    {
        global::NHibernate.Cfg.Configuration Config { get; set; }
        
        ISessionFactory BuildSessionFactory();
    }
}