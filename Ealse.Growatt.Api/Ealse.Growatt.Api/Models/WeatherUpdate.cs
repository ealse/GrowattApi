using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class WeatherUpdate
    {
        [JsonPropertyName("utc")]
        public string Utc { get; set; }

        [JsonPropertyName("loc")]
        public string Loc { get; set; }
    }
}