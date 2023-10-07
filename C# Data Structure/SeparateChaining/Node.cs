using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeparateChaining
{
    public class Node
    {
        public studentRecord info;
        public Node link;

        public Node(studentRecord rec)
        {
            info = rec;
            link = null;
        }
    }
    
}
