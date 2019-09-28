using System;
using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class InverterData
    {
        [JsonPropertyName("invPacData")]
        public Tuple<string, double> Data { get; set; }

        [JsonPropertyName("nominalPower")]
        public string NominalPower { get; set; }

        [JsonPropertyName("eToday")]
        public string TodayElectricity { get; set; }

        [JsonPropertyName("power")]
        public string Power { get; set; }

        [JsonPropertyName("eTotal")]
        public string TotalElectricity { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }
}