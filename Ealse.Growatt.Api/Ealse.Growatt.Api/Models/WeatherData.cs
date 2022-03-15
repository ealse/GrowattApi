using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class WeatherData
    {
        [JsonPropertyName("HeWeather6")]
        public List<WeatherHeData> WeatherList { get; set; }

    }
}