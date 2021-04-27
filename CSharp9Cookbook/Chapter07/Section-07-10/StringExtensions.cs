using System;
using System.Globalization;
using System.Text.Json;

namespace Section_07_10
{
    public static class StringExtensions
    {
        static readonly string[] dateFormats =
        {
            "ddd MMM dd HH:mm:ss %zzzz yyyy",
            "yyyy-MM-dd\\THH:mm:ss.000Z",
            "yyyy-MM-dd\\THH:mm:ss\\Z",
            "yyyy-MM-dd HH:mm:ss",
            "yyyy-MM-dd HH:mm"
        };

        public static DateTime GetDate(this string date, DateTime defaultValue)
        {
            return string.IsNullOrWhiteSpace(date) ||
                !DateTime.TryParseExact(
                        date,
                        dateFormats,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.AssumeUniversal |
                        DateTimeStyles.AdjustToUniversal,
                        out DateTime result)
                    ? defaultValue
                    : result;
        }

        public static DateTime GetDate(this JsonElement json, string propertyName, DateTime defaultValue = default)
        {
            string? date = json.GetString(propertyName);
            return date?.GetDate(defaultValue) ?? defaultValue;
        }

        public static string? GetString(
            this JsonElement json,
            string propertyName,
            string? defaultValue = default)
        {
            if (!json.IsNull() &&
                json.TryGetProperty(propertyName, out JsonElement element))
                return element.GetString() ?? defaultValue;

            return defaultValue;
        }

        public static bool IsNull(this JsonElement json)
        {
            return
                json.ValueKind == JsonValueKind.Undefined ||
                json.ValueKind == JsonValueKind.Null;
        }
    }
}
