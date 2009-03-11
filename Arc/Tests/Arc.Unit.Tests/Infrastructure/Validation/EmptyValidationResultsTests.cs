using Arc.Infrastructure.Validation;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Unit.Tests.Infrastructure.Validation
{
    [TestFixture]
    public class EmptyValidationResultsTests
    {

        private EmptyValidationResults CreateSUT()
        {
            return new EmptyValidationResults();
        }

        [Test]
        public void Validation_results_should_be_always_valid()
        {
            Assert.That(CreateSUT().IsValid, Is.True);
        }

        [Test]
        public void Validation_results_summary_should_be_always_empty()
        {
            Assert.That(CreateSUT().Summary, Is.Empty);
        }

        [Test]
        public void Validation_results_should_not_contain_any_messages()
        {
            var actual = CreateSUT().GetMessagesFor(string.Empty);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Length, Is.EqualTo(0));
        }

        [Test]
        public void Validation_results_should_not_return_first_message_for_given_field()
        {
            var actual = CreateSUT().GetFirstMessageFor(string.Empty);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Length, Is.EqualTo(0));
        }

    }
}