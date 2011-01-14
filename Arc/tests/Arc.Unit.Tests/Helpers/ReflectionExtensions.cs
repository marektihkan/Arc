namespace Arc.Unit.Tests.Helpers
{
    public static class ReflectionExtensions
    {
        public static void SetValueTo(this object obj, string property, object value)
        {
            obj.GetType().GetProperty(property).SetValue(obj, value, null);
        }
    }
}