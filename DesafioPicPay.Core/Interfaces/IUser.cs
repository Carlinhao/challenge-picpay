namespace DesafioPicPay.Core.Interfaces
{
    public interface IUser
    {
        public string FullName { get; }
        public string CpfCnpj { get; }
        public string Email { get;  }
        public string Password { get; }
        public bool Active { get; }
        public char TypeUser { get; }
        public DateTime BirthDate { get; }
    }
}
