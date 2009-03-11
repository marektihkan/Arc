namespace Arc.Integration.Tests.Fakes.DependencyInjection
{
    internal class ServiceImpl : IService
    {
        private readonly IParameterlessService _dependency;


        public ServiceImpl(IParameterlessService dependency)
        {
            _dependency = dependency;
        }


        public IParameterlessService Dependency
        {
            get { return _dependency; }
        }
    }
}