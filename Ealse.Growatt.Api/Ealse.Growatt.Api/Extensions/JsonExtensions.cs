using System;
using System.Linq;
using System.Text.Json;

namespace Ealse.Growatt.Api.Extensions
{
    internal static class JsonExtensions
    {
        /// <summary>
        /// Get json element by path.
        /// Example path: "obj.0.datas"
        /// </summary>
        /// <param name="jsonElement">jsonElement</param>
        /// <param name="path">Path to part of the json</param>
        /// <returns>Part of the json by path</returns>
        internal static JsonElement GetJsonElementByPath(this JsonElement jsonElement, string path)
        {
            if(string.IsNullOrWhiteSpace(path))
                return jsonElement;

            if (jsonElement.ValueKind is JsonValueKind.Null || jsonElement.ValueKind is JsonValueKind.Undefined)
                return default;

            string[] segments = path.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var segment in segments)
            {
                if (int.TryParse(segment, out var index) && jsonElement.ValueKind == JsonValueKind.Array)
                {
                    jsonElement = jsonElement.EnumerateArray().ElementAtOrDefault(index);
                    if (jsonElement.ValueKind is JsonValueKind.Null || jsonElement.ValueKind is JsonValueKind.Undefined)
                        return default;

                    continue;
                }

                jsonElement = jsonElement.TryGetProperty(segment, out var value) ? value : default;

                if (jsonElement.ValueKind is JsonValueKind.Null || jsonElement.ValueKind is JsonValueKind.Undefined)
                    return default;
            }

            return jsonElement;
        }

        /// <summary>
        /// Get part of the json by path.
        /// Example path: "obj.0.datas"
        /// </summary>
        /// <param name="json">Json string</param>
        /// <param name="path">Path to part of the json</param>
        /// <returns>Part of the json by path</returns>
        internal static string GetPartOfJson(this string json, string path)
        {
            using (JsonDocument document = JsonDocument.Parse(json))
            {
                return document.RootElement.GetJsonElementByPath(path).ToString();
            }
        }
    }
}
