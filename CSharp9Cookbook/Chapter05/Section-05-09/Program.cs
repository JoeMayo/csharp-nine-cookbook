using System;
using System.Collections.Generic;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace Section_05_09
{
    class Program
    {
        static void Main()
        {
            List<object> tweets = GetTweets();

            string report = new Report().Generate(tweets);

            Console.WriteLine(report);
        }

        static List<object> GetTweets()
        {
            ScriptRuntime py = Python.CreateRuntime();
            dynamic semantic = py.UseFile("../../../Semantic.py");
            dynamic semanticAnalysis = semantic.SemanticAnalysis();

            DateTime date = DateTime.UtcNow;

            var tweets = new List<object>
            {
                new Tweet
                {
                    ScreenName = "SomePerson",
                    CreatedAt = date.AddMinutes(5),
                    Text = "Comment #1",
                    Semantics = GetSemanticText(semanticAnalysis, "Comment #1")
                },
                new Tweet
                {
                    ScreenName = "SomePerson",
                    CreatedAt = date.AddMinutes(7),
                    Text = "Comment #2",
                    Semantics = GetSemanticText(semanticAnalysis, "Comment #2")
                },
                new Tweet
                {
                    ScreenName = "SomePerson",
                    CreatedAt = date.AddMinutes(12),
                    Text = "Comment #3",
                    Semantics = GetSemanticText(semanticAnalysis, "Comment #3")
                },
            };

            return tweets;
        }

        static string GetSemanticText(dynamic semantic, string text)
        {
            bool result = semantic.Eval(text);
            return result ? "Positive" : "Negative";
        }
    }
}
