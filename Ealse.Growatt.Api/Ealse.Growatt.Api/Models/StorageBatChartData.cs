using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class StorageBatChartData
    {
        [JsonPropertyName("cdsData")]
        public StorageBatChartCdsData CdsData { get; set; }

        [JsonPropertyName("cdsTitle")]
        public List<string> CdsTitle { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("socChart")]
        public StorageBatChartSocChartData SocChart { get; set; }
    }
}