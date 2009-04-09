namespace Arc.Infrastructure.Data.NHibernate
{
    public abstract class BaseRepository<TEntity> : BaseGenericRepository<TEntity, INHibernateRepository<TEntity>> where TEntity : class
    {
        protected BaseRepository(INHibernateRepository<TEntity> repository) : base(repository)
        {
        }
    }
}