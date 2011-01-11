using Arc.Infrastructure.Data;

namespace Arc.Unit.Tests.Fakes.Data
{
    public class Repository
    {
        public IRepository InnerRepository { get; set; }

        public Repository(IRepository repository)
        {
            InnerRepository = repository;
        }

        public IRepository GetInnerRepository()
        {
            return InnerRepository;
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return InnerRepository.UnitOfWork;
        }
    }
}