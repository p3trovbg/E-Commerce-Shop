namespace ECommerceShop.Domain.Factories.Products
{
    using Exceptions;
    using Models.Products;

    internal class ProductFactory : IProductFactory
    {
        private string name = default!;
        private string description = default!;
        private int quantity = default!;
        private Origin origin = default!;
        private Money money = default!;
        private Image mainImage = default!;
        private Category category = default!;

        private bool originSet = false;
        private bool moneySet = false;
        private bool imageSet = false;
        private bool categorySet = false;

        public IProductFactory WithName(string name)
        {
            this.name = name;
            return this;
        }

        public IProductFactory WithDescription(string description)
        {  
            this.description = description;
            return this;
        }

        public IProductFactory WithQuantity(int quantity)
        {
            this.quantity = quantity;
            return this;
        }

        public IProductFactory WithOrigin(string model, string code, string country, int year)
            => this.WithOrigin(new Origin(model, code, country, year));

        public IProductFactory WithOrigin(Origin origin)
        {
            this.originSet = true;
            this.origin = origin;
            return this;
        }

        public IProductFactory WithMoney(decimal amount, Currency currency)
            => this.WithMoney(new Money(amount, currency));

        public IProductFactory WithMoney(Money money)
        {
            this.moneySet = true;
            this.money = money;
            return this;
        }

        public IProductFactory WithImage(string path, string extension, int sizeInKilobytes)
            => this.WithImage(new Image(path, extension, sizeInKilobytes));

        public IProductFactory WithImage(Image image)
        {
            this.imageSet = true;
            this.mainImage = image;
            return this;
        }

        public IProductFactory WithCategory(string name, string description)
            => this.WithCategory(new Category(name, description));

        public IProductFactory WithCategory(Category category)
        {
            this.categorySet = true;
            this.category = category;
            return this;
        }

        public Product Build()
        {
            ValidateSets();
            return new Product(
                this.name,
                this.description,
                this.quantity,
                this.origin,
                this.money,
                this.mainImage,
                this.category);
        }

        private void ValidateSets()
        {
            if (!this.originSet || !this.moneySet || !this.imageSet ||  !this.categorySet)
            {
                throw new InvalidProductException();
            }
        }
    }
}
