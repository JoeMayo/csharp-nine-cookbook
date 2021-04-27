using System;
using System.Text;

namespace Section_07_09
{
    public class Url
    {
        /// <summary>
        /// Implements Percent Encoding according to RFC 3986
        /// </summary>
        /// <param name="value">string to be encoded</param>
        /// <returns>Encoded string</returns>
        public static string PercentEncode(string? value, bool isParam = true)
        {
            const string IsParamReservedChars = @"`!@#$^&*+=,:;'?/|\[] ";
            const string NoParamReservedChars = @"`!@#$^&*()+=,:;'?/|\[] ";

            var result = new StringBuilder();

            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            var escapedValue = EncodeDataString(value);

            var reservedChars =
                isParam ? IsParamReservedChars : NoParamReservedChars;

            foreach (char symbol in escapedValue)
            {
                if (reservedChars.IndexOf(symbol) != -1)
                    result.Append(
                        '%' +
                        string.Format("{0:X2}", (int)symbol).ToUpper());
                else
                    result.Append(symbol);
            }

            return result.ToString();
        }

        /// <summary>
        /// URL-encode a string of any length.
        /// </summary>
        static string EncodeDataString(string data)
        {
            // the max length in .NET 4.5+ is 65520
            const int maxLength = 65519;

            if (data.Length <= maxLength)
                return Uri.EscapeDataString(data);

            var totalChunks = data.Length / maxLength;

            var builder = new StringBuilder();
            for (var i = 0; i <= totalChunks; i++)
            {
                string? chunk =
                    i < totalChunks ?
                        data[(maxLength * i)..maxLength] :
                        data[(maxLength * i)..];

                builder.Append(Uri.EscapeDataString(chunk));
            }
            return builder.ToString();
        }
    }
}
