using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class DeviceInfoDataLogger
    {
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

        [JsonPropertyName("sn")]
        public string SerialNumber { get; set; }

        [JsonPropertyName("simSignal")]
        public string SimSignal { get; set; }
    }
}