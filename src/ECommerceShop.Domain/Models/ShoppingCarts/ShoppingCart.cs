namespace ECommerceShop.Domain.Models.ShoppingCarts;

using Common;
using Exceptions;

using static ModelConstants.Money;

public class ShoppingCart : Entity<int>, IAggregateRoot
{
    private readonly HashSet<Product> products;

    internal ShoppingCart(decimal totalPrice)
    {
        Validate(totalPrice);
        this.TotalPrice = totalPrice;
        this.products = new HashSet<Product>();
    }

    public decimal TotalPrice { get; private set; }

    public IReadOnlyCollection<Product> Products => this.products.ToList().AsReadOnly();

    public void AddProduct(Product product) => this.products.Add(product);

    public ShoppingCart UpdateTotalPrice(decimal totalPrice)
    {
        ValidateTotalPrice(totalPrice);
        this.TotalPrice = totalPrice;
        return this;
    }

    private void Validate(decimal totalPrice)
    {
        ValidateTotalPrice(totalPrice);
    }

    private void ValidateTotalPrice(decimal totalPrice)
        => Guard.AgainstOutOfRange<InvalidMoneyException>(
            totalPrice,
            MinAmount,
            MaxAmount,
            nameof(this.TotalPrice));
}
