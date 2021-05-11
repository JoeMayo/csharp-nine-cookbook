using System.Collections.Generic;

namespace Section_08_08
{
    class Program
    {
        const int SilverPoints = 5000;
        const int GoldPoints = 20000;

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
                Customer c
                    when
                        c.Points >= GoldPoints
                            ||
                        (c.Points >= SilverPoints && c.HasFreeUpgrade)
                    => new GoldSchedule(),

                Customer c
                    when
                        c.Points >= SilverPoints
                            ||
                        (c.Points < SilverPoints && c.HasFreeUpgrade)
                    => new SilverSchedule(),

                Customer c
                    when
                        c.Points < SilverPoints
                    => new BronzeSchedule(),

                _ => new BronzeSchedule()
            };

        static List<Customer> GetCustomers() =>
            new List<Customer>
            {
                new Customer
                {
                    Points = 25000,
                    HasFreeUpgrade = false
                },
                new Customer
                {
                    Points = 10000,
                    HasFreeUpgrade = true
                },
                new Customer
                {
                    Points = 1000,
                    HasFreeUpgrade = true
                },
            };
    }
}
