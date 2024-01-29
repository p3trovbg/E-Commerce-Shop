namespace ECommerceShop.Domain.Models.Products
{
    using Common;
    using Exceptions;

    using static ModelConstants.Origin;

    public class Origin : ValueObject
    {
        private static readonly IEnumerable<string> AllowedCountries
            = new OriginCountryData().GetData().Cast<string>();

        internal Origin(string model, string code, string country, int year)
        {
            this.Validate(model, code, country, year);
            Model = model;
            Code = code;
            Country = country;
            Year = year;
        }

        public string Model { get; private set; }

        public string Code { get; private set; }

        public string Country { get; private set; }

        public int Year { get; private set; }

        private void Validate(string model, string code, string country, int year)
        {
            this.ValidateModel(model);
            this.ValidateCode(code);
            this.ValidateCountry(country);
            this.ValidateYear(year);
        }

        private void ValidateModel(string model)
            => Guard.ForStringLength<InvalidOriginException>(
                model,
                MinModelLength,
                MaxModelLength,
                nameof(this.Model));

        private void ValidateCode(string code)
            => Guard.ForStringLength<InvalidOriginException>(
                code,
                MinCodeLength,
                MaxCodeLength,
                nameof(this.Code));

        private void ValidateCountry(string country)
            => Guard.AgainstContains<InvalidOriginException, string>(
                country,
                AllowedCountries.ToList(),
                nameof(this.Country));

        private void ValidateYear(int year)
            => Guard.AgainstOutOfRange<InvalidOriginException>(
                year,
                MinYear,
                MaxYear,
                nameof(this.Year));
    }
}
