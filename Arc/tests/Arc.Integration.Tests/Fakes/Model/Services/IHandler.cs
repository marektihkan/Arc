namespace Arc.Integration.Tests.Fakes.Model.Services
{
	public interface IHandler<T>
	{
		void Handle(T obj);
	}
}