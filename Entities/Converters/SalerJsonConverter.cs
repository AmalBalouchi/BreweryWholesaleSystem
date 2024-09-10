using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Entities;

namespace Domain.Converters
{
    public class SalerJsonConverter : JsonConverter<Saler>
    {
        public override Saler Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException("Expected start of object.");

            var saler = new Saler();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    return saler;

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var propertyName = reader.GetString();
                    reader.Read(); // Move to property value

                    switch (propertyName.ToLowerInvariant())
                    {
                        case "id":
                            saler.Id = reader.GetInt32();
                            break;
                        case "name":
                            saler.Name = reader.GetString();
                            break;

                        //This scope for Deserialize salerStocks object
                        //this code is commented and saved in case we needed in the futur
                        //to link the Beer entity to the Brewer entity
                        /*case "salerstocks":
                            if (reader.TokenType == JsonTokenType.StartArray)
                                saler.salerStocks = JsonSerializer.Deserialize<List<SalerStock>>(ref reader, options);
                            else
                                throw new JsonException("Expected SalerStocks to be an array.");
                            break;*/
                        default:
                            throw new JsonException($"Unexpected property: {propertyName}");
                    }
                }
            }

            throw new JsonException("Unexpected end of JSON.");
        }

        public override void Write(Utf8JsonWriter writer, Saler value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("id");
            writer.WriteNumberValue(value.Id);

            writer.WritePropertyName("name");
            writer.WriteStringValue(value.Name);

            writer.WritePropertyName("salerstocks");
            JsonSerializer.Serialize(writer, value.salerStocks, options);

            writer.WriteEndObject();
        }
    }
}
