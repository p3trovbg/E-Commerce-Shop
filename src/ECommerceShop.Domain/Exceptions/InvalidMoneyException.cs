namespace ECommerceShop.Domain.Exceptions;

public class InvalidMoneyException : BaseDomainException
{
    public InvalidMoneyException() { }

    public InvalidMoneyException(string error) => this.Error = error;
}
