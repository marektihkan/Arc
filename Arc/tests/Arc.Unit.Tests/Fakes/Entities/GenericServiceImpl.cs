namespace Arc.Unit.Tests.Fakes.Entities
{
	public class GenericServiceImpl : IGenericService<Person>, IGenericService<Email>
	{
		public void DoSomething(Person arg)
		{
		}

		public void DoSomething(Email arg)
		{
		}
	}
}