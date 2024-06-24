using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class SetSettingResponse
    {
        [JsonPropertyName("msg")]
        public string Msg { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}