using System;

namespace Section_03_07
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                OrderOrchestrator.HandleOrdersWrong();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Handle Orders Wrong:\n" + ex);
            }

            try
            {
                OrderOrchestrator.HandleOrdersBetter1();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("\n\nHandle Orders Better #1:\n" + ex);
            }

            try
            {
                OrderOrchestrator.HandleOrdersBetter2();
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("\n\nHandle Orders Better #2:\n" + ex);
            }
        }
    }
}
