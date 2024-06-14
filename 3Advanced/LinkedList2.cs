using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using System.Xml.Linq;
using System.Runtime.Versioning;

namespace _3Advanced
{
    internal class LinkedList2
    {
        /// <summary>
        /// Given a linked list of integers, find and return the middle element of the linked list.
        /// NOTE: If there are N nodes in the linked list and N is even then return the(N/2 + 1)th element.
        /// Problem Constraints
        /// 1 <= length of the linked list <= 100000
        /// 1 <= Node value <= 10^9
        /// </summary>
        public static void MiddleElementofLinkedList()
        {
            List<int> input = [14, 42, 98, 26, 36, 28, 57, 93];

            var A = input.ListToListNode();

            ListNode slow = A, fast = A;

            //while (fast.next != null && fast.next.next != null) // to get left middle
            while (fast != null && fast.next != null) // to get right middle
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            Console.WriteLine(slow.val);
        }
        /// <summary>
        /// Merge two sorted linked lists, A and B, and return it as a new list.
        /// The new list should be made by splicing together the nodes of the first two lists and should also be sorted.
        /// Problem Constraints
        /// 0 <= |A|, |B| <= 10^5
        /// </summary>
        public static void MergeTwoSortedLinkedLists()
        {
            //List<int> argA = [5, 8, 20];
            //List<int> argB = [4, 11, 15];

            List<int> argA = [1, 2, 3];
            List<int> argB = null;

            ListNode A = argA.ListToListNode();
            ListNode B = argB.ListToListNode();

            if(A == null)
            {
                if(B != null)
                    B.PrintLinkedList();
                return;
            }
            if(B == null)
            {
                if(A != null)
                    A.PrintLinkedList();
                return;
            }

            ListNode Head = MergeSortedLinkedLists(A, B);

            Head.PrintLinkedList();
        }

        /// <summary>
        /// Sort a linked list, A in O(n log n) time.
        /// Problem Constraints
        /// 0 <= |A| = 10^5
        /// </summary>
        public static void SortLinkedList()
        {
            //List<int> input = [3, 4, 2, 8];
            List<int> input = [1];

            ListNode A = input.ListToListNode();

            A = MergeSort(A);
            A.PrintLinkedList();
        }
        private static ListNode MergeSort(ListNode Head)
        {
            if (Head == null || Head.next == null)
                return Head;
            ListNode mid = MidOfLinkedList(Head);
            ListNode H1 = Head;
            ListNode H2 = mid.next;
            mid.next = null;
            H1 = MergeSort(H1);
            H2 = MergeSort(H2);
            return MergeSortedLinkedLists(H1, H2);
        }

        private static ListNode MidOfLinkedList(ListNode Head)
        {
            ListNode slow = Head, fast = Head;

            while(fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }

        private static ListNode MergeSortedLinkedLists(ListNode A, ListNode B)
        {
            if(A== null) return B;
            if(B == null) return A;

            ListNode Head = null;

            if (A.val <= B.val)
            {
                Head = A;
                A = A.next;
            }
            else
            {
                Head = B;
                B = B.next;
            }

            ListNode current = Head;
            while (A != null && B != null)
            {
                if (A.val <= B.val)
                {
                    current.next = A;
                    A = A.next;
                }
                else
                {
                    current.next = B;
                    B = B.next;
                }
                current = current.next;
            }
            if (A != null)
                current.next = A;
            if (B != null)
                current.next = B;

            return Head;
        }

        /// <summary>
        /// You are using Google Maps to help you find your way around a new place. But, you get lost and end up walking in a circle. 
        /// Google Maps has a way to keep track of where you've been with the help of special sensors.
        /// These sensors notice that you're walking in a loop, and now, Google wants to create a new feature to help you figure out exactly where you started going in circles.
        /// Here's how we can describe the challenge in simpler terms: You have a Linked List A that shows each step of your journey, like a chain of events. Some of these steps have accidentally led you back to a place you've already been, making you walk in a loop.The goal is to find out the exact point where you first started walking in this loop, and then you want to break the loop by not going in the circle just before this point.
        /// Problem Constraints
        /// 1 <= number of nodes <= 1000
        /// </summary>
        public static void RemoveLoopFromLinkedList()
        {
            //ListNode A = new ListNode(1);
            //A.next = new ListNode(2);
            //A.next.next = A;

            //ListNode A = new ListNode(3);
            //A.next = new ListNode(2);
            //var pt = new ListNode(4);
            //A.next = pt;
            //pt.next = (new ListNode(5));
            //pt.next.next = (new ListNode(6));
            //pt.next.next.next = pt;

            //List<int> input = [6, 5, 5, 3, 8];
            //ListNode A = input.ListToListNode();

            ListNode A = new ListNode(6);
            A.next = new ListNode(5);            
            var pt = new ListNode(3);
            A.next.next = pt;
            pt.next = new ListNode(8);
            pt.next.next = pt;

            if (A == null)
            {
                Console.WriteLine("NULL input");
                return;
            }
            ListNode slow = A, fast = A;

            bool isloop = false;
            while(fast.next !=null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if(slow == fast)
                {
                    isloop = true;
                    break;
                }
            }
            if (isloop == false)
            {
                A.PrintLinkedList();
                return;
            }

            ListNode x = A, y = slow, prevY=slow;

            while(x != y)
            {
                prevY = y;
                x = x.next;
                y = y.next;

            }
            prevY.next = null;
            A.PrintLinkedList();

            
            //ListNode result = new ListNode(y.val);
            //ListNode current = y;
            //while(true)
            //{
            //    if(current.next == x)
            //    {
            //        current.next = null;
            //        break;
            //    }
            //    current = current.next;
            //}
            //result.next = new ListNode(current.val);
            //result.PrintLinkedList();
        }

        /// <summary>
        /// You are given two linked lists, A and B, representing two non-negative numbers.
        /// The digits are stored in reverse order, and each of their nodes contains a single digit.
        /// Add the two numbers and return it as a linked list.
        /// Problem Constraints
        /// 1 <= |A|, |B| <= 10^5
        /// </summary>
        public static void AddTwoNumberofLists()
        {
            //List<int> argA = [2, 4, 3];
            //List<int> argB = [5, 6, 4];//708

            List<int> argA = [9, 9];
            List<int> argB = [1];


            ListNode A = argA.ListToListNode();
            ListNode B = argB.ListToListNode();


            if (A == null)
            {
                B.PrintLinkedList();
                return;
            }
            if (B == null)
            {
                A.PrintLinkedList();
                return;
            }
            ListNode result = new ListNode(0);
            ListNode current = result;
            ListNode currA = A;
            ListNode currB = B;
            int carry = 0;

            while (currA != null || currB != null || carry != 0)
            {
                int valA = currA ==null?0:currA.val;
                int valB = currB==null?0:currB.val;
                int val = valA+valB+carry;
                current.next = new ListNode(val%10);
                current = current.next;
                carry = val / 10;
                if(null!=currA) currA = currA.next;
                if(null != currB) currB = currB.next;
            }

            result.next.PrintLinkedList();
        }
        /// <summary>
        /// Given a singly linked list A
        /// A: A0 → A1 → … → An-1 → An
        /// reorder it to:
        /// A0 → An → A1 → An-1 → A2 → An-2 → … 
        /// You must do this in-place without altering the nodes' values.
        /// Problem Constraints
        /// 1 <= |A| <= 10^6
        /// </summary>
        public static void ReorderLinkedList()
        {
            //List<int> input = [1, 2, 3, 4, 5];

            List<int> input = [1, 2, 3, 4];

            ListNode A = input.ListToListNode();

            ListNode slow = A, fast = A;

            while (fast.next != null && fast.next.next !=null) {
                slow = slow.next;
                fast = fast.next.next;
            }

            ListNode H2 = slow.next;
            slow.next = null;

            ListNode current = H2, previous = null;
            while (current != null)
            {
                ListNode next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }
            H2 = previous;

            current = A;
            
            while(H2 != null)
            {
                var temp = current.next;
                current.next = H2;
                H2 = H2.next;
                current = current.next;
                current.next = temp;
                current = current.next;
            }
            

            A.PrintLinkedList();

        }


        public static void CopyLinkedList()
        {
            //RandomListNode head = new RandomListNode(-1);
            //var x = head;
            //while (x != null)
            //{
            //    var y = new RandomListNode(x.label);
            //    y.next = x.next;
            //    x.next = y;
            //    x = y.next;// x.next.next;
            //}

            //x = head;
            //while (x != null)
            //{
            //    if (x.random != null)
            //        x.next.random = x.random.next;
            //    else
            //        x.next.random = null;
            //    x = x.next.next;
            //}

            //var H2 = head.next;
            //x = head;
            //var b = H2;
            //while (x != null)
            //{
            //    // x.next = b.next;
            //    // x = x.next;
            //    // if(x!=null){
            //    //     b.next = x.next;
            //    //     b = x.next;
            //    // }
            //    x.next = x.next.next;
            //    if (b.next != null)
            //    {
            //        b.next = b.next.next;
            //    }
            //    x = x.next;
            //    b = b.next;
            //}
            //return H2;
        }
    }
}
