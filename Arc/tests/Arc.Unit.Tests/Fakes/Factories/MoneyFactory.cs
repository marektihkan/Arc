using Arc.Domain.Units;

namespace Arc.Unit.Tests.Fakes.Factories
{
    public class MoneyFactory
    {
        public static Money ZeroEUR
        {
            get { return new Money(0, Currency.EUR); }
        }

        public static Money OneEUR
        {
            get { return new Money(1, Currency.EUR); }
        }

        public static Money TwoEUR
        {
            get { return new Money(2, Currency.EUR); }
        }

        public static Money ZeroUSD
        {
            get { return new Money(0, Currency.USD); }
        }

        public static Money OneUSD
        {
            get { return new Money(1, Currency.USD); }
        }

        public static Money TwoUSD
        {
            get { return new Money(2, Currency.USD); }
        }

        public static Money OneEEK
        {
            get { return new Money(1, Currency.EEK); }
        }
    }
}