using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class WeatherUpdate
    {
        [JsonPropertyName("loc")]
        public string Loc { get; set; }

        [JsonPropertyName("utc")]
        public string Utc { get; set; }
    }
}