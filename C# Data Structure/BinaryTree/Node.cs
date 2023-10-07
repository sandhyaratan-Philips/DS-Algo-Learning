using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Node
    {
        public Node lchild;
        public char info;
        public Node rchild;

        public Node(char ch)
        {
            this.lchild = null;
            this.rchild = null;
            this.info = ch;
        }
    }
}
