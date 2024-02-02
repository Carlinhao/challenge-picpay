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
}