namespace ECommerceShop.Domain.Factories.Order;

using Exceptions;
using Models.Orders;

internal class OrderFactory : IOrderFactory
{
    private string address = default!;
    private decimal totalPrice = default!;
    private decimal totalDiscount = default!;
    private OrderStatus status = default!;
    private Recipient recipient = default!;

    private bool recipientSet = false;

    public IOrderFactory WithAddress(string address)
    {
        this.address = address;
        return this;
    }

    public IOrderFactory WithTotalPrice(decimal totalPrice) 
    {
        this.totalPrice = totalPrice;
        return this;
    }

    public IOrderFactory WithTotalDiscount(decimal totalDiscount)
    {
        this.totalDiscount = totalDiscount;
        return this;
    }

    public IOrderFactory WithOrderStatus (OrderStatus status)
    {
        this.status = status;
        return this;
    }

    public IOrderFactory WithRecipient(string name, string phoneNumber, string email)
        => WithRecipient(new Recipient(name, phoneNumber, email));

    public IOrderFactory WithRecipient(Recipient recipient)
    {
        this.recipientSet = true;
        this.recipient = recipient;
        return this;
    }

    public Order Build()
    {
        ValidateSets();
        return new Order(
            this.address,
            this.totalPrice,
            this.totalDiscount,
            this.status,
            this.recipient);
    }

    private void ValidateSets()
    {
        if (!this.recipientSet)
        {
            throw new InvalidOrderException();
        }
    }
}
