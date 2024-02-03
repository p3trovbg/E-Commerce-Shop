namespace ECommerceShop.Domain.Models.Payments;

using ECommerceShop.Domain.Common;

public class PaymentStatus : Enumeration
{
    public static readonly PaymentStatus NotConfirmed = new PaymentStatus(1, nameof(NotConfirmed));
    public static readonly PaymentStatus Pending = new PaymentStatus(2, nameof(Pending));
    public static readonly PaymentStatus Confirmed = new PaymentStatus(3, nameof(Confirmed));
    public static readonly PaymentStatus Success = new PaymentStatus(4, nameof(Success));
    public static readonly PaymentStatus Rejected = new PaymentStatus(5, nameof(Rejected));
    public static readonly PaymentStatus Expired = new PaymentStatus(6, nameof(Expired));
    public static readonly PaymentStatus Refunded = new PaymentStatus(7, nameof(Refunded));

    private PaymentStatus(int value) : this(value, FromValue<PaymentType>(value).Name)
    {
    }

    private PaymentStatus(int value, string name) : base(value, name)
    {
    }
}
