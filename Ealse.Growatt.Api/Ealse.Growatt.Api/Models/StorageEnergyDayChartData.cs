using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class StorageEnergyDayChartData
    {
        [JsonPropertyName("pacToUser")]
        public List<System.Nullable<double>> PacToUser { get; set; }

        [JsonPropertyName("sysOut")]
        public List<System.Nullable<double>> SysOut { get; set; }

        [JsonPropertyName("userLoad")]
        public List<System.Nullable<double>> UserLoad { get; set; }

        [JsonPropertyName("ppv")]
        public List<System.Nullable<double>> Ppv { get; set; }
    }
}