using Arc.Infrastructure.Data.NHibernate;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;
using ITransaction=Arc.Infrastructure.Data.ITransaction;

namespace Arc.Unit.Tests.Infrastructure.Data
{
    [TestFixture]
    public class TransactionTests
    {
        private NHibernate.ITransaction _transaction;

        [SetUp]
        public void SetUp()
        {
            _transaction = MockRepository.GenerateMock<NHibernate.ITransaction>();
        }

        private ITransaction CreateSUT()
        {
            return new Transaction(_transaction);
        }


        [Test]
        public void Should_commit_transaction()
        {
            CreateSUT().Commit();

            _transaction.AssertWasCalled(x => x.Commit());
        }

        [Test]
        public void Should_rollback_transaction()
        {
            CreateSUT().Rollback();

            _transaction.AssertWasCalled(x => x.Rollback());
        }

        [Test]
        public void Transaction_should_be_active_when_its_started()
        {
            _transaction.Stub(x => x.IsActive).Return(true);

            var actual = CreateSUT().IsActive;

            Assert.That(actual, Is.True);
        }

        [Test]
        public void Should_dispose_transaction()
        {
            CreateSUT().Dispose();

            _transaction.AssertWasCalled(x => x.Dispose());
        }
    }
}