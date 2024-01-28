namespace ECommerceShop.Domain.Exceptions
{
    public class InvalidProductException : BaseDomainException
    {
        public InvalidProductException() { }

        public InvalidProductException(string error) => this.Error = error;
    }
}
