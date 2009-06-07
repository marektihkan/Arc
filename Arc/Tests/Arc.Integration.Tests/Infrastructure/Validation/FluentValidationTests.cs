using Arc.Infrastructure.Dependencies;
using Arc.Infrastructure.Dependencies.Registration;
using Arc.Infrastructure.Validation.FluentValidation;
using Arc.Integration.Tests.Fakes.Validation;
using FluentValidation;
using NUnit.Framework;

namespace Arc.Integration.Tests.Infrastructure.Validation
{
    [TestFixture]
    public class FluentValidationTests : ValidationServiceTests
    {
        protected override IServiceLocatorModule<IServiceLocator> GetConfiguration()
        {
            return new ValidationConfiguration();
        }

        public override void ValidationConfiguration()
        {
            ServiceLocator.Register(
                Requested.Service<Arc.Infrastructure.Validation.IValidator<DomainEntity>>().IsImplementedBy<DomainEntityValidator>());
        }

        
    }
    public class DomainEntityValidator : Validator<DomainEntity>
    {
        public DomainEntityValidator()
        {
            RuleFor(x => x.Name).NotNull();
        }
    }
}