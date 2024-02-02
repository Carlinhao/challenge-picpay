namespace DesafioPicPay.Core.DomainObjects;

public class DomainException : Exception
{
    public DomainException() {}

    public DomainException(string message)
        : base(message){}

    public DomainException(string message, Exception innerexException)
        : base(message, innerexException){}
}