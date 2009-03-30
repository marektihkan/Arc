namespace Arc.Integration.Tests.Fakes.Model.Services
{
    public interface IGenericServiceHost
    {
        IGenericService<string> Service { get; }
    }
}