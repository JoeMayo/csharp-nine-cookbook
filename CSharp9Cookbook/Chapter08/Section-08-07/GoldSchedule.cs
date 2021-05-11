using System;
namespace Section_08_07
{
    public class GoldSchedule : IRoomSchedule
    {
        public void ScheduleRoom() =>
            Console.WriteLine("Scheduling Gold Room");
    }
}
