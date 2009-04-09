using Arc.Domain.Identity;
using Arc.Infrastructure.Data;
using Arc.Unit.Tests.Fakes.Data;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;

namespace Arc.Unit.Tests.Infrastructure.Data
{
    [TestFixture]
    public class BaseRepositoryTests
    {
        private IRepository<IEntity> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = MockRepository.GenerateMock<IRepository<IEntity>>();

            _repository.Stub(x => x.UnitOfWork).Return(MockRepository.GenerateStub<IUnitOfWork>()).Repeat.Any();
        }

        private Repository CreateSUT()
        {
            return new Repository(_repository);
        }


        [Test]
        public void Repository_should_have_access_to_inner_repository()
        {
            var actual = CreateSUT().GetInnerRepository();

            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void Repository_should_have_access_to_unit_of_work()
        {
            var actual = CreateSUT().GetUnitOfWork();

            Assert.That(actual, Is.Not.Null);
        }
    }
}