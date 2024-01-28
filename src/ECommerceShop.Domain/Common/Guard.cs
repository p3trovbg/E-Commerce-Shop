namespace ECommerceShop.Domain.Common
{
    using ECommerceShop.Domain.Exceptions;
    using ECommerceShop.Domain.Models;
    using System.Runtime.CompilerServices;

    public static class Guard
    {
        private const string EmptyStringFormat = "{0} cannot be null or empty.";
        private const string InvalidStringLengthFormat = "{0} must have between {1} and {2} symbols.";
        private const string OutOfRangeStringFormat = "{0} must be between {1} and {2}.";
        private const string InvalidUrlFormat = "{0} must be a valid URL.";
        private const string InvalidValueFormat = "{0} does not exist in collection.";
        public static void AgainstEmptyString<TException>(string value, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (!string.IsNullOrEmpty(value))
            {
                return;
            }

            ThrowException<TException>(string.Format(EmptyStringFormat, name));
        }

        public static void ForStringLength<TException>(string value, int minLength, int maxLength, string name = "Value")
            where TException : BaseDomainException, new()
        {
            AgainstEmptyString<TException>(value, name);

            if (minLength <= value.Length && value.Length <= maxLength)
            {
                return;
            }

            ThrowException<TException>(string.Format(InvalidStringLengthFormat, name, minLength, maxLength));
        }

        public static void AgainstOutOfRange<TException>(int number, int min, int max, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (min <= number && number <= max)
            {
                return;
            }

            ThrowException<TException>(string.Format(OutOfRangeStringFormat, name, min, max));
        }

        public static void AgainstOutOfRange<TException>(decimal number, decimal min, decimal max, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (min <= number && number <= max)
            {
                return;
            }

            ThrowException<TException>(string.Format(OutOfRangeStringFormat, name, min, max));
        }

        public static void ForValidUrl<TException>(string url, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (url.Length <= ModelConstants.Common.MaxUrlLength &&
                Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return;
            }

            ThrowException<TException>(string.Format(InvalidUrlFormat, name));
        }


        public static void Against<TException>(object actualValue, object unexpectedValue, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (!actualValue.Equals(unexpectedValue))
            {
                return;
            }

            ThrowException<TException>($"{name} must not be {unexpectedValue}.");
        }

        public static void AgainstContains<TException, TCollectionType>(
            TCollectionType actualValue,
            IEnumerable<TCollectionType> expectedValues,
            string name = "Value")
          where TException : BaseDomainException, new()
        {
            if (expectedValues.Contains(actualValue))
            {
                return;
            }

            ThrowException<TException>(string.Format(InvalidValueFormat, name));
        }

        private static void ThrowException<TException>(string message)
            where TException : BaseDomainException, new()
        {
            var exception = new TException
            {
                Error = message
            };

            throw exception;
        }
    }

}
