﻿using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class Plant
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("plantName")]
        public string PlantName { get; set; }
    }
}
