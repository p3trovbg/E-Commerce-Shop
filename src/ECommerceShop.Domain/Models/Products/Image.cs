namespace ECommerceShop.Domain.Models.Products;

using Common;
using Exceptions;

using static ModelConstants.Image;

public class Image : Entity<Guid>
{
    internal Image(string path, string extension, int sizeInKilobytes)
    {
        this.Validate(path, extension, sizeInKilobytes);
        Path = path;
        Extension = extension;
        SizeInKilobytes = sizeInKilobytes;
    }

    public string Path { get; private set; }

    public string Extension { get; private set; }

    public int SizeInKilobytes { get; private set; }

    private void Validate(string path, string extension, int sizeInKilobytes)
    {
        this.ValidatePath(path);
        this.ValidateExtension(extension);
        this.ValidateSizeInKilobytes(sizeInKilobytes);
    }

    private void ValidatePath(string path)
        => Guard.AgainstEmptyString<InvalidImageException>(
            path,
            nameof(this.Path));

    private void ValidateExtension(string extension)
        => Guard.AgainstContains<InvalidImageException, string>(
            extension,
            ValidExtensions,
            nameof(this.Extension));

    private void ValidateSizeInKilobytes(int sizeInKilobytes)
        => Guard.AgainstOutOfRange<InvalidImageException>(
            sizeInKilobytes,
            MinSizeInKilobytes,
            MaxSizeInKilobytes,
            nameof(this.SizeInKilobytes));
}
