﻿using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Models
{
    public class DeviceInfoStorage
    {
        [JsonPropertyName("deviceModel")]
        public string DeviceModel { get; set; }

        [JsonPropertyName("fwVersion")]
        public string FwVersion { get; set; }

        [JsonPropertyName("innerVersion")]
        public string InnerVersion { get; set; }

        [JsonPropertyName("modelText")]
        public string ModelText { get; set; }

        [JsonPropertyName("sn")]
        public string Sn { get; set; }

        [JsonPropertyName("storagedeviceType")]
        public string StoragedeviceType { get; set; }
    }
}