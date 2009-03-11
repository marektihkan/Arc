namespace Arc.Unit.Tests.Fakes.Entities
{
    public interface IService
    {
        void DoSomething();
    }

    class ServiceImpl : IService
    {
        public void DoSomething()
        {
        }
    }
}