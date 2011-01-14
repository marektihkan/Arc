using Arc.Domain.Units;

namespace Arc.Unit.Tests.Fakes.Units
{
    public class RangeTester<T> : BaseRange<T>
    {
        public RangeTester() { }

        public RangeTester(T lower, T upper) : base(lower, upper) { }

        public override bool Contains(T element)
        {
            return false;
        }

        public override bool Contains(BaseRange<T> range)
        {
            return false;
        }
    }
}