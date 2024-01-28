namespace ECommerceShop.Domain.Exceptions
{
    internal class InvalidCategoryException : BaseDomainException
    {
        public InvalidCategoryException() { }

        public InvalidCategoryException(string error) => this.Error = error;
    }
}
