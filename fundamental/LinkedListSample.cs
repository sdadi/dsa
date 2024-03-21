using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace fundamental
{
    internal class LinkedListSample
    {
        internal class Node
        {
            public int data;
            public Node next;
            public Node(int d)
            {
                data = d;
                next = null;
            }

        }
        internal static void RemoveDuplicates()
        {
            Node head = null;
            int[] T = [3,9,9,11,11,11,11,89,89,100,100,101,102,103,108,200,250,250,250,250];
            for(int i=0;i< T.Length;i++) 
            {
                head = Insert(head, T[i]);
            }
            head = RemoveDupes(head);
            Display(head);
        }
        internal static Node RemoveDupes(Node head)
        {
            //Write your code here
            if (head == null)
                return null;
            Node node = head;
            while (node !=null && node.next != null)
            {
                if (node.data == node.next.data)
                {
                    node.next = node.next.next;
                    continue;
                }
                node = node.next;
            }
            return head;
        }

        internal static Node Insert(Node head, int data)
        {
            Node p = new Node(data);


            if (head == null)
                head = p;
            else if (head.next == null)
                head.next = p;
            else
            {
                Node start = head;
                while (start.next != null)
                    start = start.next;
                start.next = p;

            }
            return head;
        }
        internal static void Display(Node head)
        {
            Node start = head;
            while (start != null)
            {
                Console.Write(start.data + " ");
                start = start.next;
            }
        }
    }
}
