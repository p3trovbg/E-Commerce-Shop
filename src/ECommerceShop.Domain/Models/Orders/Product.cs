namespace ECommerceShop.Domain.Models.Orders;

using Common;
using Exceptions;

using static ModelConstants.Product;
using static ModelConstants.Money;

public class Product : Entity<int>
{
    internal Product(
        string name,
        string code,
        int quantity,
        decimal price,
        decimal discount)
    {
        Validate(name, code, quantity, price, discount);
        this.Name = name;
        this.Code = code;
        this.Quantity = quantity;
        this.Price = price;
        this.Discount = discount;
    }

    public string Name { get; private set; }

    public string Code { get; private set; }

    public int Quantity { get; private set; }

    public decimal Price { get; private set; }

    public decimal Discount { get; private set; }

    private void Validate(
        string name,
        string code,
        int quantity,
        decimal price,
        decimal discount)
    {
        ValidateName(name);
        ValidateCode(code);
        ValidateQuantity(quantity);
        ValidatePrice(price);
        ValidateDiscount(discount);
    }

    private void ValidateName(string name)
        => Guard.ForStringLength<InvalidProductException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));

    private void ValidateCode(string code)
        => Guard.AgainstEmptyString<InvalidProductException>(
            code,
            nameof(this.Code));

    private void ValidateQuantity(int quantity)
        => Guard.AgainstOutOfRange<InvalidProductException>(
            quantity,
            MinQuantity,
            MaxQuantity,
            nameof(this.Quantity));

    private void ValidatePrice(decimal price)
        => Guard.AgainstOutOfRange<InvalidMoneyException>(
            price,
            MinAmount,
            MaxAmount,
            nameof(this.Price));

    private void ValidateDiscount(decimal discount)
        => Guard.AgainstOutOfRange<InvalidMoneyException>(
            discount,
            MinAmount,
            MaxAmount,
            nameof(this.Discount));
}
