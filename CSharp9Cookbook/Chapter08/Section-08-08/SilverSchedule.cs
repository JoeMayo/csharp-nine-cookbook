using System;
namespace Section_08_08
{
    public class SilverSchedule : IRoomSchedule
    {
        public void ScheduleRoom() =>
            Console.WriteLine("Scheduling Silver Room");
    }
}
