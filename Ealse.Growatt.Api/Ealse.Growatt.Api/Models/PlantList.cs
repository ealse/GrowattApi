using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class PlantList
    {
        [JsonPropertyName("data")]
        public List<Plant> Data { get; set; }

        [JsonPropertyName("totalData")]
        public TotalDataPlant TotalData { get; set; }
    }
}
