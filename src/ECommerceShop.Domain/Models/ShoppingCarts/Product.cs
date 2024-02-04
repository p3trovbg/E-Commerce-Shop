namespace ECommerceShop.Domain.Models.ShoppingCarts;

using Common;
using Exceptions;

using static ModelConstants.Product;
using static ModelConstants.Money;

public class Product : Entity<int>
{
    internal Product(string name, decimal price, int quantity, string imagePath, bool isAvaliable) 
    {
        Validate(name, price, quantity, imagePath);
        this.Name = name;
        this.Price = price;
        this.Quantity = quantity;
        this.ImagePath = imagePath;
        this.IsAvaliable = isAvaliable;
    }

    public string Name { get; private set; }

    public decimal Price { get; private set; }

    public int Quantity { get; private set; }

    public string ImagePath { get; private set; }

    public bool IsAvaliable { get; private set; }


    private void Validate(string name, decimal price, int quantity, string imagePath)
    {
        ValidateName(name);
        ValidatePrice(price);
        ValidateQuantity(quantity);
        ValidateImagePath(imagePath);
    }

    private void ValidateName(string name)
    {
        throw new NotImplementedException();
    }

    private void ValidatePrice(decimal price)
        => Guard.AgainstOutOfRange<InvalidProductException>(
            price,
            MinAmount,
            MaxAmount,
            nameof(this.Price));

    private void ValidateQuantity(int quantity)
        => Guard.AgainstOutOfRange<InvalidProductException>(
            quantity,
            MinQuantity,
            MaxQuantity,
            nameof(this.Quantity));

    private void ValidateImagePath(string imagePath)
        => Guard.AgainstEmptyString<InvalidImageException>(
            imagePath,
            nameof(this.ImagePath));
}
