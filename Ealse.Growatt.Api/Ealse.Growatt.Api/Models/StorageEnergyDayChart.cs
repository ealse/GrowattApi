using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class StorageEnergyDayChart
    {
        [JsonPropertyName("eChargeTotal")]
        public string EChargeTotal { get; set; }

        [JsonPropertyName("charts")]
        public StorageEnergyDayChartData Charts { get; set; }

        [JsonPropertyName("eDisCharge")]
        public string EDisCharge { get; set; }

        [JsonPropertyName("eCharge")]
        public string ECharge { get; set; }

        [JsonPropertyName("eAcCharge")]
        public string EAcCharge { get; set; }

        [JsonPropertyName("eDisChargeTotal")]
        public string EDisChargeTotal { get; set; }

        [JsonPropertyName("eAcDisCharge")]
        public string EAcDisCharge { get; set; }
    }
}