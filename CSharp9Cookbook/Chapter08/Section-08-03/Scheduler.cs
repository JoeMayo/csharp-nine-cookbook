namespace Section_08_03
{
    public class Scheduler
    {
        public IRoomSchedule CreateStatement(
            ScheduleType scheduleType)
        {
            switch (scheduleType)
            {
                case ScheduleType.Gold:
                    return new GoldSchedule();
                case ScheduleType.Silver:
                    return new SilverSchedule();
                case ScheduleType.Bronze:
                default:
                    return new BronzeSchedule();
            }
        }

        public IRoomSchedule CreateExpression(
            ScheduleType scheduleType) =>
                scheduleType switch
                {
                    ScheduleType.Gold => new GoldSchedule(),
                    ScheduleType.Silver => new SilverSchedule(),
                    ScheduleType.Bronze => new BronzeSchedule(),
                    _ => new BronzeSchedule()
                };
    }
}
