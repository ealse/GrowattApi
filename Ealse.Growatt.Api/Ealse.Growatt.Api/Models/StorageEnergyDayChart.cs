using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class StorageEnergyDayChart
    {
        [JsonPropertyName("charts")]
        public StorageEnergyDayChartData Charts { get; set; }

        [JsonPropertyName("eAcCharge")]
        public string EAcCharge { get; set; }

        [JsonPropertyName("eAcDisCharge")]
        public string EAcDisCharge { get; set; }

        [JsonPropertyName("eCharge")]
        public string ECharge { get; set; }

        [JsonPropertyName("eChargeTotal")]
        public string EChargeTotal { get; set; }

        [JsonPropertyName("eDisCharge")]
        public string EDisCharge { get; set; }

        [JsonPropertyName("eDisChargeTotal")]
        public string EDisChargeTotal { get; set; }
    }
}