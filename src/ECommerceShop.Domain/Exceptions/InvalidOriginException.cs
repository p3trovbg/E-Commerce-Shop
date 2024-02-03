namespace ECommerceShop.Domain.Exceptions;

public class InvalidOriginException : BaseDomainException
{
    public InvalidOriginException() { }

    public InvalidOriginException(string error) => this.Error = error;
}
