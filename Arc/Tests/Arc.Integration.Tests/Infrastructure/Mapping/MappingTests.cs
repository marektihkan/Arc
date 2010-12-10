using Arc.Infrastructure.Mapping;
using Arc.Integration.Tests.Fakes;
using AutoMapper;
using NUnit.Framework;

namespace Arc.Integration.Tests.Infrastructure.Mapping
{
    [TestFixture]
    public class MappingTests
    {
        private DomainObject _source;
        private DomainObjectDto _destination;

        public IMapper CreateSUT()
        {
            return new Arc.Infrastructure.Mapping.AutoMapper.Mapper(); 
        }

        private void assertMappings(DomainObjectDto actual, DomainObjectDto expected)
        {
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Id, Is.EqualTo(expected.Id));
            Assert.That(actual.Name, Is.EqualTo(expected.Name));
        }

        [SetUp]
        public void SetUp()
        {
            Mapper.CreateMap<DomainObject, DomainObjectDto>();
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
    }
}