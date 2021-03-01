using System;
using System.Collections.Generic;

namespace Section_07_05
{
    class Program
    {
        static void Main()
        {
            //var inventory = new List<dynamic>();

            //dynamic item1 = new DynamicReportItem();
            //item1.PartNumber = "1";
            //item1.Description = "Part #1";
            //item1.Count = 3;
            //item1.ItemPrice = 5.26m;
            //inventory.Add(item1);

            //dynamic item2 = new DynamicReportItem();
            //item2.PartNumber = "2";
            //item2.Description = "Part #2";
            //item2.Count = 1;
            //item2.ItemPrice = 7.95m;
            //inventory.Add(item2);

            //dynamic item3 = new DynamicReportItem();
            //item3.PartNumber = "3";
            //item3.Description = "Part #3";
            //item3.Count = 2;
            //item3.ItemPrice = 23.13m;
            //inventory.Add(item3);

            string inventory = @"
                [
                    {
                        ""PartNumber"" = ""1"",
                        ""Description"" = ""Part #1"",
                        ""Count"" = ""3"",
                        ""ItemPrice"" = ""5.26""
                    },
                    {
                        ""PartNumber"" = ""2"",
                        ""Description"" = ""Part #2"",
                        ""Count"" = ""1"",
                        ""ItemPrice"" = ""7.95""
                    },
                    {
                        ""PartNumber"" = ""3"",
                        ""Description"" = ""Part #3"",
                        ""Count"" = ""2"",
                        ""ItemPrice"" = ""23.13""
                    }
                ]";

            //inventory = new DynamicReportItem(inventory);

            //string report = new Report().Generate(inventory);

            //Console.WriteLine(report);
        }
    }
}
