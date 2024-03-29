﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeparateChaining
{
    public class SingleLinkedList
    {
        private Node start;

        public SingleLinkedList()
        {
            start = null;
        }

        public void displayList()
        {
            Node p;
            if (start == null)
            {
                Console.WriteLine("___");
                return;
            }
            p = start;
            while (p != null)
            {
                Console.Write(p.info.toString() + "  ");
                p = p.link;
            }
            Console.WriteLine();
        }


        public studentRecord search(int x)
        {
            Node p = start;
            while (p != null)
            {
                if (p.info.getstudentId() == x)
                    break;
                p = p.link;
            }
            if (p == null)
            {
                Console.WriteLine(x + " not found in list");
                return null;
            }
            else
                return p.info;
        }

        public void insertInBeginning(studentRecord data)
        {
            Node temp = new Node(data);
            temp.link = start;
            start = temp;
        }

        public void deleteNode(int x)
        {
            if (start == null)
            {
                Console.WriteLine("Value " + x + " not present\n");
                return;
            }

            /*Deletion of first node*/
            if (start.info.getstudentId() == x)
            {
                start = start.link;
                return;
            }

            /*Deletion in between or at the end*/
            Node p = start;
            while (p.link != null)
            {
                if (p.link.info.getstudentId() == x)
                    break;
                p = p.link;
            }

            if (p.link == null)
                Console.WriteLine("Value " + x + " not present\n");
            else
                p.link = p.link.link;
        }
    }
}
