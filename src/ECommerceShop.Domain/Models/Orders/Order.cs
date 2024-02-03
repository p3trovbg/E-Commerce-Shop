namespace ECommerceShop.Domain.Models.Orders;

using Common;
using Exceptions;

using static ModelConstants.Money;

public class Order : Entity<int>, IAggregateRoot
{
    private readonly HashSet<Product> products;

    internal Order(
        string address,
        decimal totalPrice,
        decimal totalDiscount,
        OrderStatus status,
        Recipient recipient)
    {
        this.Validate(address, totalPrice, totalDiscount);
        this.Address = address;
        this.TotalPrice = totalPrice;
        this.TotalDiscount = TotalDiscount;
        this.Status = status;
        this.Recipient = recipient;
        this.products = new HashSet<Product>();
    }

    public string Address { get; private set; }

    public decimal TotalPrice { get; private set; }

    public decimal TotalDiscount { get; private set; }

    public OrderStatus Status { get; private set; }

    public Recipient Recipient { get; private set; }

    public IReadOnlyCollection<Product> Products => this.products.ToList().AsReadOnly();

    private void Validate(
        string address,
        decimal totalPrice,
        decimal totalDiscount)
    {
        ValidateAddress(address);
        ValidateTotalPrice(totalPrice);
        ValidateTotalDiscount(totalDiscount);
    }

    public Order UpdateAddress(string address)
    {
        ValidateAddress(address);
        this.Address = address;
        return this;
    }

    public Order UpdateTotalPrice(decimal totalPrice)
    {
        ValidateTotalPrice(totalPrice);
        this.TotalPrice = totalPrice;
        return this;
    }

    public Order UpdateTotalDiscount(decimal totalDiscount)
    {
        UpdateTotalDiscount(totalDiscount);
        this.TotalDiscount = totalDiscount;
        return this;
    }

    public Order UpdateOrderStatus(OrderStatus status)
    {
        this.Status = status;
        return this;
    }

    public Order UpdateRecipient(string name, string phoneNumber, string email)
    {
        this.Recipient = new Recipient(name, phoneNumber, email);
        return this;
    }

    public void AddProduct(Product product) => this.products.Add(product);

    private void ValidateAddress(string address)
        => Guard.AgainstEmptyString<InvalidOrderException>(
            address,
            nameof(this.Address));

    private void ValidateTotalPrice(decimal totalPrice)
        => Guard.AgainstOutOfRange<InvalidOrderException>(
            totalPrice,
            MinAmount,
            MaxAmount,
            nameof(this.TotalPrice));

    private void ValidateTotalDiscount(decimal totalDiscount)
        => Guard.AgainstOutOfRange<InvalidOrderException>(
            totalDiscount,
            MinAmount,
            MaxAmount,
            nameof(this.TotalDiscount));
}
