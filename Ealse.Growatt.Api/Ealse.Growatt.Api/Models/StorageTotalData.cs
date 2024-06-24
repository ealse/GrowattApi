using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class StorageTotalData
    {
        [JsonPropertyName("chargeToday")]
        public string ChargeToday { get; set; }

        [JsonPropertyName("chargeTotal")]
        public string ChargeTotal { get; set; }

        [JsonPropertyName("deviceType")]
        public string DeviceType { get; set; }

        [JsonPropertyName("eDischargeToday")]
        public string EDischargeToday { get; set; }

        [JsonPropertyName("eDischargeTotal")]
        public string EDischargeTotal { get; set; }

        [JsonPropertyName("epvToday")]
        public string EpvToday { get; set; }

        [JsonPropertyName("epvTotal")]
        public string EpvTotal { get; set; }

        [JsonPropertyName("eToUserToday")]
        public string EToUserToday { get; set; }

        [JsonPropertyName("eToUserTotal")]
        public string EToUserTotal { get; set; }

        [JsonPropertyName("useEnergyToday")]
        public string UseEnergyToday { get; set; }

        [JsonPropertyName("useEnergyTotal")]
        public string UseEnergyTotal { get; set; }
    }
}