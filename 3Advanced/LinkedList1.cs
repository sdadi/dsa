using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace _3Advanced
{
    internal class LinkedList1
    {

        /// <summary>
        /// You are given a singly linked list having head node A. You have to reverse the linked list and return the head node of that reversed list.
        /// NOTE: You have to do it in-place and in one-pass.
        /// Problem Constraints
        /// 1 <= Length of linked list <= 10^5
        /// Value of each node is within the range of a 32-bit integer.
        /// </summary>
        public static void ReverseLinkedList()
        {
            List<int> input = [1, 2, 3, 4, 5];
            //List<int> input = 3;

            ListNode A = input.ListToListNode();
            A.PrintLinkedList();

            ReverseLinkedList(ref A);

            A.PrintLinkedList();
        }
        /// <summary>
        /// Problem Description
        /// Reverse a linked list A from position B to C.
        /// NOTE: Do it in-place and in one-pass.
        /// Problem Constraints
        /// 1 <= |A| <= 10^6
        /// 1 <= B <= C <= |A|
        /// </summary>
        public static void ReverseLinkedListRange()
        {
            //List<int> input = [1,2,3,4,5];
            List<int> input = [81, 86, 96, 66, 63, 76, 51, 28, 32, 36, 59, 19, 54, 93, 50, 37, 90, 46, 91, 2, 83, 55, 84, 34, 100, 79, 33, 18, 68, 75, 44, 10, 88, 64, 43, 70, 39, 8, 3, 29, 22, 74, 38];

            ListNode A = input.ListToListNode();
            //int B = 2, C = 5;
            //int B = 3, C = 5;
            //int B = 1, C = 5;
            int B = 11, C = 11;

            A.PrintLinkedList();


            ListNode current = A;
            int N = 0;
            ListNode first = null, from = null, to = null, last = null;

            while (current != null)
            {
                N++;
                if (N < B)
                    first = current;
                if (N == B)
                    from = current;
                if(N == C)
                {
                    to = current;
                    last = current.next;
                    to.next = null;
                    break;
                }
                current = current.next;
            }

            ListNode previous = null;
            current = from;

            while(current != null)
            {
                ListNode next = current.next;
                current.next = previous;
                if (null == current.next)
                    to = current;
                previous = current;
                current = next;
            }
            from = previous;
            
            if (first != null)
                first.next = from;
            else
                A = from;
            
            to.next = last;

            A.PrintLinkedList();


        }
        /// <summary>
        /// Given a singly linked list A, determine if it's a palindrome. Return 1 or 0, denoting if it's a palindrome or not, respectively.
        /// Problem Constraints
        /// 1 <= |A| <= 10^5
        /// </summary>
        public static void PalindromeLinkedList()
        {
            //List<int> input = [1, 2, 2, 1];//1

            //List<int> input = [1, 2, 1];//0
            List<int> input = [3];

            ListNode A = input.ListToListNode();
            A.PrintLinkedList();


            ListNode current = A;
            int N = 0;

            while(current != null)
            {
                N++;
                current = current.next;
            }
            if (N == 1)
            {
                Console.WriteLine(1); 
                return;
            }

            current = A;
            ListNode half2 = null;
            int i = 0;
            while(current != null)
            {
                i++;
                if(i == N / 2)
                {
                    half2 = current.next;
                    current.next = null;
                    break;
                }
                current = current.next;
            }

            current = half2;
            ListNode previous = null;
            while(current != null)
            {
                var next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }
            half2 = previous;

            ListNode current1 = A;
            ListNode current2 = half2;
            bool isPalindrome = true;

            for(int k=1;k <= i; k++)
            {
                if (current1.val != current2.val)
                {
                    isPalindrome = false; 
                    break;
                }
                current1 = current1.next;
                current2 = current2.next;
            }

            Console.WriteLine(isPalindrome?1:0);
        }

        private static void ReverseLinkedList(ref ListNode head)
        {
            ListNode current = head;
            ListNode previous = null;

            while (current != null)
            {
                ListNode next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }

            head = previous;
        }
        private static void ReverseLinkedList(ListNode head, int left, int right)
        {
            ListNode current = head;
            ListNode previous = null;
            int i = 0;
            while(i <= left){
                if (current != null)
                {
                    current = current.next;
                    i++;
                }
            }

            while (current != null  && i <=right)
            {
                ListNode next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }

            head = previous;
        }

        #region Linked List Methods

        public static void insert_node(int position, int value)
        {
            // @params position, integer
            // @params value, integer
            var newN = new ListNode(value);
            if (position == 1)
            {
                newN.next = Head;
                Head = newN;
                return;
            }

            var temp = Head;
            ListNode previousNode = temp;

            for (int i = 1; i < position; i++)
            {
                if (temp == null)
                    return;
                previousNode = temp;
                temp = temp.next;
            }
            previousNode.next = newN;
            newN.next = temp;

        }

        public static void delete_node(int position)
        {
            // @params position, integer
            if (position == 1)
            {
                var oldN = Head;
                Head = Head.next;
                oldN = null;
                return;
            }
            var temp = Head;
            if (Head == null) return;

            ListNode previousNode = temp;
            for (int i = 1; i < position; i++)
            {
                if (temp == null)
                    return;
                previousNode = temp;
                temp = temp.next;
            }
            if (temp != null)
                previousNode.next = temp.next;
            temp = null;
        }

        public static void print_ll()
        {
            // Output each element followed by a space
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            ListNode temp = Head;
            while (temp != null)
            {
                sb.Append($"{temp.val} ");
                temp = temp.next;
            }
            Console.Write(sb.ToString().TrimEnd());
        }

        public static ListNode Head = null;
        #endregion

        /// <summary>
        /// Given a sorted linked list, delete all duplicates such that each element appears only once.
        /// Problem Constraints
        /// 0 <= length of linked list <= 10^6
        /// </summary>
        public static void RemoveDuplicatesFromSortedLinkedList()
        {
            //List<int> input = [1, 1, 2];

            List<int> input = [1, 1, 2, 3,3,4,4,4,4,5,5,5,5];

            ListNode A = input.ListToListNode();

           if(A == null || A.next == null)
            {
                A.PrintLinkedList();
                return;
            }

            ListNode current = A;
            while ( current.next != null)
            {
                if(current.val == current.next.val)
                {
                    current.next = current.next.next;
                    continue;
                }
                current = current.next;
            }
            A.PrintLinkedList();
        }

        /// <summary>
        /// Given a linked list A, remove the B-th node from the end of the list and return its head.
        /// For example, given linked list: 1->2->3->4->5, and B = 2.
        /// After removing the second node from the end, the linked list becomes 1->2->3->5.
        /// NOTE: If B is greater than the size of the list, remove the first node of the list.
        /// Try doing it using constant additional space.
        /// Problem Constraints
        /// 1 <= |A| <= 10^6
        /// </summary>
        public static void RemoveNthFromEnd()
        {
            List<int> input = [1, 2, 3, 4, 5];
            int B = 1;

            //List<int> input = [1,2];
            //int B = 1;

            ListNode A = input.ListToListNode();

            if(A == null)
            {
                A.PrintLinkedList();
                return;
            }

            ListNode first = A, second = A;
            for (int i = 1; i <= B; i++)
            {
                if (first == null)
                {
                    break;
                }
                else
                    first = first.next;
            }
            if (first == null)
            {
                A = A.next;
                A.PrintLinkedList();
                return;
            }

            while (first.next != null)
            {
                first = first.next;
                second = second.next;
            }
            if(second!=null && second.next !=null)
                second.next = second.next.next;
            A.PrintLinkedList();
        }
    }
}
