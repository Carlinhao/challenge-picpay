using DesafioPicPay.Core.DomainObjects;

namespace DesafioPicPay.Core.Models;

public class User : Entity
{
    public string FullName { get; private set; }
    public string CpfCnpj { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    
    public User(string fullName, string cpfCnpj, string email, string password)
    {
        FullName = fullName;
        CpfCnpj = cpfCnpj;
        Email = email;
        Password = password;

        Validate();
    }

    private void Validate()
    {
        AssertionConcern.ValidateIfIsEmpty(FullName, "Name is empty");
        AssertionConcern.ValidateIfIsEmpty(CpfCnpj, "Document is empty");
        AssertionConcern.ValidateIfIsEmpty(Email, "Email is empty");
        AssertionConcern.ValidateIfIsEmpty(Password, "Password is empty");
    }
}