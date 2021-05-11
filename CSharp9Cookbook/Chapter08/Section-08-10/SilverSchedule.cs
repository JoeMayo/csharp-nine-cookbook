using System;

namespace Section_08_10
{
    public class SilverSchedule : IRoomSchedule
    {
        public void ScheduleRoom() =>
            Console.WriteLine("Scheduling Silver Room");
    }
}
