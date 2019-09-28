using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class Device
    {
        [JsonPropertyName("lost")]
        public bool Lost { get; set; }

        [JsonPropertyName("invType")]
        public string InvType { get; set; }

        [JsonPropertyName("eToday")]
        public string EToday { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("deviceAilas")]
        public string DeviceAilas { get; set; }

        [JsonPropertyName("deviceType")]
        public string DeviceType { get; set; }

        [JsonPropertyName("datalogSn")]
        public string DatalogSn { get; set; }

        [JsonPropertyName("deviceSn")]
        public string DeviceSn { get; set; }

        [JsonPropertyName("power")]
        public string Power { get; set; }

        [JsonPropertyName("deviceStatus")]
        public int DeviceStatus { get; set; }

        [JsonPropertyName("energy")]
        public string Energy { get; set; }

    }
}