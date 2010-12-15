using Arc.Domain.Dsl;
using Arc.Infrastructure.Mapping;
using Arc.Integration.Tests.Fakes;
using NUnit.Framework;
using System.Linq;

namespace Arc.Integration.Tests.Infrastructure.Mapping
{
    public abstract class MappingTests
    {
        private DomainObject _source;
        private DomainObjectDto _destination;

        public abstract IMapper CreateSUT();
        public abstract void SetupMappings();


        private void assertMappings(DomainObjectDto actual, DomainObjectDto expected)
        {
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Id, Is.EqualTo(expected.Id));
            Assert.That(actual.Name, Is.EqualTo(expected.Name));
        }

        [SetUp]
        public void SetUp()
        {
            SetupMappings();
            _source = new DomainObject { Id = 1, Name = "Name" };
            _destination = new DomainObjectDto { Id = 1, Name = "Name" };
        }

        [Test]
        public void Should_map_when_source_and_destination_are_generics()
        {
            var target = CreateSUT();
            var actual = target.Map<DomainObject, DomainObjectDto>(_source);
            assertMappings(actual, _destination);
        }

        [Test]
        public void Should_map_when_source_and_destination_are_generics_with_destination()
        {
            var target = CreateSUT();
            var actual = new DomainObjectDto();
            actual = target.Map<DomainObject, DomainObjectDto>(_source, actual);
            assertMappings(actual, _destination);
        }

        [Test]
        public void Should_map_when_source_and_destination_are_types()
        {
            var target = CreateSUT();
            var actual = target.Map(_source, typeof(DomainObject), typeof(DomainObjectDto)) as DomainObjectDto;
            assertMappings(actual, _destination);
        }

        [Test]
        public void Should_map_when_source_and_destination_are_types_with_destination()
        {
            var target = CreateSUT();
            var actual = new DomainObjectDto();
            actual = target.Map(_source, typeof(DomainObject), actual, typeof(DomainObjectDto)) as DomainObjectDto;
            assertMappings(actual, _destination);
        }

        [Test]
        public void Should_map_collections_when_source_and_destination_are_generics()
        {
            var target = CreateSUT();
            var sources = new[] {_source};
            var expected = new[] {_destination};
            var destinations = target.Map<DomainObject, DomainObjectDto>(sources).ToArray();
            var mappingsCount = sources.Length;
            mappingsCount.Times(index => assertMappings(destinations[index], expected[index]));
        }

        [Test]
        public void Should_map_collections_when_source_and_destination_are_types()
        {
            var target = CreateSUT();
            var sources = new[] { _source };
            var destinations = target.Map(sources, typeof(DomainObject), typeof(DomainObjectDto));
            foreach (DomainObjectDto destination in destinations)
            {
                assertMappings(destination, _destination);
            }
        }
    }
}