using System;

namespace Section_03_07
{
    class Orders
    {
        public void Process()
        {
            throw new IndexOutOfRangeException(
                "Expected 10 orders, but found only 9.");
        }
    }
}
