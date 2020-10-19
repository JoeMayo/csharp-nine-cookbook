using System;
using System.IO;

namespace Section_02_02
{
    class Program
    {
        const string FileName = "Invoice.txt";

        static void Main(string[] args)
        {
            Console.WriteLine(
                "Invoice App\n" +
                "-----------\n");

            WriteDetails();

            ReadDetails();
        }

        static void WriteDetails()
        {

            using var writer = new StreamWriter(FileName);

            Console.WriteLine("Type details and press [Enter] to end.\n");

            string detail = string.Empty;
            do
            {
                Console.Write("Detail: ");
                detail = Console.ReadLine();
                writer.WriteLine(detail);
            }
            while (!string.IsNullOrWhiteSpace(detail));
        }

        static void ReadDetails()
        {
            Console.WriteLine("\nInvoice Details:\n");

            using var reader = new StreamReader(FileName);

            string detail = string.Empty;
            do
            {
                detail = reader.ReadLine();
                Console.WriteLine(detail);
            }
            while (!string.IsNullOrWhiteSpace(detail));
        }
    }
}
