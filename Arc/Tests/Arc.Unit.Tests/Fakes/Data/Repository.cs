using System.Collections.Generic;
using Arc.Domain.Identity;
using Arc.Domain.Specifications;
using Arc.Infrastructure.Data;
using NHibernate;
using NHibernate.Criterion;

namespace Arc.Unit.Tests.Fakes.Data
{
    public class Repository : BaseRepository<IEntity>
    {
        public Repository(IRepository<IEntity> repository) : base(repository)
        {
        }

        public IRepository<IEntity> GetInnerRepository()
        {
            return InnerRepository;
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return UnitOfWork;
        }
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public ISession Session
        {
            get { throw new System.NotImplementedException(); }
        }

        public IUnitOfWork UnitOfWork
        {
            get { throw new System.NotImplementedException(); }
        }

        public T GetEntityById<T>(object identity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public T GetEntityBy<T>(ICriteria criteria) where T : class
        {
            throw new System.NotImplementedException();
        }

        public T GetEntityBy<T>(ISpecification<T> specification) where T : class
        {
            throw new System.NotImplementedException();
        }

        public T GetEntityBy<T>(DetachedCriteria criteria) where T : class
        {
            throw new System.NotImplementedException();
        }

        public IList<T> GetAllEntities<T>() where T : class
        {
            throw new System.NotImplementedException();
        }

        public IList<T> GetEntitiesBy<T>(ICriteria criteria) where T : class
        {
            throw new System.NotImplementedException();
        }

        public IList<T> GetEntitiesBy<T>(ISpecification<T> specification) where T : class
        {
            throw new System.NotImplementedException();
        }

        public IList<T> GetEntitiesBy<T>(DetachedCriteria criteria) where T : class
        {
            throw new System.NotImplementedException();
        }

        public ICriteria CreateCriteria<T>() where T : class
        {
            throw new System.NotImplementedException();
        }

        public long Count(DetachedCriteria criteria)
        {
            throw new System.NotImplementedException();
        }

        public long Count<T>(ISpecification<T> specification) where T : class
        {
            throw new System.NotImplementedException();
        }

        public long Count(ICriteria criteria)
        {
            throw new System.NotImplementedException();
        }

        public T Save<T>(T saveable) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T deleteable) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public void Evict(object evitable)
        {
            throw new System.NotImplementedException();
        }

        public TEntity GetEntityById(object identity)
        {
            throw new System.NotImplementedException();
        }

        public TEntity GetEntityBy(ICriteria criteria)
        {
            throw new System.NotImplementedException();
        }

        public IList<TEntity> GetAllEntities()
        {
            throw new System.NotImplementedException();
        }

        public IList<TEntity> GetEntitiesBy(ICriteria criteria)
        {
            throw new System.NotImplementedException();
        }

        public TEntity Save(TEntity saveable)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(TEntity deleteable)
        {
            throw new System.NotImplementedException();
        }

        public ICriteria CreateCriteria()
        {
            throw new System.NotImplementedException();
        }
    }
}