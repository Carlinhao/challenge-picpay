namespace DesafioPicPay.Core.Dtos.Responses;

public class UserResponse(
    string userUserId,
    string userFullName,
    string userCpfCnpj,
    string userEmail,
    bool userActive,
    DateTime userBirthDate,
    char userTypeUser)
{
    public string UserUserId { get; set; }

    public string UserFullName { get; set; }

    public string UserCpfCnpj { get; set; }

    public string UserEmail { get; set; }

    public bool UserActive { get; set; }

    public DateTime UserBirthDate { get; set; }

    public char UserTypeUser { get; set; }
}