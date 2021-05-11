using System;
namespace Section_08_10
{
    public class BronzeSchedule : IRoomSchedule
    {
        public void ScheduleRoom() =>
            Console.WriteLine("Scheduling Bronze Room");
    }
}
