using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class PlantFaultLog
    {
        [JsonPropertyName("alias")]
        public string Alias { get; set; }

        [JsonPropertyName("batSn")]
        public string BatSerialNumber { get; set; }

        [JsonPropertyName("deviceSn")]
        public string DeviceSerialNumber { get; set; }

        [JsonPropertyName("deviceType")]
        public string DeviceType { get; set; }

        [JsonPropertyName("eventId")]
        public string EventId { get; set; }

        [JsonPropertyName("eventName")]
        public string EventName { get; set; }

        [JsonPropertyName("eventSolution")]
        public string EventSolution { get; set; }

        [JsonPropertyName("sn")]
        public string SerialNumber { get; set; }

        [JsonPropertyName("solution")]
        public string Solution { get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; }
    }
}