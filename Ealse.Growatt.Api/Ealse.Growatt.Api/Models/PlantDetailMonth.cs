using Ealse.Growatt.Api.Converters;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class PlantDetailMonth
    {
        [JsonPropertyName("plantData")]
        public PlantDataDetail PlantData { get; set; }

        [JsonConverter(typeof(PlantDetailMonthDataConverter))]
        [JsonPropertyName("data")]
        public Dictionary<DateTime, double> Data { get; set; }
    }
}
