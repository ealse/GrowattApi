using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class WeatherHeData
    {
        [JsonPropertyName("basic")]
        public WeatherBasic Basic { get; set; }

        [JsonPropertyName("now")]
        public WeatherNow Now { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("update")]
        public WeatherUpdate Update { get; set; }
    }
}