namespace ECommerceShop.Domain.Models.Products;

using Common;
using Exceptions;

using static ModelConstants.Category;

public class Category : Entity<int>
{
    internal Category(string name, string description)
    {
        Validate(name, description);
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    private void Validate(string name, string description)
    {
        this.ValidateName(name);
        this.ValidateDescription(description);
    }

    private void ValidateName(string name)
        => Guard.ForStringLength<InvalidCategoryException>(
            name,
            MinNameLength,
            MaxNameLength,
            nameof(this.Name));

    private void ValidateDescription(string description)
        => Guard.ForStringLength<InvalidCategoryException>(
            description,
            MinDescriptionLength,
            MaxDescriptionLength,
            nameof(this.Description));
}
