namespace Arc.Integration.Tests.Fakes.Model.Services
{
    public class GenericServiceHostImpl : IGenericServiceHost
    {
        public GenericServiceHostImpl(IGenericService<string> service)
        {
            Service = service;
        }

        public IGenericService<string> Service { get; set; }
    }
}