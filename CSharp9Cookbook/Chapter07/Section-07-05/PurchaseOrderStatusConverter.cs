using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Section_07_05
{
    public class PurchaseOrderStatusConverter
        : JsonConverter<PurchaseOrderStatus>
    {
        public override PurchaseOrderStatus Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            string statusString = reader.GetString();

            if (Enum.TryParse(
                statusString,
                out PurchaseOrderStatus status))
            {
                return status;
            }
            else
            {
                throw new JsonException(
                    $"{statusString} is not a valid " +
                    $"{nameof(PurchaseOrderStatus)} value.");
            }
        }

        public override void Write(
            Utf8JsonWriter writer,
            PurchaseOrderStatus value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}