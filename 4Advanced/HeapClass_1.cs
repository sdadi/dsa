using Helpers;
namespace _4Advanced
{
    internal class HeapClass_1
    {
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
