using System;
namespace Section_08_03
{
    public class SilverSchedule : IRoomSchedule
    {
        public void ScheduleRoom() =>
            Console.WriteLine("Scheduling Silver Room");
    }
}
