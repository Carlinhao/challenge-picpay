using System.Text.Json.Serialization;

namespace DesafioPicPay.Core.Dtos
{
    public class TransferDto
    {
        [JsonPropertyName("payer")]
        public Payeer Payeer { get; set; }

        [JsonPropertyName("payee")]
        public Payee Payee { get; set; }

        [JsonPropertyName("value")]
        public decimal TransferValue { get; set; }
    }
}
