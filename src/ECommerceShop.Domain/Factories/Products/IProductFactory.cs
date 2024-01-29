namespace ECommerceShop.Domain.Factories.Products
{
    using Models.Products;

    public interface IProductFactory : IFactory<Product>
    {
        IProductFactory WithName(string name);

        IProductFactory WithDescription(string description);

        IProductFactory WithQuantity(int quantity);

        IProductFactory WithOrigin(string model, string code, string country, int year);

        IProductFactory WithOrigin(Origin origin);

        IProductFactory WithMoney(decimal amount, Currency currency);

        IProductFactory WithMoney(Money money);

        IProductFactory WithImage(string path, string extension, int sizeInKilobytes);

        IProductFactory WithImage(Image image);

        IProductFactory WithCategory(string name, string description);

        IProductFactory WithCategory(Category category);
    }
}