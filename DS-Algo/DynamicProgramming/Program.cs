using System;
using System.Collections;
using System.Collections.Generic;

namespace DynamicArray
{
    public class DArray<T> : IEnumerable<T>
    {
        private T[] arr;
        private int len = 0;
        private int capacity = 0;

        public DArray() :
            this(16)
        { }

        public DArray(int capacity)
        {
            if (capacity < 0) throw new ArgumentNullException("illegal capacity: " + capacity);
            this.capacity = capacity;
            arr = new T[capacity];
        }
        public int size() { return len; }

        public bool isEmpty() { return size() == 0; }

        public T get(int index) { return arr[index]; }

        public void set(int index, T elememt) { arr[index] = elememt; }

        public void clear()
        {
            for (int i = 0; i < capacity; i++)
            {
                arr[i] = default(T);
            }
            len = 0;
        }

        public void add(T element)
        {
            if (len + 1 >= capacity)
            {
                if (capacity == 0) capacity = 1;
                else capacity *= 2;

                T[] new_arr = new T[capacity];
                for (int i = 0; i < len; i++)
                {
                    new_arr[i] = arr[i];
                }
                arr = new_arr;
            }
            arr[len++] = element;
        }

        public T removeAt(int rm_index)
        {
            if (rm_index >= len || rm_index < 0) throw new IndexOutOfRangeException();
            T data = arr[rm_index];
            T[] new_arr = new T[capacity];

            for (int i = 0, j = 0; i < len; i++, j++)
            {
                if (i == rm_index)
                    j--;
                else new_arr[j] = arr[i];
            }
            arr = new_arr;
            capacity = --len;
            return data;
        }

        public bool remove(object obj)
        {
            for (int i = 0; i < len; i++)
            {
                if (arr[i].Equals(obj))
                {
                    removeAt(i);
                    return true;
                }
            }
            return false;
        }
        public int indexOf(object obj)
        {
            for (int i = 0; i < len; i++)
            {
                if (arr[i].Equals(obj))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool contains(object obj)
        {
            return indexOf(obj) != -1;
        }


        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return arr.GetEnumerator();
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            DArray<int> fun = new DArray<int>(7);

            fun.add(2);
            fun.add(20);
            fun.add(200);
            fun.add(2000);
            fun.add(20000);
            for (int i = 0; i < fun.size(); i++)
            {
                Console.WriteLine(i + " : " + fun.get(i));
            }

        }
    }
}
