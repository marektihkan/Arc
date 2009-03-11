using System;
using Arc.Domain.Dsl;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Arc.Unit.Tests.Domain.Dsl
{
    [TestFixture]
    public class DslTests
    {
        private void ThrowInvalidOperationException()
        {
            throw new InvalidOperationException();
        }


        [Test]
        public void Should_execute_action_when_condition_is_true()
        {
            var actionWasCalled = false;

            Should.Do(() => actionWasCalled = true).When(true);

            Assert.That(actionWasCalled, Is.True);
        }

        [Test]
        public void Should_not_execute_action_when_condition_is_false()
        {
            var actionWasCalled = false;

            Should.Do(() => actionWasCalled = true).When(false);

            Assert.That(actionWasCalled, Is.False);
        }

        [Test]
        public void Should_execute_action_unless_condition_is_false()
        {
            var actionWasCalled = false;

            Should.Do(() => actionWasCalled = true).Unless(false);

            Assert.That(actionWasCalled, Is.True);
        }

        [Test]
        public void Should_not_execute_action_unless_condition_is_true()
        {
            var actionWasCalled = false;

            Should.Do(() => actionWasCalled = true).Unless(true);

            Assert.That(actionWasCalled, Is.False);
        }

        [Test]
        public void Should_execute_recovery_action_when_specified_exception_occurs()
        {
            var recoveryWasCalled = false;

            Should.Do(ThrowInvalidOperationException).On<InvalidOperationException>(x => recoveryWasCalled = true);

            Assert.That(recoveryWasCalled, Is.True);
        }

        [Test]
        public void Should_not_execute_recovery_action_when_exception_does_not_occur()
        {
            var actionWasCalled = false;
            var recoveryWasCalled = false;

            Should.Do(() => actionWasCalled = true).On<Exception>(x => recoveryWasCalled = true);

            Assert.That(actionWasCalled, Is.True);
            Assert.That(recoveryWasCalled, Is.False);
        }

        [Test]
        [ExpectedException(typeof (InvalidOperationException))]
        public void Should_throw_exception_when_note_expected_exception_occurs()
        {
            var recoveryWasCalled = false;

            Should.Do(ThrowInvalidOperationException).On<ArgumentNullException>(x => recoveryWasCalled = true);

            Assert.That(recoveryWasCalled, Is.False);
        }
    }
}