using System;

namespace Section_1_7.Objects
{
    public class CircularQueue
    {
        int current = 0;
        int last = 0;
        object[] items;

        public CircularQueue(int size)
        {
            items = new object[size];
        }

        public void Add(object obj)
        {
            if (last >= items.Length)
                throw new IndexOutOfRangeException();

            items[last++] = obj;
        }

        public object Next()
        {
            current %= last;
            object item = items[current];
            current++;

            return item;
        }
    }
}
