using DesafioPicPay.Core.Interfaces;

namespace DesafioPicPay.Core.DomainObjects;

public class AssertionConcern
{
    protected AssertionConcern() { }

    public static void ValidateIfIsEmpty(string value, string message)
    {
        if (value == null || value.Trim().Length == 0)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidateIfCanTransfer(decimal value, decimal accountValue, string message)
    {
        if (value < accountValue || value > 0)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidateIfObjectIsNull(object value, string message)
    {
        if (value is null)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidateIfValueTransferIsZero(decimal value, string message)
    {
        if (value <= 0)
        {
            throw new DomainException(message);
        }
    }

    public static void ValidateTypeCostumer(char value, string message)
    {
        if (!value.Equals('F') || !value.Equals('f') || !value.Equals('J') || !value.Equals('j'))
        {
            throw new DomainException(message);
        }
    }
}