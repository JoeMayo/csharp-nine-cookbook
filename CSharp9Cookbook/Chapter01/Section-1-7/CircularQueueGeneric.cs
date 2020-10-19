using System;

namespace Section_1_7.Generic
{
    public class CircularQueue<T>
    {
        int current = 0;
        int last = 0;
        T[] items;

        public CircularQueue(int size)
        {
            items = new T[size];
        }

        public void Add(T obj)
        {
            if (last >= items.Length)
                throw new IndexOutOfRangeException();

            items[last++] = obj;
        }

        public T Next()
        {
            current %= last;
            T item = items[current];
            current++;

            return item;
        }
    }
}
