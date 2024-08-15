using Helpers;
using System.Data;
using System.Globalization;
using System.Numerics;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _4Advanced
{
    internal class HeapClass_2
    {

        /// <summary>
        /// Given an integer array B of size N.
        /// You need to find the Ath largest element in the subarray[1 to i], where i varies from 1 to N.
        /// In other words, find the Ath largest element in the sub-arrays[1 : 1], [1 : 2], [1 : 3], ...., [1 : N].
        /// NOTE: If any subarray[1 : i] has less than A elements, then the output should be -1 at the ith index.
        /// Problem Constraints
        /// 1 <= N <= 100000
        /// 1 <= A <= N
        /// 1 <= B[i] <= INT_MAX
        /// </summary>
        public static void KthLargestElement()
        {
            int A = 4;
            List<int> B = [1, 2, 3, 4 ,5 ,6];// [-1, -1, -1, 1, 2, 3]

            A = 2;
            B = [15, 20, 99, 1];// [-1, 15, 20, 20]

            var heap = new PriorityQueue<int, int>();
            var result = new List<int>();

            for (int i = 0; i < A; i++)
            {
                heap.Enqueue(B[i], B[i]);
                result.Add(heap.Count < A ? -1 : heap.Peek());
            }
            
            for (int i=A; i<B.Count; i++)
            {
                if(B[i] > heap.Peek())
                {
                    heap.Dequeue();
                    heap.Enqueue(B[i], B[i]);
                }
                result.Add(heap.Count < A ? -1 : heap.Peek());
                
            }

            result.PrintArray();
        }

        /// <summary>
        /// N people having different priorities are standing in a queue.
        /// The queue follows the property that each person is standing at most B places away from its position in the sorted queue.
        /// Your task is to sort the queue in the increasing order of priorities.
        /// NOTE:
        /// No two persons can have the same priority.
        /// Use the property of the queue to sort the queue with complexity O(NlogB).
        /// Problem Constraints
        /// 1 <= N <= 100000
        /// 0 <= B <= N
        /// </summary>
        public static void KPlacesApartSorting()
        {
            List<int> A = [1, 40, 2, 3];
            int B = 2;

            A = [2, 1, 17, 10, 21, 95];
            B = 1;

            var heap = new PriorityQueue<int, int>();
            var result = new List<int>();

            for(int i = 0; i <= B; i++)
            {
                heap.Enqueue(A[i], A[i]);
            }

            for(int i=B+1; i<A.Count; i++)
            {
                result.Add(heap.Dequeue());
                heap.Enqueue(A[i],A[i]);
            }

            while(heap.Count > 0)
            {
                result.Add(heap.Dequeue());
            }
            result.PrintArray();
        }


        /// <summary>
        /// Flipkart is currently dealing with the difficulty of precisely estimating and displaying the expected delivery time for orders to a specific pin code. 
        /// The existing method relies on historical delivery time data for that pin code, using the median value as the expected delivery time. 
        /// As the order history expands with new entries, Flipkart aims to enhance this process by dynamically updating the expected delivery time whenever a new delivery time is added. 
        /// The objective is to find the expected delivery time after each new element is incorporated into the list of delivery times. 
        /// End Goal: With every addition of new delivery time, requirement is to find the median value.
        /// Why Median ? The median is calculated because it provides a more robust measure of the expected delivery time 
        /// The median is less sensitive to outliers or extreme values than the mean.
        /// In the context of delivery times, this is crucial because occasional delays or unusually fast deliveries (outliers) can skew the mean significantly, leading to inaccurate estimations.
        /// Given an array of integers, A denoting the delivery times for each order. New arrays of integer B and C are formed, each time a new delivery data is encountered, append it at the end of B and append the median of array B at the end of C.Your task is to find and return the array C.
        /// NOTE:
        /// If the number of elements is N in B and N is odd, then consider the median as B[N / 2] (B must be in sorted order).
        /// If the number of elements is N in B and N is even, then consider the median as B[N / 2 - 1]. (B must be in sorted order).
        /// Problem Constraints
        /// 1 <= length of the array <= 100000
        /// 1 <= A[i] <= 10^9
        /// </summary>
        public static void RunningMedian()
        {
            List<int> A = [1, 2, 5, 4, 3];// [1, 1, 2, 2, 3]

            //A = [5, 17, 100, 11];//[5, 5, 17, 11]

            var maxHeap = new PriorityQueue<int, int>(new MaxHeapComparator());
            var minHeap = new PriorityQueue<int, int>();
            maxHeap.Enqueue(A[0], A[0]);
            var result = new List<int>{A[0]};

            for(int i = 1; i < A.Count; i++)
            {
                if (A[i] <= maxHeap.Peek())
                {
                    maxHeap.Enqueue(A[i], A[i]);
                    if(maxHeap.Count - minHeap.Count > 1)
                    {
                        int root = maxHeap.Dequeue();
                        minHeap.Enqueue(root,root);
                    }
                }
                else
                {
                    minHeap.Enqueue(A[i], A[i]);
                    if(minHeap.Count - maxHeap.Count > 0)
                    {
                        int root = minHeap.Dequeue();
                        maxHeap.Enqueue(root,root);
                    }
                }
                result.Add(maxHeap.Peek());
            }

            result.PrintArray();
        }
        class MaxHeapComparator:IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y - x;
            }
        }
    }
}
