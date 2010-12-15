namespace Arc.Unit.Tests.Fakes
{
    public class DummyReflection
    {
        private int _field;

        private int Property { get; set; }
        
        public int PropertyValue
        {
            get { return Property; }
        }
        
        public int FieldValue
        {
            get { return _field; }
        }
    }
}