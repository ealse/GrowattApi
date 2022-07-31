using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class WeatherHeData
    {
        [JsonPropertyName("update")]
        public WeatherUpdate Update { get; set; }

        [JsonPropertyName("basic")]
        public WeatherBasic Basic { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("now")]
        public WeatherNow Now { get; set; }
    }
}