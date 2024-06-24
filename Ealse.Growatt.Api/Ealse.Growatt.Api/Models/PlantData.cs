using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class PlantData
    {
        [JsonPropertyName("accountName")]
        public string AccountName { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("co2")]
        public string Co2 { get; set; }

        [JsonPropertyName("coal")]
        public string Coal { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("creatDate")]
        public string CreatDate { get; set; }

        [JsonPropertyName("eTotal")]
        public string ETotal { get; set; }

        [JsonPropertyName("fixedPowerPrice")]
        public string FixedPowerPrice { get; set; }

        [JsonPropertyName("flatPeriodPrice")]
        public string FlatPeriodPrice { get; set; }

        [JsonPropertyName("formulaCo2")]
        public string FormulaCo2 { get; set; }

        [JsonPropertyName("formulaCoal")]
        public string FormulaCoal { get; set; }

        [JsonPropertyName("formulaMoney")]
        public string FormulaMoney { get; set; }

        [JsonPropertyName("formulaTree")]
        public string FormulaTree { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("isShare")]
        public string IsShare { get; set; }

        [JsonPropertyName("lng")]
        public string Langitude { get; set; }

        [JsonPropertyName("lat")]
        public string Latitude { get; set; }

        [JsonPropertyName("locationImg")]
        public string LocationImg { get; set; }

        [JsonPropertyName("moneyUnit")]
        public string MoneyUnit { get; set; }

        [JsonPropertyName("moneyUnitText")]
        public string MoneyUnitText { get; set; }

        [JsonPropertyName("nominalPower")]
        public string NominalPower { get; set; }

        [JsonPropertyName("peakPeriodPrice")]
        public string PeakPeriodPrice { get; set; }

        [JsonPropertyName("plantImg")]
        public string PlantImg { get; set; }

        [JsonPropertyName("plantName")]
        public string PlantName { get; set; }

        [JsonPropertyName("plantType")]
        public string PlantType { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("tree")]
        public string Tree { get; set; }

        [JsonPropertyName("valleyPeriodPrice")]
        public string ValleyPeriodPrice { get; set; }
    }
}