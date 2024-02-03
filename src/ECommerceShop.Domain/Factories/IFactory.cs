namespace ECommerceShop.Domain.Factories;

using ECommerceShop.Domain.Common;

public interface IFactory<out TEntity>
    where TEntity : IAggregateRoot
{
    TEntity Build();
}
