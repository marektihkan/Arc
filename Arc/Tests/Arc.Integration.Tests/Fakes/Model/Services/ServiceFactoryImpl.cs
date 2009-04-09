namespace Arc.Integration.Tests.Fakes.Model.Services
{
    public class ServiceFactoryImpl : IServiceFactory
    {
        public IParameterlessService Create()
        {
            return new ParameterlessServiceImpl();
        }
    }
}