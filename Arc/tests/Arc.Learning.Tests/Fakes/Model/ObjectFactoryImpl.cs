namespace Arc.Learning.Tests.Fakes.Model
{
    public class ObjectFactoryImpl : IObjectFactory
    {
        public ICreatedObject Create()
        {
            return new CreatedObjectImpl();
        }
    }
}