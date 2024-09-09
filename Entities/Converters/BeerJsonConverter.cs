using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Entities;

namespace Domain.Converters
{
    public class BeerJsonConverter : JsonConverter<Beer>
    {
        public override Beer Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException("Expected start of object.");

            var beer = new Beer();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    return beer;

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var propertyName = reader.GetString();
                    reader.Read(); // Move to property value

                    switch (propertyName.ToLowerInvariant())
                    {
                        case "id":
                            beer.Id = reader.GetInt32();
                            break;
                        case "name":
                            beer.Name = reader.GetString();
                            break;
                        case "alcohol":
                            beer.Alcohol = reader.GetDouble();
                            break;
                        case "price":
                            beer.Price = reader.GetDecimal();
                            break;
                        case "brewerid":
                            beer.BrewerId = reader.GetInt32();
                            break;
                        case "brewer":
                            if (reader.TokenType == JsonTokenType.StartObject)
                                beer.Brewer = JsonSerializer.Deserialize<Brewer>(ref reader, options);
                            else
                                throw new JsonException("Expected Brewer to be an object.");
                            break;
                        case "salerstocks":
                            if (reader.TokenType == JsonTokenType.StartArray)
                                beer.salerStocks = JsonSerializer.Deserialize<List<SalerStock>>(ref reader, options);
                            else
                                throw new JsonException("Expected SalerStocks to be an array.");
                            break;
                        default:
                            throw new JsonException($"Unexpected property: {propertyName}");
                    }
                }
            }

            throw new JsonException("Unexpected end of JSON.");
        }

        public override void Write(Utf8JsonWriter writer, Beer value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("id");
            writer.WriteNumberValue(value.Id);

            writer.WritePropertyName("name");
            writer.WriteStringValue(value.Name);

            writer.WritePropertyName("alcohol");
            writer.WriteNumberValue(value.Alcohol);

            writer.WritePropertyName("price");
            writer.WriteNumberValue(value.Price);

            writer.WritePropertyName("brewerId");
            writer.WriteNumberValue(value.BrewerId);

            // Use ReferenceHandler.Preserve to prevent cycles
            var newOptions = new JsonSerializerOptions(options)
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            /*writer.WritePropertyName("brewer");
            JsonSerializer.Serialize(writer, value.Brewer, newOptions);*/

            writer.WritePropertyName("salerStocks");
            JsonSerializer.Serialize(writer, value.salerStocks, newOptions);

            writer.WriteEndObject();
        }
    }
}
