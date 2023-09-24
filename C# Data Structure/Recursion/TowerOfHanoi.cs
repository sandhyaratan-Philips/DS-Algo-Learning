using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class TowerOfHanoi
    {
        public void Hanoi(int n,char source,char temp,char dest)
        {
            if(n ==1)
            {
                Console.WriteLine("move disk " + n + "from " + source + "-->" + dest);
                return;
            }
            Hanoi(n-1,source,dest,temp);
            Console.WriteLine($"Move Disk {n} from {source} --> {dest}");
            Hanoi(n-1,temp,source,dest);
        }
    }
}
