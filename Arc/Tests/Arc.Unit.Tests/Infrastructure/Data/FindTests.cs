using Arc.Domain.Specifications;
using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Data;
using Arc.Infrastructure.Dependencies;
using Arc.Unit.Tests.Fakes.Entities;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;

namespace Arc.Unit.Tests.Infrastructure.Data
{
    [TestFixture]
    public class FindTests
    {
        private IServiceLocator _serviceLocator;
        private IRepository<Person> _repository;

        [SetUp]
        public void SetUp()
        {
            _serviceLocator = MockRepository.GenerateMock<IServiceLocator>();
            _repository = MockRepository.GenerateMock<IRepository<Person>>();

            Configure.ServiceLocator.ProviderTo(_serviceLocator);

            _serviceLocator.Stub(x => x.Resolve<IRepository<Person>>()).Return(_repository);
        }


        [Test]
        public void Should_find_entity_by_identity()
        {
            Find<Person>.ByIdentity(1);

            _repository.AssertWasCalled(x => x.GetEntityById(1));
        }

        [Test]
        public void Should_find_entity_by_specification()
        {
            var specification = new Specification<Person>(x => x.FirstName == "a");
            Find<Person>.By(specification);

            _repository.AssertWasCalled(x => x.GetEntityBy(specification));
        }

        [Test]
        public void Should_find_entity_by_predicate()
        {
            Find<Person>.By(x => x.FirstName == "a");

            _repository.AssertWasCalled(x => x.GetEntityBy(Arg<ISpecification<Person>>.Is.NotNull));
        }

        [Test]
        public void Should_find_all_entities()
        {
            Find<Person>.All();

            _repository.AssertWasCalled(x => x.GetAllEntities());
        }

        [Test]
        public void Should_find_all_entities_by_specification()
        {
            var specification = new Specification<Person>(x => x.FirstName == "a");
            Find<Person>.AllBy(specification);

            _repository.AssertWasCalled(x => x.GetEntitiesBy(specification));
        }

        [Test]
        public void Should_find_all_entities_by_predicate()
        {
            Find<Person>.AllBy(x => x.FirstName == "a");

            _repository.AssertWasCalled(x => x.GetEntitiesBy(Arg<ISpecification<Person>>.Is.NotNull));
        }
    }
}