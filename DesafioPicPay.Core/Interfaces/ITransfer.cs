using DesafioPicPay.Core.Dtos;

namespace DesafioPicPay.Core.Interfaces;

public interface ITransfer
{
    public Payeer Payeer { get; }
    public Payee Payee { get; }
    public decimal ValueTransfer { get; }
    public DateTime DateTransfer { get; }
}