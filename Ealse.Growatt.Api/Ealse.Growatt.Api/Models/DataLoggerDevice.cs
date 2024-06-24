using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class DataLoggerDevice
    {
        [JsonPropertyName("accountName")]
        public string AccountName { get; set; }

        [JsonPropertyName("alias")]
        public string Alias { get; set; }

        [JsonPropertyName("deviceType")]
        public string DeviceType { get; set; }

        [JsonPropertyName("deviceTypeIndicate")]
        public string DeviceTypeIndicate { get; set; }

        [JsonPropertyName("firmwareVersion")]
        public string FirmwareVersion { get; set; }

        [JsonPropertyName("interval")]
        public string Interval { get; set; }

        [JsonPropertyName("ipAndPort")]
        public string IpAndPort { get; set; }

        [JsonPropertyName("lastUpdateTime")]
        public string LastUpdateTime { get; set; }

        [JsonPropertyName("lost")]
        public string Lost { get; set; }

        [JsonPropertyName("plantId")]
        public string PlantId { get; set; }

        [JsonPropertyName("plantName")]
        public string PlantName { get; set; }

        [JsonPropertyName("simSignal")]
        public string SimSignal { get; set; }

        [JsonPropertyName("sn")]
        public string SerialNumber { get; set; }

        [JsonPropertyName("subModuleVersion")]
        public string SubModuleVersion { get; set; }

        [JsonPropertyName("wirelessType")]
        public string WirelessType { get; set; }
    }
}