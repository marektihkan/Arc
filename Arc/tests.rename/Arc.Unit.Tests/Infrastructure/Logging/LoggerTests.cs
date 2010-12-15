using System;
using Arc.Infrastructure.Logging;
using Arc.Infrastructure.Logging.Log4Net;
using log4net;
using NUnit.Framework;
using Rhino.Mocks;

namespace Arc.Unit.Tests.Infrastructure.Logging
{
    [TestFixture]
    public class LoggerTests
    {
        private const string ExpectedMessage = "Message";
        private static readonly Exception ExpectedException = new Exception();
        private ILog _log;

        [SetUp]
        public void SetUp()
        {
            _log = MockRepository.GenerateMock<ILog>();
        }

        private ILogger CreateSUT()
        {
            return new Logger(_log);
        }

        [Test]
        public void Should_write_debug_information_to_log()
        {
            CreateSUT().Debug(ExpectedMessage);

            _log.AssertWasCalled(x => x.Debug(ExpectedMessage));
        }

        [Test]
        public void Should_write_debug_information_with_exception_to_log()
        {
            CreateSUT().Debug(ExpectedMessage, ExpectedException);

            _log.AssertWasCalled(x => x.Debug(ExpectedMessage, ExpectedException));
        }

        [Test]
        public void Should_write_information_to_log()
        {
            CreateSUT().Information(ExpectedMessage);

            _log.AssertWasCalled(x => x.Info(ExpectedMessage));
        }

        [Test]
        public void Should_write_information_with_exception_to_log()
        {
            CreateSUT().Information(ExpectedMessage, ExpectedException);

            _log.AssertWasCalled(x => x.Info(ExpectedMessage, ExpectedException));
        }

        [Test]
        public void Should_write_warning_information_to_log()
        {
            CreateSUT().Warning(ExpectedMessage);

            _log.AssertWasCalled(x => x.Warn(ExpectedMessage));
        }

        [Test]
        public void Should_write_warning_information_with_exception_to_log()
        {
            CreateSUT().Warning(ExpectedMessage, ExpectedException);

            _log.AssertWasCalled(x => x.Warn(ExpectedMessage, ExpectedException));
        }

        [Test]
        public void Should_write_error_information_to_log()
        {
            CreateSUT().Error(ExpectedMessage);

            _log.AssertWasCalled(x => x.Error(ExpectedMessage));
        }

        [Test]
        public void Should_write_error_information_with_exception_to_log()
        {
            CreateSUT().Error(ExpectedMessage, ExpectedException);

            _log.AssertWasCalled(x => x.Error(ExpectedMessage, ExpectedException));
        }

        [Test]
        public void Should_write_fatal_error_information_to_log()
        {
            CreateSUT().Fatal(ExpectedMessage);

            _log.AssertWasCalled(x => x.Fatal(ExpectedMessage));
        }

        [Test]
        public void Should_write_fatal_error_information_with_exception_to_log()
        {
            CreateSUT().Fatal(ExpectedMessage, ExpectedException);

            _log.AssertWasCalled(x => x.Fatal(ExpectedMessage, ExpectedException));
        }
    }
}