using System.Collections.Generic;
using Arc.Domain.Specifications;
using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Data;
using Arc.Infrastructure.Data.NHibernate;
using Arc.Infrastructure.Dependencies;
using NHibernate;
using NHibernate.Criterion;
using Ninject.Core;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Learning.Tests
{
    [TestFixture]
    public class DependencyTests
    {
        [Test]
        [Ignore("Not needed")]
        public void TEST_NAME()
        {
            Configure.ServiceLocator.ProviderTo("Arc.Infrastructure.Dependencies.CastleWindsor.ServiceLocator, Arc.Infrastructure.Dependencies.CastleWindsor");

            //ServiceLocator.ServiceLocator.Register<IService, ServiceImpl>(ServiceLocator.Scopes.Singleton);
//            ServiceLocator.ServiceLocator.Register<IService, ServiceImpl>();
//
//            ServiceLocator.ServiceLocator.Register(typeof(IRepository<>), typeof(Repository<>));
//            ServiceLocator.ServiceLocator.Register<IRepository<DomainEntity>, DomainEntityRepository>();
//            ServiceLocator.ServiceLocator.Register<IDomainRepository, DomainRepository>();
//            ServiceLocator.ServiceLocator.Register<IDomain2Repository, Domain2Repository>();

            var actuals = ServiceLocator.Resolve<IService>();
            var actual = ServiceLocator.Resolve<IDomainRepository>();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Repository, Is.Not.Null);
            Assert.That(actual.Repository, Is.InstanceOfType(typeof(DomainEntityRepository)));

//            var actual2 = ServiceLocator.Resolve<IDomain2Repository>();
//            
//            Assert.That(actual2, Is.Not.Null);
//            Assert.That(actual2.Repository, Is.Not.Null);
//            Assert.That(actual2.Repository, Is.InstanceOfType(typeof(IRepository<Domain2Entity>)));
        }

        [Test]
        public void TEST_NAME2()
        {
            StandardKernel kernel = new StandardKernel();

            
//            kernel.AddBinding(new InlineModule(x => x.Bind<IRepository>().ToFactoryMethod(
        }
    }

    public interface IDomainRepository
    {
        IRepository<DomainEntity> Repository { get; set; }
    }

    public class DomainRepository : IDomainRepository
    {
        public DomainRepository(IRepository<DomainEntity> repository)
        {
            Repository = repository;
        }

        public IRepository<DomainEntity> Repository { get; set; }

    }

    public interface IDomain2Repository
    {
        IRepository<Domain2Entity> Repository { get; set; }
    }

    public class Domain2Repository : IDomain2Repository
    {
        public Domain2Repository(IRepository<Domain2Entity> repository)
        {
            Repository = repository;
        }

        public IRepository<Domain2Entity> Repository { get; set; }

    }

    public class Domain2Entity
    {
    }

    public class DomainEntity
    {
    }

    public class DomainEntityRepository : IRepository<DomainEntity>
    {
        public DomainEntity GetEntityById(object identity)
        {
            throw new System.NotImplementedException();
        }

        public DomainEntity GetEntityBy(ICriteria criteria)
        {
            throw new System.NotImplementedException();
        }

        public IList<DomainEntity> GetAllEntities()
        {
            throw new System.NotImplementedException();
        }

        public IList<DomainEntity> GetEntitiesBy(ICriteria criteria)
        {
            throw new System.NotImplementedException();
        }

        public DomainEntity Get()
        {
            throw new System.NotImplementedException();
        }

        public DomainEntity Save(DomainEntity saveable)
        {
            throw new System.NotImplementedException();
        }

        void IRepository<DomainEntity>.Delete(DomainEntity deleteable)
        {
            throw new System.NotImplementedException();
        }

        public ICriteria CreateCriteria()
        {
            throw new System.NotImplementedException();
        }

        public DomainEntity Delete(DomainEntity deleteable)
        {
            throw new System.NotImplementedException();
        }

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
    }
}