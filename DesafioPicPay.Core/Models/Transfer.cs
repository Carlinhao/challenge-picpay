using DesafioPicPay.Core.Dtos;
using DesafioPicPay.Core.Interfaces;

namespace DesafioPicPay.Core.Models;

public class Transfer : ITransfer
{
    public Payeer Payeer { get; }
    public Payee Payee { get; }
    public decimal ValueTransfer { get; }
    public DateTime DateTransfer { get; }

    public Transfer(Payeer payeer, Payee payee, decimal valueTransfer)
    {
        Payeer = payeer;
        Payee = payee;
        ValueTransfer = valueTransfer;
        DateTransfer = DateTime.Now;
    }
    
    protected Transfer() { }
}
