using DesafioPicPay.Core.Interfaces;

namespace DesafioPicPay.Core.Models
{
    public class Account : IAccount
    {

        public string AccountId { get; }
        public string UserId { get; }
        public string CostumerName { get; }
        public decimal Balance { get; private set; }
        public bool Active { get; }
        public DateTime CreateDate { get; }
        public DateTime UpdateDate { get; }

        // Relation Entity Framework
        public User User { get; set; }

        public Account(string accountId,
                       string userId,
                       string costumerName,
                       decimal balance,
                       bool active,
                       DateTime createDate,
                       DateTime updateDate)
        {
            AccountId = accountId;
            UserId = userId;
            CostumerName = costumerName;
            Balance = balance;
            Active = active;
            CreateDate = createDate;
            UpdateDate = updateDate;
        }

        protected Account() { }

        public void Deposit(decimal value)
        {
            Balance += value;
        }

        public decimal GetCurrentBalance(decimal value)
        {
            return Balance;
        }

        public void Debit(decimal value)
        {
            Balance -= value;
        }
    }
}
