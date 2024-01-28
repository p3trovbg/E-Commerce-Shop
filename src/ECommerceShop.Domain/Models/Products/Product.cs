namespace ECommerceShop.Domain.Models.Products
{
    using ECommerceShop.Domain.Common;
    using ECommerceShop.Domain.Exceptions;

    using static ModelConstants.Product;

    public class Product : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Review> reviews;
        private readonly HashSet<Image> images;

        internal Product(
            string name,
            string description,
            int quantity,
            Origin origin,
            Money money,
            Image mainImage,
            Category category)
        {
            this.Validate(name, description, quantity);
            this.Name = name;
            this.Description = description;
            this.Quantity = quantity;
            this.Origin = origin;
            this.Money = money;
            this.MainImage = mainImage;
            this.Category = category;
            this.reviews = new HashSet<Review>();
            this.images = new HashSet<Image>();
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public int Quantity { get; private set; }

        public Origin Origin { get; private set; }

        public Money Money { get; private set; }

        public Image MainImage { get; private set; }

        public Category Category { get; private set; }

        public IReadOnlyCollection<Review> Reviews => this.reviews.ToList().AsReadOnly();

        public IReadOnlyCollection<Image> Images => this.images.ToList().AsReadOnly();

        private void Validate(
            string name,
            string description,
            int quantity)
        {
            this.ValidateName(name);
            this.ValidateDescription(description);
            this.ValidateQuantity(quantity);
        }

        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidProductException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

        private void ValidateDescription(string description)
            => Guard.ForStringLength<InvalidProductException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(this.Description));

        private void ValidateQuantity(int quantity)
            => Guard.AgainstOutOfRange<InvalidProductException>(
                quantity,
                MinQuantity,
                MaxQuantity,
                nameof(this.Quantity));
    }
}
