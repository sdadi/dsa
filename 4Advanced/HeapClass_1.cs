using Helpers;
using System;
using System.Collections;
using System.Collections.ObjectModel;
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
            var heap = new MinHeapClass(A);
            A = heap.BuildHeap();

            int sum = 0, a = 0, b = 0;

            while(heap.Count > 1)
            {
                a = heap.GetMin();
                b = heap.GetMin();
                sum += a + b;
                heap.Insert(a+b);
            }
            
            Console.WriteLine(sum);
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
    }
}
