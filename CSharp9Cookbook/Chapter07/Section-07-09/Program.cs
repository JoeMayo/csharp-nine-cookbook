using System;
using System.Linq;

namespace Section_07_09
{
    class Program
    {
        static void Main()
        {
            const string OriginalUrl =
                "https://myco.com/po/search?company=computers+";
            Console.WriteLine($"Original:    '{OriginalUrl}'");

            string escapedUri = Uri.EscapeUriString(OriginalUrl);
            Console.WriteLine($"Escape URI:  '{escapedUri}'");

            string escapedData = Uri.EscapeDataString(OriginalUrl);
            Console.WriteLine($"Escape Data: '{escapedData}'");

            string escapedUrl = EscapeUrlParams(OriginalUrl);
            Console.WriteLine($"Escaped URL: '{escapedUrl}'");
        }

        static string EscapeUrlParams(string originalUrl)
        {
            const int Base = 0;
            const int Parms = 1;
            const int Key = 0;
            const int Val = 1;
            string[] parts = originalUrl.Split('?');
            string[] pairs = parts[Parms].Split('&');

            string escapedParms =
                string.Join('&',
                    (from pair in pairs
                     let keyVal = pair.Split('=')
                     let encodedVal = Url.PercentEncode(keyVal[Val])
                     select $"{keyVal[Key]}={encodedVal}")
                    .ToList());

            return $"{parts[Base]}?{escapedParms}";
        }
    }
}
