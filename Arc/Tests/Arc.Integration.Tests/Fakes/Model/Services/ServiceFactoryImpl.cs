namespace Arc.Integration.Tests.Fakes.Model.Services
{
    public class ServiceFactoryImpl : IServiceFactory
    {
        public string Name { get; set; }

        public IParameterlessService Create()
        {
            return new ParameterlessServiceImpl();
        }
    }
}