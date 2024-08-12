using System.Text.Json.Serialization;

namespace DesafioPicPay.Core.Dtos
{
    public class UserDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
        
        [JsonPropertyName("cpfCnpj")]
        public string CpfCnpj { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("isActive")]
        public bool Active { get; set; }

        [JsonPropertyName("birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonPropertyName("typeUser")]
        public char TypeUser { get; set; }
    }
}
