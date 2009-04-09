using Arc.Infrastructure.Data;
using Arc.Infrastructure.Data.NHibernate;
using Arc.Infrastructure.Registry;
using NHibernate;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;

namespace Arc.Unit.Tests.Infrastructure.Data.NHibernate
{
    [TestFixture]
    public class UnitOfWorkFactoryTests
    {
        private ISessionFactory _sessionFactory;
        private IRegistry _registry;


        [SetUp]
        public void SetUp()
        {
            _sessionFactory = MockRepository.GenerateMock<ISessionFactory>();
            _registry = MockRepository.GenerateMock<IRegistry>();
        }

        private UnitOfWorkFactory CreateSUT()
        {
            return new UnitOfWorkFactory(_registry, _sessionFactory);
        }

        private UnitOfWorkFactory CreateSUTWithLocalRegistry()
        {
            return new UnitOfWorkFactory(new LocalRegistry(), _sessionFactory);
        }

        [Test]
        public void Should_create_new_unit_of_work()
        {
            var target = CreateSUTWithLocalRegistry();

            var actual = target.Create();

            Assert.That(actual, Is.Not.Null, "Created unit of work should not be empty.");
        }

        [Test]
        public void Should_get_same_session_in_unit_of_work_when_session_is_not_discarded()
        {
            var target = CreateSUTWithLocalRegistry();
            var session = MockRepository.GenerateMock<ISession>();

            _sessionFactory.Stub(x => x.OpenSession()).Return(session);

            var actual = target.Create() as UnitOfWork;

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.RealSession, Is.SameAs(session));
        }

        [Test]
        public void Should_release_unit_of_work()
        {
            var unitOfWork = MockRepository.GenerateStub<IUnitOfWork>();

            CreateSUT().Release(unitOfWork);

            _registry.AssertWasCalled(x => x.Unregister(UnitOfWorkFactory.UnitOfWorkKey));
        }

        [Test]
        public void Should_release_unit_of_work_and_session()
        {
            var unitOfWork = MockRepository.GenerateStub<IUnitOfWork>();
            var session = MockRepository.GenerateStub<ISession>();

            _registry.Stub(x => x.Unregister<ISession>(UnitOfWorkFactory.SessionKey)).Return(session);

            CreateSUT().Release(unitOfWork);

            _registry.AssertWasCalled(x => x.Unregister(UnitOfWorkFactory.UnitOfWorkKey));
            session.AssertWasCalled(x => x.Dispose());
        }
    }
}