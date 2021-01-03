using System;

namespace Section_03_08
{
    class Program
    {
        static void Main()
        {
            // Don't do this:
            //Console.WriteLine("Processing Orders Started");

            //ProcessOrders();

            //Console.WriteLine("Processing Orders Complete");

            try
            {
                Console.WriteLine("Processing Orders Started");

                ProcessOrders();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine('\n' + ae.ToString() + '\n');
            }
            finally
            {
                Console.WriteLine("Processing Orders Complete");
            }
        }

        static void ProcessOrders()
        {
            throw new ArgumentException();
        }
    }
}
