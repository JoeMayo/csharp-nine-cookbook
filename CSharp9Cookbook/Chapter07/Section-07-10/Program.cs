using System;
using System.Text.Json;

namespace Section_07_10
{
    class Program
    {
        static void Main()
        {
            const string TweetID = "1305895383260782593";
            const string CreatedDate = "created_at";

            string tweetJson = GetTweet(TweetID);

            JsonElement tweetElem = JsonDocument.Parse(tweetJson).RootElement;

            DateTime created = tweetElem.GetDate(CreatedDate);

            Console.WriteLine($"Created Date: {created}");
        }

        static string GetTweet(string tweetID)
        {
            return @"{
			""text"": ""Thanks @github for approving sponsorship for LINQ to Twitter: https://t.co/jWeDEN07HN"",
			""id"": ""1305895383260782593"",
			""author_id"": ""15411837"",
			""created_at"": ""2020-09-15T15:44:56.000Z""
}";
        }
    }
}
