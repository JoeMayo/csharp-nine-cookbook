using System;
namespace Section_08_08
{
    public class GoldSchedule : IRoomSchedule
    {
        public void ScheduleRoom() =>
            Console.WriteLine("Scheduling Gold Room");
    }
}
