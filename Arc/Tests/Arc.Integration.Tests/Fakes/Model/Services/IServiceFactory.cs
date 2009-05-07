namespace Arc.Integration.Tests.Fakes.Model.Services
{
    public interface IServiceFactory
    {
        IParameterlessService Create();
        string Name { get; set; }
    }
}