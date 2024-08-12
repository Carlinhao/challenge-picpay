using System.Text.Json.Serialization;

namespace DesafioPicPay.Core.Dtos
{
    public class AccountDto
    {
        [JsonPropertyName("id")]
        public string UserId { get; set; }

        [JsonPropertyName("costumerName")]
        public string CostumerName { get; set; }

        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("createDate")]
        public DateTime CreateDate { get; set; }

        [JsonPropertyName("updateDate")]
        public DateTime UpdateDate { get; set; }
    }
}
