using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Section_07_05
{
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            var targetChars = new List<char>();
            char[] sourceChars = name.ToCharArray();

            char first = sourceChars[0];
            if (char.IsUpper(first))
                targetChars.Add(char.ToLower(first));
            else
                targetChars.Add(first);

            for (int i = 1; i < sourceChars.Length; i++)
            {
                char ch = sourceChars[i];

                if (char.IsUpper(ch))
                {
                    targetChars.Add('_');
                    targetChars.Add(char.ToLower(ch));
                }
                else
                {
                    targetChars.Add(ch);
                }
            }

            return new string(targetChars.ToArray());
        }
    }
}
