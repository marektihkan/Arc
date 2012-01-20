using System;
using Arc.Infrastructure.Utilities;
using Arc.Unit.Tests.Fakes.Entities;
using NUnit.Framework;

namespace Arc.Unit.Tests.Infrastructure.Utilities
{
    [TestFixture]
    public class FindTests
    {
        private const string ValidTypeName = "Arc.Unit.Tests.Fakes.Entities.ServiceImpl, Arc.Unit.Tests";
        private const string ValidGenericTypeName = "Arc.Unit.Tests.Fakes.Entities.GenericServiceImpl, Arc.Unit.Tests";
        private const string InvalidTypeName = "Arc.Unit.Tests.Fakes.Entities.Service, Arc.Unit.Tests";
        private const string TypeWithoutInterfaceName = "Arc.Unit.Tests.Fakes.Entities.Person, Arc.Unit.Tests";


        [Test]
        public void Should_find_specified_type()
        {
            var actual = Find.Type(ValidTypeName);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.EqualTo(typeof(ServiceImpl)));
        }

        [Test]
        public void Should_find_specified_type_with_interface()
        {
            var actual = Find.TypeWithInterface<IService>(ValidTypeName);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.EqualTo(typeof(ServiceImpl)));
        }

    	[Test]
    	public void Should_find_specified_type_with_generic_interface()
    	{
			var actual = Find.TypeWithInterface<IGenericService<Person>>(ValidGenericTypeName);

			Assert.That(actual, Is.Not.Null);
			Assert.That(actual, Is.EqualTo(typeof(GenericServiceImpl)));
    	}

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void Should_thorw_argument_exception_when_type_is_not_found()
        {
            Find.Type(InvalidTypeName);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void Should_throw_argument_exception_when_type_doesnt_implemet_specified_interface()
        {
            Find.TypeWithInterface<IService>(TypeWithoutInterfaceName);
        }
    }
}