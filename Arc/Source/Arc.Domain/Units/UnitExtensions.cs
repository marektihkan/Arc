namespace Arc.Domain.Units
{
    public static class UnitExtensions
    {
        public static Money AsMoney(this decimal amount)
        {
            return new Money(amount);
        }
        
        public static Money AsMoney(this int amount)
        {
            return new Money(amount);
        }

        public static Money InCurrency(this decimal amount, Currency currency)
        {
            return new Money(amount, currency);
        }

        public static Money InCurrency(this int amount, Currency currency)
        {
            return new Money(amount, currency);
        }

        public static Quantity AsQuantity(this decimal amount)
        {
            return new Quantity(amount);
        }

        public static Quantity AsQuantity(this int amount)
        {
            return new Quantity(amount);
        }
    }
}