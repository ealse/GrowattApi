using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class NewPlant
    {
        [JsonPropertyName("plantMoneyText")]
        public string PlantMoneyText { get; set; }

        [JsonPropertyName("optimizerType")]
        public int OptimizerType { get; set; }

        [JsonPropertyName("ammeterType")]
        public string AmmeterType { get; set; }

        [JsonPropertyName("storagePgrid")]
        public string StoragePgrid { get; set; }

        [JsonPropertyName("todayEnergy")]
        public string TodayEnergy { get; set; }

        [JsonPropertyName("storageTodayPpv")]
        public string StorageTodayPpv { get; set; }

        [JsonPropertyName("invTodayPpv")]
        public string InvTodayPpv { get; set; }

        [JsonPropertyName("totalEnergy")]
        public string TotalEnergy { get; set; }

        [JsonPropertyName("nominalPower")]
        public int NominalPower { get; set; }

        [JsonPropertyName("todayDischarge")]
        public string DevictodayDischargeeStatus { get; set; }

        [JsonPropertyName("Co2Reduction")]
        public string Co2Reduction { get; set; }

        [JsonPropertyName("storagePuser")]
        public string StoragePuser { get; set; }

        [JsonPropertyName("useEnergy")]
        public string UseEnergy { get; set; }

        [JsonPropertyName("totalMoneyText")]
        public string TotalMoneyText { get; set; }

        [JsonPropertyName("nominal_Power")]
        public int Nominal_Power { get; set; }

        [JsonPropertyName("deviceList")]
        public List<Device> DeviceList { get; set; }
    }
}