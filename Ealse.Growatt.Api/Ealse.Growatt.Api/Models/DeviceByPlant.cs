using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class DeviceByPlant
    {
        [JsonPropertyName("accountName")]
        public string AccountName { get; set; }

        [JsonPropertyName("alias")]
        public string Alias { get; set; }

        [JsonPropertyName("bdcStatus")]
        public string BdcStatus { get; set; }

        [JsonPropertyName("datalogSn")]
        public string DataLoggerSerialNumber { get; set; }

        [JsonPropertyName("datalogTypeTest")]
        public string DataLoggerTypeTest { get; set; }

        [JsonPropertyName("deviceModel")]
        public string DeviceModel { get; set; }

        [JsonPropertyName("deviceType")]
        public string DeviceType { get; set; }

        [JsonPropertyName("deviceTypeName")]
        public string DeviceTypeName { get; set; }

        [JsonPropertyName("eMonth")]
        public string EnergyMonth { get; set; }

        [JsonPropertyName("eToday")]
        public string EnergyToday { get; set; }

        [JsonPropertyName("eTotal")]
        public string EnergyTotal { get; set; }

        [JsonPropertyName("lastUpdateTime")]
        public string LastUpdateTime { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("nominalPower")]
        public string NominalPower { get; set; }

        [JsonPropertyName("pac")]
        public string Pac { get; set; }

        [JsonPropertyName("plantId")]
        public string PlantId { get; set; }

        [JsonPropertyName("plantName")]
        public string PlantName { get; set; }

        [JsonPropertyName("sn")]
        public string SerialNumber { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("timeServer")]
        public string TimeServer { get; set; }

        [JsonPropertyName("timezone")]
        public string TimeZone { get; set; }
    }
}