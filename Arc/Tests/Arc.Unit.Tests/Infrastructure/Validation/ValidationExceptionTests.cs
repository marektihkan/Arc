using System;
using Arc.Infrastructure.Validation;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;

namespace Arc.Unit.Tests.Infrastructure.Validation
{
    [TestFixture]
    public class ValidationExceptionTests
    {
        private IValidationResults _validationResults;

        [SetUp]
        public void SetUp()
        {
            _validationResults = MockRepository.GenerateMock<IValidationResults>();
        }

        private ValidationException CreateSUT()
        {
            return new ValidationException(_validationResults);
        }

        [Test]
        public void Exception_message_should_return_validation_results_summary()
        {
            var expected = "Errors Summary";

            _validationResults.Stub(x => x.Summary).Return(expected);

            var actual = CreateSUT().Message;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_have_empty_constructor()
        {
            var target = new ValidationException();

            Assert.That(target, Is.Not.Null);
        }

        [Test]
        public void Should_have_constructor_with_error_message()
        {
            var expectedMessage = "Message";
            
            var target = new ValidationException(expectedMessage);

            Assert.That(target, Is.Not.Null);
            Assert.That(target.Message, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void Should_have_constructor_with_error_message_and_inner_exception()
        {
            var expectedMessage = "Message";
            var expectedInnerException = new Exception("Inner Message");

            var target = new ValidationException(expectedMessage, expectedInnerException);

            Assert.That(target, Is.Not.Null);
            Assert.That(target.Message, Is.EqualTo(expectedMessage));
            Assert.That(target.InnerException, Is.SameAs(expectedInnerException));
        }
    }
}