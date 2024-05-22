using Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _2Advanced
{
    internal class Sorting1
    {

        /// <summary>
        /// Given an array of integers A, we call (i, j) an important reverse pair if i < j and A[i] > 2*A[j].
        /// Return the number of important reverse pairs in the given array A.
        /// Problem Constraints
        /// 1 <= length of the array <= 10^5
        /// -2 * 109 <= A[i] <= 2 * 10^9
        /// </summary>
        public static void ReversePairs()
        {
            List<int> A = [1, 3, 2, 3, 1];//2

            //List<int> A = [4, 1, 2];//1


        }
        /// <summary>
        /// Given an array A. Sort this array using Count Sort Algorithm and return the sorted array.
        /// 1 <= |A| <= 10^5
        /// 1 <= A[i] <= 10^5
        /// </summary>
        public static void CountSort()
        {
            List<int> A = [1, 3, 1];
            
            var result = new List<int>();
            var fArray = new List<int>();
            int maxVal = int.MinValue;

            
            for(int i=0; i < A.Count; i++)
            {
                if (A[i] > maxVal)
                    maxVal = A[i];
            }
            for (int i = 0; i <= maxVal; i++)
            {
                fArray.Add(0);
            }


            for (int i = 0;i<A.Count ;i++)
            {
                fArray[A[i]] += 1;
            }

            for(int i=1;i< fArray.Count; i++)
            {
                while (fArray[i] > 0)
                {
                    result.Add(i);
                    fArray[i] -= 1;
                }
            }

            ArrayExtension.PrintArray(result);
        }

        /// <summary>
        /// Given an array of integers A. If i < j and A[i] > A[j], then the pair (i, j) is called an inversion of A. 
        /// Find the total number of inversions of A modulo (109 + 7).
        /// 1 <= length of the array <= 105
        /// 1 <= A[i] <= 109
        /// </summary>
        public static void InverseCountRun()
        {
            //List<int> A = [1, 3, 2];
            //List<int> A = [3, 4, 1, 2];
            List<int> A = [45, 10, 15, 25, 50];
        }

        public static void MergeSortRun()
        {
            //List<int> A = [1, 3, 2];
            //List<int> A = [3, 4, 1, 2];
            List<int> A = [45, 10, 15, 25, 50];
            Console.WriteLine("Input array");
            ArrayExtension.PrintArray(A);

            MergeSort(A, 0, A.Count - 1);

            Console.WriteLine("Sorted Array");
            ArrayExtension.PrintArray(A);
        }
        private static void MergeSort(List<int> A,int l,int r)
        {
            if (l >= r) return;
            int mid = (l + r) / 2;
            MergeSort(A, l, mid);//left sort
            MergeSort(A, mid + 1, r);//right sort

            MergeSortedArray(A, l, mid, r); //merge sorted left and right parts
        }
        private static void MergeSortedArray(List<int> A,int l, int mid, int r)
        {
            var lArray = new List<int>();
            var rArray = new List<int>();

            for(int i=l;i<=mid; i++)
            {
                lArray.Add(A[i]);
            }
            for(int i = mid + 1; i <= r; i++)
            {
                rArray.Add(A[i]);
            }

            int k = l, l_new = 0, r_new = 0;

            while(l_new < (lArray.Count) && r_new < (rArray.Count))
            {
                if (lArray[l_new] >= rArray[r_new])
                {
                    A[k++] = lArray[l_new++];
                }
                else
                {
                    A[k++] = rArray[r_new++];
                }
            }
            while(l_new < lArray.Count)
            {
                A[k++] = lArray[l_new++];
            }
            while(r_new < rArray.Count)
            {
                A[k++] = rArray[r_new++];
            }
        }
        public static void MergeSortedArrayRun()
        {
            List<int> A = [];
            List<int> B = [];
            List<int> C = new List<int>();

        }
        private static void MergeSortedArray(List<int> A,List<int> B,List<int> C)
        {
            int i = 0,j=0,k=0;
            int N = A.Count, M = B.Count;

            while(i < N && j< M)
            {
                if (A[i] < B[j])
                {
                    C.Add(A[i]);
                    i++;
                }
                else
                {
                    C.Add(B[j]);
                    j++;
                }
            }
            while (i < N)
            {
                C.Add(A[i]); 
                i++;
            }
            while (j < M)
            {
                C.Add(B[j]);
                j++;
            }
        }
    }
}
