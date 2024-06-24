using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class WeatherNow
    {
        [JsonPropertyName("cloud")]
        public string Cloud { get; set; }

        [JsonPropertyName("cond_code")]
        public string ConditionCode { get; set; }

        [JsonPropertyName("cond_txt")]
        public string ConditionText { get; set; }

        [JsonPropertyName("fl")]
        public string Fl { get; set; }

        [JsonPropertyName("hum")]
        public string Humidity { get; set; }

        [JsonPropertyName("pcpn")]
        public string Pcpn { get; set; }

        [JsonPropertyName("pres")]
        public string Pressure { get; set; }

        [JsonPropertyName("tmp")]
        public string Temperature { get; set; }

        [JsonPropertyName("vis")]
        public string Visibility { get; set; }

        [JsonPropertyName("wind_deg")]
        public string WindDegrees { get; set; }

        [JsonPropertyName("wind_dir")]
        public string WindDirection { get; set; }

        [JsonPropertyName("wind_sc")]
        public string WindSc { get; set; }

        [JsonPropertyName("wind_spd")]
        public string WindSpeed { get; set; }
    }
}