using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class StorageBatChartCdsData
    {
        [JsonPropertyName("cd_charge")]
        public List<double> CdChargeList { get; set; }

        [JsonPropertyName("cd_disCharge")]
        public List<double> CdDischargeList { get; set; }
    }
}