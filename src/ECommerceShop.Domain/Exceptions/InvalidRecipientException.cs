namespace ECommerceShop.Domain.Exceptions;

public class InvalidRecipientException : BaseDomainException
{
    public InvalidRecipientException() { }

    public InvalidRecipientException(string error) => this.Error = error;
}
