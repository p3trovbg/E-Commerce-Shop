namespace ECommerceShop.Domain.Models.Payments;

using Common;

public class PaymentType : Enumeration
{
    public static readonly PaymentType Cash = new PaymentType(1, nameof(Cash));
    public static readonly PaymentType BankWire = new PaymentType(2, nameof(BankWire));
    public static readonly PaymentType OnlineWithCreditCard = new PaymentType(3, nameof(OnlineWithCreditCard));

    private PaymentType(int value) : this(value, FromValue<PaymentStatus>(value).Name)
    {
    }

    private PaymentType(int value, string name) : base(value, name)
    {
    }
}
