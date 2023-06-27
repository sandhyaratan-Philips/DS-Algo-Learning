using System;
using System.Collections.Generic;
using System.Linq;

namespace _1146._Snapshot_Array
{
    public class snapshot
    {
        public int snapId { get; set; }
        public int index { get; set; }
        public int val { get; set; }
        public snapshot(int s, int i, int v)
        {
            snapId = s;
            index = i;
            val = v;
        }
    }
    class Program
    {
        int[] arr;
        int count;

        List<snapshot> snapMap;

        public Program(int length)
        {
            arr = new int[length];

            snapMap = new List<snapshot>();
        }

        public void Set(int index, int val)
        {
            arr[index] = val;
            var asd = snapMap.Where(x => x.snapId == count && x.index == index).FirstOrDefault();
            if (asd != null)
            {
                asd.val = val;
            }
            else
                snapMap.Add(new snapshot(count, index, val));
        }

        public int Snap()
        {
            count++;
            return count - 1;
        }

        public int Get(int index, int snap_id)
        {
            var a = snapMap.Where(x => x.snapId == snap_id && x.index == index).FirstOrDefault();
            var b = snapMap.Where(x => x.index == index).FirstOrDefault();
            if (b != null)
                return b.val;
            return a == null ? 0 : a.val;
        }
        static void Main(string[] args)
        {
            Program program = new Program(4);
            program.Snap();
            program.Snap();
            program.Get(3, 1);
            program.Set(2, 4);
            program.Snap();
            program.Get(1, 4);

            Console.WriteLine("Hello World!");
        }
    }
}
