using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    internal class BinarySearchTre
    {
        private Node root;
        public BinarySearchTre()
        {
            root = null;
        }
        public bool IsEmpty()
        {
            return root == null;
        }
        public void Preorder()
        {
            Preorder(root);
            Console.WriteLine();
        }

        private void Preorder(Node p)
        {
            if (p == null)
                return;
            Console.Write(p.info + " ");
            Preorder(p.lchild);
            Preorder(p.rchild);
        }

        public void Inorder()
        {
            Inorder(root);
            Console.WriteLine();
        }

        private void Inorder(Node p)
        {
            if (p == null)
                return;
            Inorder(p.lchild);
            Console.Write(p.info + " ");
            Inorder(p.rchild);
        }

        public void Postorder()
        {
            Postorder(root);
            Console.WriteLine();
        }

        private void Postorder(Node p)
        {
            if (p == null)
                return;
            Postorder(p.lchild);
            Postorder(p.rchild);
            Console.Write(p.info + " ");
        }
        public int Height()
        {
            return Height(root);
        }

        private int Height(Node p)
        {
            if (p == null)
                return 0;
            int hL = Height(p.lchild);
            int hR = Height(p.rchild);
            if (hL > hR)
                return hL + 1;
            else return hR + 1;
        }
        public void Display()
        {
            Display(root, 0);
            Console.WriteLine();
        }



        private void Display(Node p, int level)
        {
            int i;
            if (p == null)
                return;

            Display(p.rchild, level + 1);
            Console.WriteLine();

            for (i = 0; i < level; i++)
                Console.Write("    ");
            Console.Write(p.info);

            Display(p.lchild, level + 1);
        }

        internal bool Search1(int x)
        {
            Node p = root;
            if (p != null)
            {
                while (p != null)
                {
                    if (x < p.info)
                        p = p.lchild;
                    else if (x > p.info)
                        p = p.rchild;
                    else
                        return true;
                }

            }
            return false;

        }

        internal bool Search(int x)
        {
            return Search(root, x) != null;
        }

        private Node Search(Node p, int x)
        {
            if (p == null)
                return null;

            if (x < p.info)
                return Search(p.lchild, x);
            else if (x > p.info)
                return Search(p.rchild, x);

            return p;
        }
        public int Min1()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            Node p = root;
            while (p.lchild != null)
            {
                p = p.lchild;
            }
            return p.info;
        }
        public int Max1()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            Node p = root;
            while (p.rchild != null)
            {
                p = p.rchild;
            }
            return p.info;
        }

        public int Max()
        {
            return Max(root);
        }

        public int Min()
        {
            return Min(root);
        }

        public int Min(Node p)
        {
            if (IsEmpty()) 
                throw new InvalidOperationException();
            if (p.lchild == null)
                return p.info;
            return Min(p.lchild);
        }

        public int Max(Node p)
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            if (p.rchild == null)
                return p.info;
            return Min(p.rchild);
        }

        public void Insert(int x)
        {
            root = Insert(root, x);
        }
        internal Node Insert(Node p,int x)
        {
            if (p==null)
                p = new Node(x);
           else if(p.info>x)
                return Insert(p.lchild,x);
            else if (p.info < x)
                return Insert(p.rchild, x);
            else
                Console.WriteLine("already in tree");
            return p;
        }
        public void Insert1(int x)
        {
            Node p = root;
            Node par = null;

            while (p != null)
            {
                par = p;
                if (x < p.info)
                    p = p.lchild;
                else if (x > p.info)
                    p = p.rchild;
                else
                {
                    Console.WriteLine(x + " already present in the tree");
                    return;
                }
            }

            Node temp = new Node(x);

            if (par == null)
                root = temp;
            else if (x < par.info)
                par.lchild = temp;
            else
                par.rchild = temp;
        }

        internal void Delete(int x)
        {
            root = Delete(root, x);
        }

        private Node Delete(Node p, int x)
        {
            Node ch, s;
            if (p == null)
            {
                Console.WriteLine(x + "  not found");
                return p;
            }
            if (x < p.info)
                p.lchild = Delete(p.lchild, x);
            else if (x < p.info)
                p.rchild = Delete(p.rchild, x);
            else
            {
                //2child
                if(p.lchild != null && p.rchild != null)
                {
                    s = p.rchild;
                    while (s.lchild != null)
                        s = s.lchild;
                    p.info = s.info;
                    p.rchild = Delete(p.rchild, s.info);
                }
                else //1 or no child
                {
                    if(p.lchild!=null)
                        ch = p.lchild;
                    else ch = p.rchild;
                    p = ch;
                }
            }
            return p;
        }
        public void Delete1(int x)
        {
            Node p = root;
            Node par = null;

            while (p != null)
            {
                if (x == p.info)
                    break;
                par = p;
                if (x < p.info)
                    p = p.lchild;
                else
                    p = p.rchild;
            }

            if (p == null)
            {
                Console.WriteLine(x + " not found");
                return;
            }

            /*Case C: 2 children*/
            /*Find inorder successor and its parent*/
            Node s, ps;
            if (p.lchild != null && p.rchild != null)
            {
                ps = p;
                s = p.rchild;

                while (s.lchild != null)
                {
                    ps = s;
                    s = s.lchild;
                }
                p.info = s.info;
                p = s;
                par = ps;
            }

            /*Case B and Case A : 1 or no child*/
            Node ch;
            if (p.lchild != null) /*node to be deleted has left child */
                ch = p.lchild;
            else                /*node to be deleted has right child or no child*/
                ch = p.rchild;

            if (par == null)   /*node to be deleted is root node*/
                root = ch;
            else if (p == par.lchild)/*node is left child of its parent*/
                par.lchild = ch;
            else       /*node is right child of its parent*/
                par.rchild = ch;
        }
    }
}
