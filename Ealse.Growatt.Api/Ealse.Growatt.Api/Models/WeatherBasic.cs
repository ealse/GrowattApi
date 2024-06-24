using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class WeatherBasic
    {
        [JsonPropertyName("admin_area")]
        public string AdminArea { get; set; }

        [JsonPropertyName("cnty")]
        public string Country { get; set; }

        [JsonPropertyName("lat")]
        public string Latitude { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("lon")]
        public string Longitude { get; set; }

        [JsonPropertyName("parent_city")]
        public string ParentCity { get; set; }

        [JsonPropertyName("sr")]
        public string Sunrise { get; set; }

        [JsonPropertyName("ss")]
        public string Sunset { get; set; }

        [JsonPropertyName("tz")]
        public string TimeZone { get; set; }

        [JsonPropertyName("toDay")]
        public string Today { get; set; }
    }
}