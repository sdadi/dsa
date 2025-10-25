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
        /// 1 <= length of the array <= 10^5
        /// 1 <= A[i] <= 10^9
        /// </summary>
        public static void InverseCountRun()
        {
            //List<int> A = [1, 3, 2];//1
            List<int> A = [3, 4, 1, 2];//4
            //List<int> A = [45, 10, 15, 25, 50];//3
            Console.WriteLine("Input array");
            ArrayExtension.PrintArray(A);
            Console.WriteLine("----------------------");
            MergeSort(A,0,A.Count - 1);
            ArrayExtension.PrintArray(A);
            Console.WriteLine($"Inversion Count: {inversionCount}");
        }
        private static int inversionCount = 0;

        public static void MergeSortRun()
        {
            List<int> A = [1, 3, 2];
            //List<int> A = [3, 4, 1, 2];
            //List<int> A = [45, 10, 15, 25, 50];
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
            int mod = 1000000007;
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

            int start = l, l_new = 0, r_new = 0;

            while(l_new < (lArray.Count) && r_new < (rArray.Count))
            {
                if (lArray[l_new] <= rArray[r_new])
                {
                    A[start++] = lArray[l_new++];
                }
                else
                {
                    A[start++] = rArray[r_new++];
                    inversionCount = (inversionCount%mod + (lArray.Count - l_new)%mod)%mod;
                }
            }
            while(l_new < lArray.Count)
            {
                A[start++] = lArray[l_new++];
            }
            while(r_new < rArray.Count)
            {
                A[start++] = rArray[r_new++];
            }
        }

        /// <summary>
        /// Given two sorted integer arrays A and B, merge B and A as one sorted array and return it as an output.
        /// Note: A linear time complexity is expected and you should avoid use of any library function.
        /// -2×10^9 <= A[i], B[i] <= 2×10^9
        /// 1 <= |A|, |B| <= 5×10^4
        /// </summary>
        public static void MergeSortedArrayRun()
        {
            //List<int> A = [1];
            //List<int> B = [2];

            List<int> A = [4, 7,8, 9];
            List<int> B = [2,8,9, 11, 19];

            List<int> C = new List<int>();

            MergeSortedArray(A, B, C);

            ArrayExtension.PrintArray(C);
        }
        private static void MergeSortedArray(List<int> A,List<int> B,List<int> C)
        {
            int i = 0,j=0;
            int N = A.Count, M = B.Count;

            while(i < N && j< M)
            {
                if (A[i] < B[j])
                {
                    C.Add(A[i++]);
                }
                else
                {
                    C.Add(A[j++]);
                }
            }
            while (i < N)
            {
                C.Add(A[i++]); 
            }
            while (j < M)
            {
                C.Add(B[j++]);
            }
        }
    }
}
