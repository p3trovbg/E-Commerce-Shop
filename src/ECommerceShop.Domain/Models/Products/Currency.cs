namespace ECommerceShop.Domain.Models.Products
{
    using ECommerceShop.Domain.Common;

    public class Currency : Enumeration
    {
        public static readonly Currency BGN = new Currency(1, nameof(BGN));
        public static readonly Currency USD = new Currency(2, nameof(USD));

        private Currency(int value)
            : this(value, FromValue<Currency>(value).Name)
        {
        }

        private Currency(int value, string name)
            : base(value, name)
        {
        }
    }
}
