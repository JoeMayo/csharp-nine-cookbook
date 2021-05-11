using System;
namespace Section_08_10
{
    public class GoldSchedule : IRoomSchedule
    {
        public void ScheduleRoom() =>
            Console.WriteLine("Scheduling Gold Room");
    }
}
