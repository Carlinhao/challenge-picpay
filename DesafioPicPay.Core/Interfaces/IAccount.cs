namespace DesafioPicPay.Core.Interfaces
{
    public interface IAccount
    {
        public string AccountId { get; }
        public string UserId { get; }
        public string CostumerName { get; }
        public decimal Balance { get; }
        public bool Active { get; }
        public DateTime CreateDate { get; }
        public DateTime UpdateDate { get; }

        void Deposit(decimal value);

        void Debit(decimal value);

        decimal GetCurrentBalance(decimal value);
    }
}