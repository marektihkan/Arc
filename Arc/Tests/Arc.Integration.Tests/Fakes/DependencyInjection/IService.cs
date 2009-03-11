namespace Arc.Integration.Tests.Fakes.DependencyInjection
{
    public interface IService
    {
        IParameterlessService Dependency { get; }
    }
}