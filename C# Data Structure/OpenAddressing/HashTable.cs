using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAddressing
{
    public class HashTable
    {
        private StudentRecord[] arr;
        private int m;
        int n;

        public HashTable():this(11)
        { }
        public HashTable(int tableSize)
        {
            m= tableSize;
            arr = new StudentRecord[m];
            n=0;
        }

        int hash(int key)
        {
            return key % m;
        }

        public void Insert(StudentRecord record)
        {
            int key=record.getId();
            int h=hash(key);
            int location = h;

            for (int i = 1; i < m; i++)
            {
                if (arr[location]==null|| arr[location].getId() == -1)
                {
                    arr[location]=record;
                    n++;
                    return;
                }
                if (arr[location].getId()==key)
                {
                    throw new InvalidOperationException("dublicate key");
                }

                location = (h + i) % m;
            }
            Console.WriteLine("record cant be inserted");
        }

        public StudentRecord Search(int key)
        {
            int h=hash(key);
            int location = h;
            for(int i = 1;i < m;i++)
            {
                if (arr[location] == null)
                    return null;
                if (arr[location].getId() == key)
                    return arr[location];
                location = (h + i) % m;
            }
            return null;
        }

        public void DisplayTable()
        {
            for (int i = 0; i < m; i++)
            {
                Console.Write("[" + i + "]  -->  ");

                if (arr[i] != null && arr[i].getId() != -1)
                    Console.WriteLine(arr[i].toString());
                else
                    Console.WriteLine("___");
            }
        }


        public StudentRecord Delete(int key)
        {
            int h = hash(key);
            int location = h;

            for (int i = 1; i < m; i++)
            {
                if (arr[location] == null)
                    return null;
                if (arr[location].getId() == key)
                {
                    StudentRecord temp = arr[location];
                    arr[location].setId(-1);
                    n--;
                    return temp;
                }
                location = (h + i) % m;
            }
            return null;
        }
    }

}

