using System;
namespace Section_08_03
{
    public class GoldSchedule : IRoomSchedule
    {
        public void ScheduleRoom() =>
            Console.WriteLine("Scheduling Gold Room");
    }
}
