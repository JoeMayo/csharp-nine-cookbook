using System;
using System.Collections.Generic;

namespace Section_08_10
{
    class Program
    {
        static void Main()
        {
            foreach (var customer in GetCustomers())
            {
                IRoomSchedule schedule = GetSchedule(customer);
                schedule.ScheduleRoom();
            }
        }

        static IRoomSchedule GetSchedule(Customer customer) =>
            customer switch
            {
                GoldCustomer => new GoldSchedule(),
                SilverCustomer => new SilverSchedule(),
                BronzeCustomer => new BronzeSchedule(),
                _ => new BronzeSchedule()
            };

        static List<Customer> GetCustomers() =>
            new List<Customer>
            {
                new GoldCustomer(),
                new SilverCustomer(),
                new BronzeCustomer()
            };
    }
}
