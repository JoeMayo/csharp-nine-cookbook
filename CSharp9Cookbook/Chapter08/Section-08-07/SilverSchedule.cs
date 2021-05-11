using System;
namespace Section_08_07
{
    public class SilverSchedule : IRoomSchedule
    {
        public void ScheduleRoom() =>
            Console.WriteLine("Scheduling Silver Room");
    }
}
