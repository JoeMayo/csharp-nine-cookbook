using System;

namespace Section_03_07
{
    class OrderOrchestrator
    {
        public static void HandleOrdersWrong()
        {
            try
            {
                new Orders().Process();
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ArgumentException(ex.Message);
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
                throw new ArgumentException("Error Processing Orders", ex);
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
    }
}
