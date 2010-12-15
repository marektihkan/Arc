using Arc.Domain.Dsl.Parsing;
using NUnit.Framework;

namespace Arc.Unit.Tests.Domain.Dsl.Parsing
{
    [TestFixture]
    public class EmptyParsingResultTests
    {
        private const int ExpectedDefaultParsingResult = 1;

        private IParsingResult<int> CreateSUT()
        {
            return new EmptyParsingResult<int>();
        }

        [Test]
        public void Should_get_default_value_after_parsing()
        {
            Assert.That(CreateSUT().Value, Is.EqualTo(default(int)));
        }

        [Test]
        public void Should_always_set_default_value()
        {
            var target = CreateSUT().Default(ExpectedDefaultParsingResult);
            Assert.That(target.Value, Is.EqualTo(ExpectedDefaultParsingResult));
        }

        [Test]
        public void Should_always_be_unsuccessful()
        {
            Assert.That(CreateSUT().WasSuccessful, Is.False);
        }

    }
}