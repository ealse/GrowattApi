using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class Weather
    {
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("week")]
        public string Week { get; set; }

        [JsonPropertyName("dataStr")]
        public string DataString { get; set; }

        [JsonPropertyName("data")]
        public WeatherData Data { get; set; }

        [JsonPropertyName("radiant")]
        public string Radiant { get; set; }

    }
}