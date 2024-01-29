namespace ECommerceShop.Domain.Models.Products
{
    using ECommerceShop.Domain.Common;
    using ECommerceShop.Domain.Exceptions;

    using static ModelConstants.Money;

    public class Money : ValueObject
    {
        internal Money(decimal amount, Currency currency)
        {
            Validate(amount);
            Amount = amount;
            Currency = currency;
        }

        public decimal Amount { get; private set; }

        public Currency Currency { get; private set; }

        private void Validate(decimal amount)
            => Guard.AgainstOutOfRange<InvalidMoneyException>(
                amount,
                MinAmount,
                MaxAmount,
                nameof(this.Amount));
    }
}