using System;

namespace Section_03_07
{
    public class OrderOrchestrator
    {
        public static void HandleOrdersWrong()
        {
            try
            {
                new Orders().Process();
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public static void HandleOrdersBetter1()
        {
            try
            {
                new Orders().Process();
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidOperationException("Error Processing Orders", ex);
            }
        }

        public static void HandleOrdersBetter2()
        {
            try
            {
                new Orders().Process();
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
        }

        public static void DontHandleOrders()
        {
            new Orders().Process();
        }
    }
}
