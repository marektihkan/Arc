using System;
using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Data.NHibernate.Listeners;
using Arc.Infrastructure.Validation;
using Arc.Integration.Tests.Fakes.Validation;
using NUnit.Framework;
using Rhino.Mocks;

namespace Arc.Integration.Tests.Infrastructure.Validation
{
    [TestFixture]
    public class BaseValidationListenerTests
    {
        private IValidationService _validation;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Application.ServiceLocatorIs(new Arc.Infrastructure.Dependencies.StructureMap.ServiceLocator())
                .Load(Arc.Infrastructure.Validation.EnterpriseLibrary.ValidationConfiguration.Default());
        }

        [SetUp]
        public void SetUp()
        {
            _validation = MockRepository.GenerateMock<IValidationService>();
        }


        private BaseValidationListener CreateSUTWithFakes()
        {
            return new BaseValidationListener(_validation);
        }

        private BaseValidationListener CreateSUT()
        {
            return new BaseValidationListener();
        }

        [Test]
        public void Should_validate_entity()
        {
            var entity = EntityFactory.CreateValidDomainEntity();
            var type = typeof(DomainEntity);

            _validation.Expect(x => x.Validate(entity, type)).Return(new EmptyValidationResults());

            CreateSUTWithFakes().Validate(entity, type);
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public void Should_throw_exception_when_entity_is_not_valid()
        {
            var entity = EntityFactory.CreateInvalidDomainEntity();

            CreateSUT().Validate(entity, typeof(DomainEntity));
        }

        [Test]
        public void Should_not_validate_null_entity()
        {
            var type = typeof(DomainEntity);

            CreateSUTWithFakes().Validate(null, type);

            _validation.AssertWasNotCalled(x => x.Validate(Arg<object>.Is.Anything, Arg<Type>.Is.Anything));
        }

    }
}