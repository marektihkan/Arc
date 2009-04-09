namespace Arc.Learning.Tests.Fakes.Model
{
    public class HostObject2Impl : IHostObject2
    {
        public HostObject2Impl(ICreatedObject createdObject)
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