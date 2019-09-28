using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class Plant
    {
        [JsonPropertyName("plantMoneyText")]
        public string PlantMoneyText { get; set; }

        [JsonPropertyName("plantName")]
        public string PlantName { get; set; }

        [JsonPropertyName("plantId")]
        public string PlantId { get; set; }

        [JsonPropertyName("isHaveStorage")]
        public string IsHaveStorage { get; set; }

        [JsonPropertyName("todayEnergy")]
        public string TodayEnergy { get; set; }

        [JsonPropertyName("totalEnergy")]
        public string TotalEnergy { get; set; }

        [JsonPropertyName("currentPower")]
        public string CurrentPower { get; set; }
    }
}
