namespace ECommerceShop.Domain.Models.Orders;

using Common;
using Exceptions;

public class Recipient : Entity<int>
{
    internal Recipient(
        string name,
        string phoneNumber,
        string email) 
    {
        Validate(name, phoneNumber, email);
        this.Name = name;
        this.PhoneNumber = phoneNumber;
        this.Email = email;
    }

    public string Name { get; private set; }

    public string PhoneNumber { get; private set; }

    public string Email { get; private set; }

    private void Validate(string name, string phoneNumber, string email)
    {
        ValidateName(name);
        ValidatePhoneNumber(phoneNumber);
        ValidateEmail(email);
    }

    private void ValidateName(string name)
        => Guard.AgainstEmptyString<InvalidRecipientException>(
            name,
            nameof(this.Name));

    private void ValidatePhoneNumber(string phoneNumber)
        => Guard.AgainstEmptyString<InvalidRecipientException>(
            phoneNumber,
            nameof(this.PhoneNumber));

    private void ValidateEmail(string email)
        => Guard.AgainstEmptyString<InvalidRecipientException>(
            email,
            nameof(this.Email));
}
