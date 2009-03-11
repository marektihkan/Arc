using System.Collections.Generic;
using Arc.Domain.Identity;
using Arc.Infrastructure.Data;
using Arc.Infrastructure.Data.NHibernate;
using NHibernate;
using NHibernate.Criterion;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;

namespace Arc.Unit.Tests.Infrastructure.Data
{
    [TestFixture]
    public class RepositoryTests
    {
        private IUnitOfWork _unitOfWork;
        private ISession _session;

        [SetUp]
        public void SetUp()
        {
            _session = MockRepository.GenerateMock<ISession>();
            _unitOfWork = MockRepository.GenerateMock<IUnitOfWork>();

            _unitOfWork.Stub(x => x.Session).Return(_session).Repeat.Any();
        }

        private IRepository<IEntity> CreateSUT()
        {
            return new Repository<IEntity>(_unitOfWork);
        }

        private IEntity CreateEntity()
        {
            return MockRepository.GenerateStub<IEntity>();
        }


        [Test]
        public void Repository_should_have_unit_of_work()
        {
            Assert.That(CreateSUT().UnitOfWork, Is.SameAs(_unitOfWork));
        }

        [Test]
        public void Repository_should_have_session()
        {
            Assert.That(CreateSUT().Session, Is.SameAs(_session));
        }

        [Test]
        public void Should_get_entity_by_identity()
        {
            var expected = CreateEntity();

            _session.Stub(x => x.Get<IEntity>(1)).Return(expected);

            var actual = CreateSUT().GetEntityById(1);

            Assert.That(actual, Is.SameAs(expected));
        }

        [Test]
        public void Should_get_null_entity_by_identity_when_its_not_found_in_repository()
        {
            _session.Stub(x => x.Get<IEntity>(1)).Return(null);

            var actual = CreateSUT().GetEntityById(1);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void Should_get_all_entities()
        {
            var entities = new List<IEntity> { CreateEntity() };
            var criteria = MockRepository.GenerateMock<ICriteria>();

            _session.Stub(x => x.CreateCriteria(typeof(IEntity))).Return(criteria);
            criteria.Stub(x => x.List<IEntity>()).Return(entities);

            var actual = CreateSUT().GetAllEntities();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Should_get_null_list_when_entities_are_not_found_in_repository()
        {
            var criteria = MockRepository.GenerateMock<ICriteria>();

            _session.Stub(x => x.CreateCriteria(typeof(IEntity))).Return(criteria);
            criteria.Stub(x => x.List<IEntity>()).Return(null);

            var actual = CreateSUT().GetAllEntities();

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void Should_create_count_criteria()
        {
            var criteria = MockRepository.GenerateMock<ICriteria>();

            criteria.Stub(x => x.UniqueResult()).Return(1);

            var actual = CreateSUT().Count(criteria);

            Assert.That(actual, Is.EqualTo(1));

            var rowCountType = Projections.RowCount().GetType();
            criteria.AssertWasCalled(x => x.SetProjection(Arg<IProjection>.Matches(y => y.GetType() == rowCountType)));
        }

        [Test]
        public void Should_save_entity_to_repository()
        {
            var entity = CreateEntity();

            _session.Expect(x => x.SaveOrUpdate(entity));
            _session.Expect(x => x.Flush());
            
            CreateSUT().Save(entity);

            _session.VerifyAllExpectations();
        }
        
        [Test]
        public void Should_not_save_null_entity_to_repository()
        {
            _session.Expect(x => x.SaveOrUpdate(null)).Repeat.Never();
            _session.Expect(x => x.Flush()).Repeat.Never();
            
            CreateSUT().Save(null);

            _session.VerifyAllExpectations();
        }

        //TODO: Test saving in transaction

        [Test]
        public void Should_delete_entity_from_repository()
        {
            var entity = CreateEntity();

            _session.Expect(x => x.Delete(entity));
            _session.Expect(x => x.Flush());

            CreateSUT().Delete(entity);

            _session.VerifyAllExpectations();
        }

        [Test]
        public void Should_not_delete_null_entity_from_repository()
        {
            _session.Expect(x => x.Delete(null)).Repeat.Never();
            _session.Expect(x => x.Flush()).Repeat.Never();

            CreateSUT().Delete(null);

            _session.VerifyAllExpectations();
        }

        //TODO: Test deleting in transaction

        [Test]
        public void Should_create_criteria()
        {
            var expected = MockRepository.GenerateStub<ICriteria>();
            
            _session.Stub(x => x.CreateCriteria(typeof(IEntity))).Return(expected);

            var actual = CreateSUT().CreateCriteria();

            Assert.That(actual, Is.SameAs(expected));
        }

        [Test]
        public void Should_query_entities_by_criteria()
        {
            var criteria = MockRepository.GenerateMock<ICriteria>();

            CreateSUT().GetEntitiesBy(criteria);

            criteria.AssertWasCalled(x => x.List<IEntity>());
        }

        [Test]
        public void Should_return_empty_list_when_querying_entities_by_null_criteria()
        {
            var actual = CreateSUT().GetEntitiesBy(null);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Count, Is.EqualTo(0));
        }

        //TODO: Test with detached criteria

        [Test]
        public void Should_query_entity_by_criteria()
        {
            var criteria = MockRepository.GenerateMock<ICriteria>();

            CreateSUT().GetEntityBy(criteria);

            criteria.AssertWasCalled(x => x.UniqueResult<IEntity>());
        }

        [Test]
        public void Should_not_query_entity_by_null_criteria()
        {
            var actual = CreateSUT().GetEntityBy(null);

            Assert.That(actual, Is.Null);
        }

        //TODO: Test with detached criteria

        [Test]
        public void Should_evict_specified_object()
        {
            var evitable = new object();

            CreateSUT().Evict(evitable);

            _session.AssertWasCalled(x => x.Evict(evitable));
        }

        [Test]
        public void Should_clear_session()
        {
            CreateSUT().Clear();

            _session.AssertWasCalled(x => x.Clear());
        }
    }
}