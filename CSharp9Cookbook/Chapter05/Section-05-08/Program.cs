using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Section_05_08
{
    class Program
    {
        static void Main()
        {
            List<dynamic> logData = GetData();

            var tempDateTime = DateTime.MinValue;
            List<object> inventory =
                (from log in logData
                 let canParse =
                    DateTime.TryParse(
                        log.Date, out tempDateTime)
                 select new LogEntry
                 {
                     CreatedAt = tempDateTime,
                     Type = log.Severity,
                     Where = log.Location,
                     Description = log.Message
                 })
                .ToList<object>();

            string report = new Report().Generate(inventory);

            Console.WriteLine(report);
        }

        private static List<dynamic> GetData()
        {
            const int Date = 0;
            const int Severity = 1;
            const int Location = 2;
            const int Message = 3;

            var logEntries = new List<dynamic>();

            string logData = GetLogData();

            foreach (var line in logData.Split('\n'))
            {
                string[] columns = line.Split('|');

                dynamic logEntry = new ExpandoObject();

                logEntry.Date = columns[Date];
                logEntry.Severity = columns[Severity];
                logEntry.Location = columns[Location];
                logEntry.Message = columns[Message];

                logEntries.Add(logEntry);
            }

            return logEntries;
        }

        private static string GetLogData()
        {
            return
"2022-11-12 12:34:56.7890|INFO|Section_05_07.Program|Got this far\n" +
"2022-11-12 12:35:12.3456|ERROR|Section_05_07.Report|Index out of range\n" +
"2022-11-12 12:55:34.5678|WARNING|Section_05_07.Report|Please check this";
        }
    }
}
