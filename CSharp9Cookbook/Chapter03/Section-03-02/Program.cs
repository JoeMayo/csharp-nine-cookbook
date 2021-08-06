using System;
using System.Collections.Generic;

namespace Section_03_02
{
    class Program
    {
        static void Main()
        {
            var orders = new List<IOrder>
            {
                new CustomerOrder(),
                new CompanyOrder()
            };

            foreach (var order in orders)
            {
                Console.WriteLine(order.PrintOrder());
                Console.WriteLine($"Rewards: {order.GetRewards()}");
            }
        }
    }
}
