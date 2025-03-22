using System.Text.Json.Serialization;
using DesafioPicPay.Core.DomainObjects;
using DesafioPicPay.Core.Interfaces;

namespace DesafioPicPay.Core.Models;

public class User : IUser
{
    public string UserId { get; private set; }
    public string FullName { get; private set; }
    public string CpfCnpj { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public bool Active { get; private set; }
    public DateTime BirthDate { get; private set; }
    public char TypeUser { get; private set; }

    // Relation Entity Framework
    [JsonIgnore]
    public Account Account { get; set; }

    protected User() { }

    public User(string userId,
                string fullName,
                string cpfCnpj,
                string email,
                string password,
                bool active,
                DateTime birthDate,
                char typeUser)
    {
        
        UserId = userId;
        FullName = fullName;
        CpfCnpj = cpfCnpj;
        Email = email;
        Password = password;
        Active = active;
        BirthDate = birthDate;
        TypeUser = char.ToUpper(typeUser);

        Validate();
    }

    public void UpdateName(string fullName)
    {
        FullName = fullName;
    }

    public void UpdatePassword(string password)
    {
        Password = password;
    }

    private void Validate()
    {
        AssertionConcern.ValidateIfIsEmpty(FullName, "Name is empty");
        AssertionConcern.ValidateIfIsEmpty(CpfCnpj, "Document is empty");
        AssertionConcern.ValidateIfIsEmpty(Email, "Email is empty");
        AssertionConcern.ValidateIfIsEmpty(Password, "Password is empty");
    }
}