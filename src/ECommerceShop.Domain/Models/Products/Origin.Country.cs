namespace ECommerceShop.Domain.Models.Products
{
    using Common;

    internal class OriginCountryData : IInitialData
    {
        public Type EntityType => typeof(string);

        // For testing purposes
        public IEnumerable<object> GetData()
            => new List<string>
            {
                "Bulgaria",
                "Turkey",
                "Romania",
                "Japan",
                "China",
            };
    }
}
