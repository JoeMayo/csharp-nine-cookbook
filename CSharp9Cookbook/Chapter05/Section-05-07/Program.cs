using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Section_05_07
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

        static List<dynamic> GetData()
        {
            string headers = "Date|Severity|Location|Message";

            string logData = GetLogData();

            return
                (from line in logData.Split('\n')
                 select new DynamicLog(headers, line))
                .ToList<dynamic>();
        }

        static string GetLogData()
        {
            return
"2022-11-12 12:34:56.7890|INFO|Section_05_07.Program|Got this far\n" +
"2022-11-12 12:35:12.3456|ERROR|Section_05_07.Report|Index out of range\n" +
"2022-11-12 12:55:34.5678|WARNING|Section_05_07.Report|Please check this";
        }
    }
}
