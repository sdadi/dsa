using _3Advanced;
using Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
namespace _4Advanced
{
    internal class HeapClass_1
    {

        /// <summary>
        /// You are given an array A of integers that represent the lengths of ropes.
        /// You need to connect these ropes into one rope.The cost of joining two ropes equals the sum of their lengths.
        /// Find and return the minimum cost to connect these ropes into one rope.
        /// Problem Constraints
        /// 1 <= length of the array <= 100000
        /// 1 <= A[i] <= 1000
        /// </summary>
        public static void ConnectRopes()
        {
            int[] A = [1, 2, 3, 4, 5];//33

            //A = [5, 17, 100, 11];//182
            A = [16, 7, 3, 5, 9, 8, 6, 15];//197
            var heap = new MinHeapClass(A);
            A = heap.BuildHeap();

            int sum = 0, a = 0, b = 0;

            while (heap.Count > 1)
            {
                a = heap.GetMin();
                b = heap.GetMin();
                sum += a + b;
                heap.Insert(a + b);
            }

            Console.WriteLine(sum);
        }

        public static void MergeKSortedLists()
        {
            List<int> a = [1, 10, 20];
            List<int> b = [4, 11, 13];
            List<int> c = [3, 8, 9];

            //a = [10, 12];
            //b = [13];
            //c = [5, 6];


            List<ListNode> A = [a.ListToListNode(), b.ListToListNode(), c.ListToListNode()];
            var heap = new PriorityQueue<ListNode, int>();

            for (int i = 0; i < A.Count; i++)
            {
                heap.Enqueue(A[i], A[i].val);
            }

            var result = new ListNode(-1);
            var current = result;
            while (heap.Count > 0)
            {
                var temp = heap.Dequeue();
                current.next = temp;
                temp = temp.next;
                if (temp != null)
                    heap.Enqueue(temp, temp.val);
                current = current.next;
            }
            result.next.PrintLinkedList();
        }
        /// <summary>
        /// Given an array A of N integers, convert that array into a min heap and return the array.
        /// NOTE: A min heap is a binary tree where every node has a value less than or equal to its children.
        /// Problem Constraints
        /// 1 ≤ N ≤ 10^5
        /// 0 ≤ A[i] ≤ 10^9
        /// </summary>
        public static void BuildHeap()
        {
            int[] A = [5, 13, -2, 11, 27, 31, 0, 19];
            int N = A.Length;
            for (int i = (N - 1) / 2; i >= 0; i--)
            {
                MinHeapify(A, i, N);
            }
            foreach (int i in A)
                Console.Write(i + " ");
            Console.WriteLine();
        }

        private static void MinHeapify(int[] arr, int index, int N)
        {
            int left = 2 * index;
            int right = (2 * index) + 1;
            int smallest = index;
            if (left < N && arr[left] < arr[index])
            {
                smallest = left;
            }
            else
            {
                smallest = index;
            }
            if (right < N && arr[right] < arr[smallest])
            {
                smallest = right;
            }
            if (smallest != index)
            {
                //swap(ref arr, index, smallest);
                int temp = arr[index];
                arr[index] = arr[smallest];
                arr[smallest] = temp;
                MinHeapify(arr, smallest, N);
            }
        }
        /// <summary>
        /// You have an empty min heap. You are given an array A consisting of N queries. 
        /// Let P denote A[i][0] and Q denote A[i][1]. There are two types of queries:
        /// P = 1, Q = -1 : Pop the minimum element from the heap.
        /// P = 2, 1 <= Q <= 109 : Insert Q into the heap.
        /// Return an integer array containing the answer for all the extract min operation.If the size of heap is 0, then extract min should return -1.
        /// roblem Constraints
        /// 1 <= N <= 10^5
        /// 1 <= A[i][0] <= 2
        /// 1 <= A[i][1] <= 10^9 or A[i][1] = -1
        /// </summary>
        public static void HeapQueries()
        {
            List<List<int>> A = [[1, -1], [2, 2], [2, 1], [1, -1]]; //[-1,1]

            A = [[2, 5], [2, 3], [2, 1], [1, -1], [1, -1]];// [1,3]

            var result = new List<int>();

            var heap = new PriorityQueue<int, int>();

            for (int i = 0; i < A.Count; i++)
            {
                if (A[i][0] == 1)
                {
                    result.Add(heap.Count == 0 ? -1 : heap.Dequeue());
                }
                else if (A[i][0] == 2)
                {
                    heap.Enqueue(A[i][1], A[i][1]);
                }
            }

            result.PrintArray();
        }
    }
}
