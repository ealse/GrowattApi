using Ealse.Growatt.Api.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ealse.Growatt.Api.Converters
{
    public abstract class DictionaryBaseConverter<TKey, TVal> : JsonConverter<Dictionary<TKey, TVal>>
    {
        public override Dictionary<TKey, TVal> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var ret = new Dictionary<TKey, TVal>();
                reader.Read();
                while (reader.TokenType != JsonTokenType.EndObject)
                {
                    if (reader.TokenType != JsonTokenType.PropertyName)
                    {
                        throw new UnexpectedTokenException();
                    }

                    var key = GetKey(reader.GetString());
                    reader.Read();

                    if (reader.TokenType != JsonTokenType.String)
                    {
                        throw new UnexpectedTokenException();
                    }

                    var value = GetValue(reader.GetString());
                        ret.Add(key, value);

                    reader.Read();
                }
                return ret;
            }

            return new Dictionary<TKey, TVal>();
        }

        public override void Write(Utf8JsonWriter writer, Dictionary<TKey, TVal> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public abstract TKey GetKey(string propertyName);

        public abstract TVal GetValue(string propertyValue);
    }
}
