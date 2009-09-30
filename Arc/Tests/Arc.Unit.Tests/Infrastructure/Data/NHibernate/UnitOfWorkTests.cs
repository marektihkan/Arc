using Arc.Infrastructure.Data;
using Arc.Infrastructure.Data.NHibernate;
using Arc.Unit.Tests.Fakes;
using NHibernate;
using NUnit.Framework;
using Rhino.Mocks;
using ITransaction=NHibernate.ITransaction;

namespace Arc.Unit.Tests.Infrastructure.Data.NHibernate
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        private ISession _session;
        private IUnitOfWorkFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _session = MockRepository.GenerateMock<ISession>();
            _factory = MockRepository.GenerateMock<IUnitOfWorkFactory>();
        }

        private IUnitOfWork CreateSUT()
        {
            return new UnitOfWork(_session, _factory);
        }


        [Test]
        public void Unit_of_work_should_contain_nhibernate_session()
        {
            var target = CreateSUT() as UnitOfWork;

            Assert.That(target.RealSession, Is.SameAs(_session));
        }

        [Test]
        public void Should_begin_transaction()
        {
            var transaction = MockRepository.GenerateMock<global::NHibernate.ITransaction>();

            _session.Stub(x => x.BeginTransaction()).Return(transaction);
            transaction.Stub(x => x.IsActive).Return(true);
            
            var actual = CreateSUT().BeginTransaction();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.IsActive, Is.True);
        }

        [Test]
        public void Should_be_active_transaction_after_starting_it()
        {
            var transaction = MockRepository.GenerateMock<ITransaction>();
            
            _session.Stub(x => x.Transaction).Return(transaction);
            transaction.Stub(x => x.IsActive).Return(true);

            var target = CreateSUT();
            target.BeginTransaction();

            Assert.That(target.IsInTransaction, Is.True);
        }

        [Test]
        public void Should_flush_unit_of_work_and_end_active_transaction()
        {
            var transaction = MockRepository.GenerateMock<global::NHibernate.ITransaction>();

            _session.Stub(x => x.BeginTransaction()).Return(transaction);
            transaction.Stub(x => x.IsActive).Return(true);

            var target = CreateSUT();
            target.TransactionalFlush();

            transaction.AssertWasCalled(x => x.Commit());
        }

        [Test]
        public void Should_rollback_unit_of_works_transaction_when_exception_occurs()
        {
            var transaction = MockRepository.GenerateMock<global::NHibernate.ITransaction>();

            _session.Stub(x => x.BeginTransaction()).Return(transaction);
            transaction.Stub(x => x.IsActive).Return(true).Repeat.Any();
            transaction.Expect(x => x.Commit()).Throw(new DummyException());
            transaction.Expect(x => x.Rollback()).Repeat.Once();

            var target = CreateSUT();
            try
            {
                target.TransactionalFlush();
            }
            catch (DummyException)
            {
            }

            transaction.VerifyAllExpectations();
        }

        [Test]
        public void Should_dispose_unit_of_work()
        {
            var target = CreateSUT();

            target.Dispose();

            _factory.AssertWasCalled(x => x.Release(target));
        }
    }
}