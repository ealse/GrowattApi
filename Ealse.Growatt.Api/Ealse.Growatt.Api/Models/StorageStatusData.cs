using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class StorageStatusData
    {
        [JsonPropertyName("fAcInput")]
        public string FAcInput { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("vAcInput")]
        public string VAcInput { get; set; }

        [JsonPropertyName("gridPower")]
        public string GridPower { get; set; }

        [JsonPropertyName("batPower")]
        public string BatPower { get; set; }

        [JsonPropertyName("iPv2")]
        public string IPv2 { get; set; }

        [JsonPropertyName("iPv1")]
        public string IPv1 { get; set; }

        [JsonPropertyName("rateVA")]
        public string RateVA { get; set; }

        [JsonPropertyName("vBat")]
        public string VBat { get; set; }

        [JsonPropertyName("loadPrecent")]
        public string LoadPrecent { get; set; }

        [JsonPropertyName("iTotal")]
        public string ITotal { get; set; }

        [JsonPropertyName("deviceType")]
        public string DeviceType { get; set; }

        [JsonPropertyName("panelPower")]
        public string PanelPower { get; set; }

        [JsonPropertyName("capacity")]
        public string Capacity { get; set; }

        [JsonPropertyName("vAcOutput")]
        public string VAcOutput { get; set; }

        [JsonPropertyName("invStatus")]
        public string InvStatus { get; set; }

        [JsonPropertyName("loadPower")]
        public string LoadPower { get; set; }

        [JsonPropertyName("ppv2")]
        public string Ppv2 { get; set; }

        [JsonPropertyName("ppv1")]
        public string Ppv1 { get; set; }

        [JsonPropertyName("vPv2")]
        public string VPv2 { get; set; }

        [JsonPropertyName("fAcOutput")]
        public string FAcOutput { get; set; }

        [JsonPropertyName("vPv1")]
        public string VPv1 { get; set; }
    }
}