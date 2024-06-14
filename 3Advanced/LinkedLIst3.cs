using System;
using System.Collections.Concurrent;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Xml.Linq;

namespace _3Advanced
{
    internal class LinkedLIst3
    {
        /// <summary>
        /// Write a program to find the node at which the intersection of two singly linked lists, A and B, begins. For example, the following two linked lists:
        /// A:          a1 → a2
        ///                     ↘
        ///                     c1 → c2 → c3
        ///                     ↗
        ///B:     b1 → b2 → b3
        ///NOTE:
        ///If the two linked lists have no intersection at all, return null.
        ///The linked lists must retain their original structure after the function returns.
        ///You may assume there are no cycles anywhere in the entire linked structure.
        ///Your code should preferably run in O(n) time and use only O(1) memory.
        ///The custom input to be given is different than the one explained in the examples.Please be careful.
        ///Problem Constraints
        ///0 <= |A|, |B| <= 10^6
        /// </summary>
        public static void IntersectionOfLinkedList()
        {
            #region Input setup
            List<int> inputA = [1, 25];
            List<int> inputB = [6];
            List<int> inputC = [3, 4, 5];

            //List<int> inputA = [1, 2, 3];
            //List<int> inputB = [4, 5];
            //List<int> inputC = [];

            //List<int> inputA = [56, 79, 78, 13, 97, 64, 47, 10];
            //List<int> inputB = [97, 6, 46, 83, 54, 47, 24];
            //List<int> inputC = [81, 85];

            ListNode A = inputA.ListToListNode();
            ListNode B = inputB.ListToListNode();
            ListNode C = inputC.ListToListNode();

            ListNode tempA = A;
            while (tempA.next != null)
            {
                tempA = tempA.next;
            }
            tempA.next = C;
            ListNode tempB = B;
            while (tempB.next != null)
            {
                tempB = tempB.next;
            }
            tempB.next = C; 
            #endregion

            if(A == null || B == null)
            {
                Console.WriteLine("NULL - no intersection");
                return;
            }

            int countA =0, countB =0;

            ListNode current = A;
            while(current != null)
            {
                countA++;
                current = current.next;
            }

            current = B;
            while(current != null)
            {
                countB++;
                current = current.next;
            }

            ListNode nodeA = A;
            //nodeA = A;
            int diffAB = Math.Abs(countA - countB);
            if (countA > countB)
            {
                for (int i = 0; i < diffAB; i++)
                {
                    nodeA = nodeA.next;
                }
            }

            ListNode nodeB = B;
            if (countB > countA)
            {
                for (int i = 0; i < diffAB; i++)
                {
                    nodeB = nodeB.next;
                }
            }

            while (nodeA !=null && nodeB != null)
            {
                if (nodeA == nodeB)
                    break;
                nodeA = nodeA.next;
                nodeB = nodeB.next;
            }

            nodeA.PrintLinkedList();
        }


        public static void LRUCheck()
        {
            //LRUCache cache = new LRUCache(2);
            //cache.set(1, 10);
            //cache.set(5, 12);
            //Console.WriteLine(cache.get(5));
            //Console.WriteLine(cache.get(1));
            //Console.WriteLine(cache.get(10));
            //cache.set(6, 14);
            //Console.WriteLine(cache.get(5));

            #region 6 -> 1 S 2 1 S 2 2 G 2 S 1 1 S 4 1 G 2
            LRUCache cache = new LRUCache(1);
            cache.set(2,1);
            cache.set(2,2);
            Console.WriteLine(cache.get(2));
            cache.set(1, 1);
            cache.set(4, 1);
            Console.WriteLine(cache.get(2));
            #endregion
        }

        /// <summary>
        /// You are given a linked list A
        /// Each node in the linked list contains two pointers: a next pointer and a random pointer
        /// The next pointer points to the next node in the list
        /// The random pointer can point to any node in the list, or it can be NULL
        /// Your task is to create a deep copy of the linked list A
        /// The copied list should be a completely separate linked list from the original list, but with the same node values and random pointer connections as the original list
        /// You should create a new linked list B, where each node in B has the same value as the corresponding node in A
        /// The next and random pointers of each node in B should point to the corresponding nodes in B(rather than A)
        /// Problem Constraints
        /// 0 <= |A| <= 10^6
        /// </summary>
        public static void DeepCopyLinkedList()
        {

        }
        /// <summary>
        /// Given a linked list A and a value B, partition it such that all nodes less than B come before nodes greater than or equal to B.
        /// You should preserve the original relative order of the nodes in each of the two partitions.
        /// Problem Constraints
        /// 1 <= |A| <= 10^6
        /// 1 <= A[i], B <= 10^9
        /// </summary>
        public static void PartitionListLessthanB()
        {
            List<int> input = [1, 4, 3, 2, 5, 2];
            int B = 3;//[1,2,2,4,3,5]

            //input = [1, 2, 3, 1, 3];
            //B = 2;//[1,1,2,3,3]

            var A = input.ListToListNode();

            ListNode less_start = new ListNode(0);
            ListNode great_start = new ListNode(0);
            var less = less_start;
            var great = great_start;
            var current = A;
            while (current != null)
            {
                if (current.val < B)
                {
                    less.next = current;
                    less = less.next;
                }
                else
                {
                    great.next = current;
                    great = great.next;
                }
                current = current.next;
            }
            great.next = null;
            less.next = great_start.next;
            less_start.next.PrintLinkedList();
        }
        /// <summary>
        /// Given a linked list where every node represents a linked list and contains two pointers of its type:
        /// Pointer to next node in the main list(right pointer)
        /// Pointer to a linked list where this node is head(down pointer). All linked lists are sorted.
        /// You are asked to flatten the linked list into a single list.Use down pointer to link nodes of the flattened list.The flattened linked list should also be sorted.
        /// Problem Constraints
        /// 1 <= Total nodes in the list <= 100000
        /// 1 <= Value of node <= 10^9
        /// </summary>
        public static void FlattenLinkedList()
        {

        }
    }
}
