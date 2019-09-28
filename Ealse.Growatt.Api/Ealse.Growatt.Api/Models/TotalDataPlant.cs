using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class TotalDataPlant
    {
        [JsonPropertyName("currentPowerSum")]
        public string CurrentPowerSum { get; set; }

        [JsonPropertyName("CO2Sum")]
        public string CO2Sum { get; set; }

        [JsonPropertyName("isHaveStorage")]
        public string IsHaveStorage { get; set; }

        [JsonPropertyName("eTotalMoneyText")]
        public string EtotalMoneyText { get; set; }

        [JsonPropertyName("todayEnergySum")]
        public string TodayEnergySum { get; set; }

        [JsonPropertyName("totalEnergySum")]
        public string TotalEnergySum { get; set; }
    }
}
