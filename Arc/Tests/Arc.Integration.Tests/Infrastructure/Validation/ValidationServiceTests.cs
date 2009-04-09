using Arc.Infrastructure.Configuration;
using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Validation;
using Arc.Integration.Tests.Fakes.Validation;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Integration.Tests.Infrastructure.Validation
{
    [TestFixture]
    public class ValidationServiceTests
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Configure.ServiceLocator.ProviderTo(new Arc.Infrastructure.Dependencies.StructureMap.ServiceLocator())
                .With<Arc.Infrastructure.Validation.EnterpriseLibrary.ValidationConfiguration>();
        }

        private IValidationService CreateSUT()
        {
            return ServiceLocator.Resolve<IValidationService>();
        }


        [Test]
        public void Should_get_empty_validation_results_when_domain_object_is_valid()
        {
            var target = CreateSUT();

            var actual = target.Validate<DomainEntity>(EntityFactory.CreateValidDomainEntity());

            Assert.That(actual.IsValid, Is.True);
        }

        [Test]
        public void Should_get_validation_results_when_domain_entity_is_not_valid()
        {
            var target = CreateSUT();

            var actual = target.Validate<DomainEntity>(EntityFactory.CreateInvalidDomainEntity());

            Assert.That(actual.IsValid, Is.False);
        }

        [Test]
        public void Should_get_empty_validation_result_on_null_domain_entity()
        {
            var target = CreateSUT();

            var actual = target.Validate<DomainEntity>(null);

            Assert.That(actual, Is.InstanceOfType(typeof(EmptyValidationResults)));
        }
    }
}