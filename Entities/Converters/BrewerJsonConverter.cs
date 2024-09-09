using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Entities;

namespace Domain.Converters
{
    public class BrewerJsonConverter : JsonConverter<Brewer>
    {
        public override Brewer Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException("Expected start of object.");

            var brewer = new Brewer();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    return brewer;

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var propertyName = reader.GetString();
                    reader.Read(); // Move to property value

                    switch (propertyName.ToLowerInvariant())
                    {
                        case "id":
                            brewer.Id = reader.GetInt32();
                            break;
                        case "name":
                            brewer.Name = reader.GetString();
                            break;
                        case "beers":
                            if (reader.TokenType == JsonTokenType.StartArray)
                                brewer.Beers = JsonSerializer.Deserialize<List<Beer>>(ref reader, options);
                            else
                                throw new JsonException("Expected Beers to be an array.");
                            break;
                        default:
                            throw new JsonException($"Unexpected property: {propertyName}");
                    }
                }
            }

            throw new JsonException("Unexpected end of JSON.");
        }

        public override void Write(Utf8JsonWriter writer, Brewer value, JsonSerializerOptions options)
        {
            var newOptions = new JsonSerializerOptions(options)
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles // Ignore cycles to prevent circular references
            };

            writer.WriteStartObject();

            writer.WritePropertyName("id");
            writer.WriteNumberValue(value.Id);

            writer.WritePropertyName("name");
            writer.WriteStringValue(value.Name);

            writer.WritePropertyName("beer");
            JsonSerializer.Serialize(writer, value.Beers, newOptions);

            writer.WriteEndObject();
        }
    }
}
