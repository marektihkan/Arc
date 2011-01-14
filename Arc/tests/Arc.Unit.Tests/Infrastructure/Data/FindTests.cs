using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Data;
using Arc.Infrastructure.Dependencies;
using Arc.Unit.Tests.Fakes.Entities;
using NUnit.Framework;
using Rhino.Mocks;

namespace Arc.Unit.Tests.Infrastructure.Data
{
    [TestFixture]
    public class FindTests
    {
        private IServiceLocator _serviceLocator;
        private IRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _serviceLocator = MockRepository.GenerateMock<IServiceLocator>();
            _repository = MockRepository.GenerateMock<IRepository>();

            Application.ServiceLocatorIs(_serviceLocator);

            _serviceLocator.Stub(x => x.Resolve<IRepository>()).Return(_repository);
        }


        [Test]
        public void Should_find_entity_by_identity()
        {
            Find<Person>.ByIdentity(1);

            _repository.AssertWasCalled(x => x.GetEntityById<Person>(1));
        }
        
        [Test]
        public void Should_find_all_entities()
        {
            var entities = Find<Person>.All;

            _repository.AssertWasCalled(x => x.Query<Person>());
        }
    }
}