using Ealse.Growatt.Api.Converters;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class PlantDetailYear
    {
        [JsonPropertyName("plantData")]
        public PlantDataDetail PlantData { get; set; }

        [JsonConverter(typeof(PlantDetailYearDataConverter))]
        [JsonPropertyName("data")]
        public Dictionary<DateTime, double> Data { get; set; }
    }
}
