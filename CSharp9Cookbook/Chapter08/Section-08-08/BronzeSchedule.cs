using System;
namespace Section_08_08
{
    public class BronzeSchedule : IRoomSchedule
    {
        public void ScheduleRoom() =>
            Console.WriteLine("Scheduling Bronze Room");
    }
}
