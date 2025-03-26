namespace DesafioPicPay.Core.Interfaces
{
    public interface ITransferService<in TRequest, TValue>
    {
        TValue SendMessaAsync(TRequest request);
        TValue TransferAsync(TRequest request);
        bool CanTransfer(TRequest request);
    }
}
