using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class StorageBatChartSocChartData
    {
        [JsonPropertyName("capacity")]
        public List<Nullable<double>> Capacity { get; set; }
    }
}