using Arc.Infrastructure.Mapping;
using Arc.Integration.Tests.Fakes;
using AutoMapper;
using NUnit.Framework;

namespace Arc.Integration.Tests.Infrastructure.Mapping
{
    [TestFixture]
    public class AutoMapperMappingTests : MappingTests
    {
        public override IMapper CreateSUT()
        {
            return new Arc.Infrastructure.Mapping.AutoMapper.Mapper();
        }

        public override void SetupMappings()
        {
            Mapper.CreateMap<DomainObject, DomainObjectDto>();
        }
    }
}