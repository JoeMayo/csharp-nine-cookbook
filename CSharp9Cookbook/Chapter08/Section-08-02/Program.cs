using System;

namespace Section_08_02
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Choose (1) arg1 or (2) arg2? ");
                string arg = Console.ReadLine();

                var scheduler = new Scheduler();

                if (arg == "1")
                    scheduler.ScheduleRoom(null, "arg2");
                else
                    scheduler.ScheduleRoom("arg1", null);
            }
            catch (ArgumentNullException ex1)
                when (ex1.ParamName == "arg1")
            {
                Console.WriteLine("Invalid arg1");
            }
            catch (ArgumentNullException ex2)
                when (ex2.ParamName == "arg2")
            {
                Console.WriteLine("Invalid arg2");
            }
        }
    }
}
