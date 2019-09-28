using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class PlantDataDetail
    {
        [JsonPropertyName("plantMoneyText")]
        public string PlantMoneyText { get; set; }

        [JsonPropertyName("plantName")]
        public string PlantName { get; set; }

        [JsonPropertyName("plantId")]
        public string PlantId { get; set; }

        [JsonPropertyName("currentEnergy")]
        public string CurrentEnergy { get; set; }
    }
}