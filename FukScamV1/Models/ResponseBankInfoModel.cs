using System.Text.Json.Serialization;

namespace FukScamV1.Models
{
    public class ResponseBankInfoModel
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("html")]
        public string? Html { get; set; }
    }
}
