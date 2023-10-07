using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    internal class Node
    {
        public Node lchild;
        public Node rchild;
        public int info;
        public Node(int ch)
        {
            this.lchild = null;
            this.rchild = null;
            this.info = ch;
        }
    }
}
