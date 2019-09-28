using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class LoginPlantData
    {
        [JsonPropertyName("plantName")]
        public string PlantName { get; set; }

        [JsonPropertyName("plantId")]
        public string PlantId { get; set; }
    }
}
