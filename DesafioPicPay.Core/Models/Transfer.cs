namespace DesafioPicPay.Core.Models;

public class Transfer
{
    public decimal ValueTransfer { get; private set; }
    public string Payeer { get; private set; }
    public string Payee { get; private set; }
    
    public Transfer(decimal valueTransfer, string payeer, string payee)
    {
        ValueTransfer = valueTransfer;
        Payeer = payeer;
        Payee = payee;
    }
}