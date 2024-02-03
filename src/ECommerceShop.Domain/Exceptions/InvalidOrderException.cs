namespace ECommerceShop.Domain.Exceptions;

public class InvalidOrderException : BaseDomainException
{
    public InvalidOrderException() { }

    public InvalidOrderException(string error) => this.Error = error;
}
