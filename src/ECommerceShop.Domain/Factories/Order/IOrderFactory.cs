namespace ECommerceShop.Domain.Factories.Order;

using Models.Orders;

public interface IOrderFactory : IFactory<Order>
{
    IOrderFactory WithAddress(string address);

    IOrderFactory WithTotalPrice(decimal totalPrice);

    IOrderFactory WithTotalDiscount(decimal totalDiscount);

    IOrderFactory WithOrderStatus(OrderStatus status);

    IOrderFactory WithRecipient(string name, string phoneNumber, string email);

    IOrderFactory WithRecipient(Recipient recipient);
}
