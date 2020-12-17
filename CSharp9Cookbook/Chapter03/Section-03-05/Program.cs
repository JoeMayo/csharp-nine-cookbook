using System;
using System.Collections.Generic;

namespace Section_03_05
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = new List<Order>
            {
                new Order { DeliveryInstructions = Delivery.LowFare },
                new Order { DeliveryInstructions = Delivery.NextDay },
                new Order { DeliveryInstructions = Delivery.Standard },
            };

            orders.ForEach(order => 
                Console.WriteLine(order.DeliveryInstructions));
        }
    }
}
