using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class LoginInfo
    {
        [JsonPropertyName("LoginPlantData")]
        public LoginPlantData Data { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("service")]
        public string Service { get; set; }

        [JsonPropertyName("quality")]
        public string Quality { get; set; }

        [JsonPropertyName("isOpenSmartFamily")]
        public int IsOpenSmartFamily { get; set; }

        [JsonPropertyName("app_code")]
        public string AppCode { get; set; }

        [JsonPropertyName("success")]
        public bool IsAuthenticated { get; set; }
    }
}
