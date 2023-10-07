using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTre
    {
        private Node root;
        public BinaryTre()
        {
            root = null;
        }
        public void Display()
        {
            Display(root, 0);
            Console.WriteLine();
        }

        private void Display(Node p, int Level)
        {
            int i;
            if (p == null)
                return;

            Display(p.rchild, Level+1);
            Console.WriteLine();

            for(i=0; i < Level; i++)
            {
                Console.Write(" ");
            }
            Console.Write(p.info);

            Display(p.lchild, Level + 1);
        }
        public void CreateTree()
        {
            root = new Node('P');
            root.lchild = new Node('Q');
            root.rchild = new Node('R');
            root.lchild.lchild = new Node('A');
            root.lchild.rchild = new Node('B');
            root.rchild.lchild = new Node('X');

        }

        internal void LevelOrder()
        {
            if (root == null)
            {
                Console.WriteLine("tree is empty");
                return;
            }    

            Queue<Node> queue = new Queue<Node>();

            queue.Enqueue(root);
            Node p;
            while (queue.Count > 0)
            {
                p= queue.Dequeue();
                Console.WriteLine(p.info);
                if(p.lchild != null)
                    queue.Enqueue(p.lchild);
                if(p.rchild != null)
                    queue.Enqueue(p.rchild);
            }
            Console.WriteLine();
        }

        internal void Postorder()
        {
            Postorder(root);
            Console.WriteLine();
        }

        private void Postorder(Node p)
        {
            if (p == null)
                return;
            Inorder(p.lchild);
            Inorder(p.rchild);
            Console.WriteLine(p.info);
        }

        internal void Inorder()
        {
            Inorder(root);
            Console.WriteLine();
        }

        private void Inorder(Node p)
        {
            if (p == null)
                return;
            Inorder(p.lchild);
            Console.WriteLine(p.info);
            Inorder(p.rchild);
        }

        internal void Preorder()
        {
            Preorder(root);
            Console.WriteLine();
        }

        private void Preorder(Node p)
        {
            if (p == null)
                return;
            Console.WriteLine(p.info);
            Preorder(p.lchild);
            Preorder(p.rchild);
        }

        internal int Height()
        {
            return Height(root);
        }

        private int Height(Node p)
        {
            if (p == null)
                return 0;
            int hL=Height(p.lchild);
            int hR=Height(p.rchild);

            if (hL > hR)
                return hL+1;
            else
                return hR+1;
        }
    }
}
