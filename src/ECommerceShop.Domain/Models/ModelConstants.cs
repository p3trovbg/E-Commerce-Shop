namespace ECommerceShop.Domain.Models;

public class ModelConstants
{
    public class Common
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 20;
        public const int MinEmailLength = 3;
        public const int MaxEmailLength = 50;
        public const int MaxUrlLength = 2048;
        public const int Zero = 0;
    }

    public class Product
    {
        public const int MinNameLength = 3;
        public const int MaxNameLength = 50;
        public const int MinDescriptionLength = 5;
        public const int MaxDescriptionLength = 400;
        public const int MinQuantity = 1;
        public const int MaxQuantity = 1000;
    }

    public class Money
    {
        public const decimal MinAmount = 1.00M;
        public const decimal MaxAmount = 50.000M;
    }

    public class Category
    {
        public const int MinNameLength = 3;
        public const int MaxNameLength = 50;
        public const int MinDescriptionLength = 5;
        public const int MaxDescriptionLength = 400;
    }

    public class Review
    {
        public const int MinContentLength = 4;
        public const int MaxContentLength = 300;
        public const int MinRating = 1;
        public const int MaxRating = 6;
    }

    public class Image
    {
        public const int MinSizeInKilobytes = 50;
        public const int MaxSizeInKilobytes = 3000;
        public static readonly IEnumerable<string> ValidExtensions = new HashSet<string>
        { "jpg", "png", "jpeg" };
    }

    public class Origin
    {
        public const int MinModelLength = 2;
        public const int MaxModelLength = 50;
        public const int MinCodeLength = 13;
        public const int MaxCodeLength = 13;
        public const int MinYear = 2000;
        public const int MaxYear = 2200;
    }
}
