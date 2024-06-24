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
        public string DatalogSn { get; set; }

        [JsonPropertyName("datalogTypeTest")]
        public string DatalogTypeTest { get; set; }

        [JsonPropertyName("deviceModel")]
        public string DeviceModel { get; set; }

        [JsonPropertyName("deviceType")]
        public string DeviceType { get; set; }

        [JsonPropertyName("deviceTypeName")]
        public string DeviceTypeName { get; set; }

        [JsonPropertyName("eMonth")]
        public string EMonth { get; set; }

        [JsonPropertyName("eToday")]
        public string EToday { get; set; }

        [JsonPropertyName("eTotal")]
        public string ETotal { get; set; }

        [JsonPropertyName("lastUpdateDateTime")]
        public string LastUpdateDateTime { get; set; }

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
        public string Sn { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("timeServer")]
        public string TimeServer { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }
    }
}