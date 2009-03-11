using System.Collections.Generic;
using Arc.Unit.Tests.Fakes;
using AutoMapper;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Arc.Infrastructure.Data;

namespace Arc.Unit.Tests.Infrastructure.Data
{
    [TestFixture]
    public class ObjectMapperExtensionsTests
    {
        private DomainObject _expected;

        [SetUp]
        public void SetUp()
        {
            Mapper.CreateMap<DomainObject, DomainObjectDto>();
            _expected = new DomainObject { Id = 1, Name = "Name" };
        }

        [Test]
        public void Should_map_list()
        {
            var list = new List<DomainObject> { _expected };

            var actual = list.MapTo<DomainObject, DomainObjectDto>();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual[0].Id, Is.EqualTo(_expected.Id));
            Assert.That(actual[0].Name, Is.EqualTo(_expected.Name));
        }

        [Test]
        public void Should_map_list_when_source_type_is_not_given()
        {
            var list = new List<DomainObject> { _expected };

            var actual = list.As<DomainObjectDto>();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual[0].Id, Is.EqualTo(_expected.Id));
            Assert.That(actual[0].Name, Is.EqualTo(_expected.Name));
        }

        [Test]
        public void Should_map_object_when_source_type_is_not_given()
        {
            var actual = _expected.As<DomainObjectDto>();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Id, Is.EqualTo(_expected.Id));
            Assert.That(actual.Name, Is.EqualTo(_expected.Name));
        }

        [Test]
        public void Should_map_object()
        {
            var actual = _expected.MapTo<DomainObject, DomainObjectDto>();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Id, Is.EqualTo(_expected.Id));
            Assert.That(actual.Name, Is.EqualTo(_expected.Name));
        }

        [Test]
        public void Should_map_object_to_destination_object()
        {
            var destination = new DomainObjectDto();
            var actual = _expected.MapTo(destination);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.SameAs(destination));
            Assert.That(actual.Id, Is.EqualTo(_expected.Id));
            Assert.That(actual.Name, Is.EqualTo(_expected.Name));
        }

        [Test]
        public void Should_map_object_to_destination_object_when_source_type_is_not_given()
        {
            var destination = new DomainObjectDto();
            var actual = _expected.As(destination);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.SameAs(destination));
            Assert.That(actual.Id, Is.EqualTo(_expected.Id));
            Assert.That(actual.Name, Is.EqualTo(_expected.Name));
        }

        //NOTE: Should test what happens on NHibernate proxies.
    }
}