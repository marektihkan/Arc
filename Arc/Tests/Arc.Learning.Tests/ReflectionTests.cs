using Arc.Learning.Tests.Fakes.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

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
    }
}