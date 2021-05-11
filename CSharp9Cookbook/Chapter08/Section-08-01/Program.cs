using System;
using System.Collections;
using System.Collections.Generic;

namespace Section_08_01
{
    class Program
    {
        static void Main()
        {
            ProcessLegacyCode();
            ProcessModernCode();
        }

        static void ProcessLegacyCode()
        {
            ArrayList schedules = GetWeakTypedSchedules();

            foreach (var schedule in schedules)
            {
                if (schedule is IRoomSchedule)
                {
                    IRoomSchedule roomSchedule = (IRoomSchedule)schedule;
                    roomSchedule.ScheduleRoom();
                }

                //
                // alternatively
                //

                IRoomSchedule asRoomSchedule = schedule as IRoomSchedule;

                if (asRoomSchedule != null)
                    asRoomSchedule.ScheduleRoom();

                //
                // even better
                //

                if (schedule is IRoomSchedule isRoomSchedule)
                    isRoomSchedule.ScheduleRoom();
            }
        }

        static ArrayList GetWeakTypedSchedules()
        {
            var list = new ArrayList();

            list.Add(new BronzeSchedule());
            list.Add(new SilverSchedule());
            list.Add(new GoldSchedule());

            return list;
        }

        static void ProcessModernCode()
        {
            List<IRoomSchedule> schedules = GetStrongTypedSchedules();

            foreach (var schedule in schedules)
            {
                schedule.ScheduleRoom();

                if (schedule is GoldSchedule gold)
                    Console.WriteLine(
                        $"Extra processing for {gold.GetType()}");
            }
        }

        static List<IRoomSchedule> GetStrongTypedSchedules()
        {
            return new List<IRoomSchedule>
            {
                new BronzeSchedule(),
                new SilverSchedule(),
                new GoldSchedule()
            };
        }
    }
}
