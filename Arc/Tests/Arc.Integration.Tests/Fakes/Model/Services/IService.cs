namespace Arc.Integration.Tests.Fakes.Model.Services
{
    public interface IService
    {
        IParameterlessService Dependency { get; }
    }
}