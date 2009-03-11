using Arc.Domain.Dsl.Parsing;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Unit.Tests.Domain.Dsl.Parsing
{
    [TestFixture]
    public class ParsingResultTests
    {
        private const int ExpectedParsingResult = 1;
        private const int ExpectedDefaultParsingResult = 1;

        private IParsingResult<int> CreateSUT()
        {
            return new ParsingResult<int>(ExpectedParsingResult);
        }

        [Test]
        public void Should_get_paring_result_value()
        {
            Assert.That(CreateSUT().Value, Is.EqualTo(ExpectedParsingResult));
        }

        [Test]
        public void Should_not_set_default_value()
        {
            var target = CreateSUT().Default(ExpectedDefaultParsingResult);
            Assert.That(target.Value, Is.EqualTo(ExpectedParsingResult));
        }

        [Test]
        public void Should_have_always_successful_parsing()
        {
            var target = CreateSUT().Default(ExpectedDefaultParsingResult);
            Assert.That(target.WasSuccessful, Is.True);
        }
    }
}