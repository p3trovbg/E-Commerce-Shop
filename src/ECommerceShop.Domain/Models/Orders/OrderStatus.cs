namespace ECommerceShop.Domain.Models.Orders;

using Common;

public class OrderStatus : Enumeration
{
    public static readonly OrderStatus Pending = new OrderStatus(1, nameof(Pending));
    public static readonly OrderStatus Confirmed = new OrderStatus(2, nameof(Confirmed));
    public static readonly OrderStatus Success = new OrderStatus(3, nameof(Success));
    public static readonly OrderStatus Rejected = new OrderStatus(3, nameof(Rejected));
    public static readonly OrderStatus Expired = new OrderStatus(3, nameof(Expired));

    private OrderStatus(int value) : this(value, FromValue<OrderStatus>(value).Name)
    {
    }

    private OrderStatus(int value, string name) : base(value, name)
    {
    }
}
