using System;

namespace Arc.Unit.Tests.Fakes.Factories
{
    public class GuidFactory
    {
        public static Guid Empty
        {
            get { return Guid.Empty; }
        }

        public static Guid One
        {
            get { return new Guid("11111111-1111-1111-1111-111111111111"); }
        }
        
        public static Guid Two
        {
            get { return new Guid("22222222-2222-2222-2222-222222222222"); }
        }
    }
}