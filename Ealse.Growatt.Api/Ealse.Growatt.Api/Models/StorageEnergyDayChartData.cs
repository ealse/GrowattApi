using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class StorageEnergyDayChartData
    {
        [JsonPropertyName("pacToUser")]
        public List<double?> PacToUser { get; set; }

        [JsonPropertyName("ppv")]
        public List<double?> Ppv { get; set; }

        [JsonPropertyName("sysOut")]
        public List<double?> SysOut { get; set; }

        [JsonPropertyName("userLoad")]
        public List<double?> UserLoad { get; set; }
    }
}