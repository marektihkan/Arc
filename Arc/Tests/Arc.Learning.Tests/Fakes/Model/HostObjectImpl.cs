namespace Arc.Learning.Tests.Fakes.Model
{
    public class HostObjectImpl : IHostObject
    {
        public HostObjectImpl(ICreatedObject createdObject)
        {
            CreatedObject = createdObject;
        }

        public ICreatedObject CreatedObject
        {
            get;
            set;
        }
    }
}