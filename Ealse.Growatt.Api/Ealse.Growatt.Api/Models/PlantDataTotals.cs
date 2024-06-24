using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class PlantDataTotals
    {
        [JsonPropertyName("eToday")]
        public string EnergyToday { get; set; }

        [JsonPropertyName("eTotal")]
        public string EnergyTotal { get; set; }

        [JsonPropertyName("mToday")]
        public string MoneyToday { get; set; }

        [JsonPropertyName("mTotal")]
        public string MoneyTotal { get; set; }

        [JsonPropertyName("mUnitText")]
        public string MoneyUnitText { get; set; }

        [JsonPropertyName("plantId")]
        public string PlantId { get; set; }
    }
}