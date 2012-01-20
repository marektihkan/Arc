namespace Arc.Unit.Tests.Fakes.Entities
{
	public interface IGenericService<T>
	{
		void DoSomething(T arg);
	}
}