using System;
namespace Section_08_02
{
    public class Scheduler
    {
        public void ScheduleRoom(string arg1, string arg2)
        {
            _ = arg1 ?? throw new ArgumentNullException(nameof(arg1));
            _ = arg2 ?? throw new ArgumentNullException(nameof(arg2));
        }
    }
}
