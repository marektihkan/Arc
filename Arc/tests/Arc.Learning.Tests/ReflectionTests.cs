using Arc.Infrastructure.Validation;
using Arc.Learning.Tests.Fakes.Model;
using NUnit.Framework;

namespace Arc.Learning.Tests
{
    [TestFixture]
    public class ReflectionTests
    {
        [Test]
        public void Should_get_generic_type_full_name()
        {
            const string expected = "Arc.Learning.Tests.Fakes.Model.IGenericService`1";

            Assert.That(typeof(IGenericService<>).FullName, Is.EqualTo(expected));
        }

        [Test]
        public void Should_create_generic_type_from_types()
        {
            var validationType = typeof(DomainEntity);
            var type = typeof(IValidator<>);

            var genericType = type.MakeGenericType(validationType);

            Assert.That(genericType.FullName, Is.StringContaining("Arc.Infrastructure.Validation.IValidator`1"));
            Assert.That(genericType.FullName, Is.StringContaining("Arc.Learning.Tests.Fakes.Model.DomainEntity"));
        }
    }
}