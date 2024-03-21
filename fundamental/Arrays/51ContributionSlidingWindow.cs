using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace fundamental.Arrays
{
    internal class ContributionSlidingWindow
    {
        internal static void MaxSubArraySum()
        {
            int A = 9, B = 14;
            List<int> C = [1, 2, 4, 4, 5, 5, 5, 7, 5];
            int maxSum = int.MinValue;

            for (int l = 0; l < A; l++)
            {
                int sum = 0;
                for (int r = l; r < A; r++)
                {
                    sum += C[r];
                    if (sum > maxSum)
                        if (sum <= B)
                            maxSum = sum;
                }
            }
            maxSum = maxSum == int.MinValue ? 0 : maxSum;
            Console.WriteLine(maxSum);
        }
        internal static void SubArraysCountSumLessThanB()
        {
            List<int> A = [2, 5, 6];
            int B = 10;
            int count = 0;

            for (int l = 0; l < A.Count; l++)
            {
                int sum = 0;
                for (int r = l; r < A.Count; r++)
                {
                    sum += A[r];
                    if (sum < B)
                        count++;
                }
            }
            Console.WriteLine($"{count} subarrays with sum less than {B}");
        }
        internal static void GoodSubArrays()
        {
            List<int> A = [13, 16, 16, 15, 9, 16, 2, 7, 6, 17, 3, 9];// [1, 2, 3, 4, 5];
            int B = 65;// 4;//subarray sum
            int oddCount = 0,evenCount=0;

            for(int l = 0;l < A.Count; l++)
            {
                int sum = 0;
                int i = 1;
                for(int r=l;r < A.Count; r++)
                {
                    sum += A[r];
                    if (i % 2 == 0 && sum < B)
                        evenCount++;
                    else if (i % 2 != 0 && sum > B)
                        oddCount++;
                    i++;
                }
            }

            Console.WriteLine($"Good subarrays count is {oddCount+evenCount} with odd {oddCount} and even {evenCount}");
        }
        internal static void SubArrayBLeastAvg()
        {
            //List<int> A = [3, 7, 90, 20, 10, 50, 40];
            //int B = 3;//subarraylength;
            List<int> A = [20, 3, 13, 5, 10, 14, 8, 5, 11, 9, 1, 11];// [3, 7, 5, 20, -10, 0, 12];
            int B = 9;

            int sum = 0;
            for(int i=0;i< B; i++)
            {
                sum += A[i];
            }
            decimal avg = (decimal)sum / B;
            int index = 0;
            
            for(int l=B;l < A.Count; l++)
            {
                sum += A[l] - A[l - B];
                decimal av = (decimal)sum / B;
                if (av < avg)
                {
                    avg = av;
                    index = l-B+1 ;
                }
            }
            Console.WriteLine($"least average is {avg} and starting index of element is {index}");
        }
        internal static void MinSwaps()
        {
            //List<int> A = [52, 7, 93, 47, 68, 26, 51, 44, 5, 41, 88, 19, 78, 38, 17, 13, 24, 74, 92, 5, 84, 27, 48, 49, 37, 59, 3, 56, 79, 26, 55, 60, 16, 83, 63, 40, 55, 9, 96, 29, 7, 22, 27, 74, 78, 38, 11, 65, 29, 52, 36, 21, 94, 46, 52, 47, 87, 33, 87, 70];
            List<int> A = [1, 12, 10, 3, 14, 10, 5];
            int B = 8;
            foreach(int i in A) { Console.Write(i + " "); }
            
            int count = 0;

            foreach(int i in A) { if(i <= B) count++; }
            int result = 0;
            for(int i = 0; i < count; i++)
            {
                if (A[i] > B) result++;
            }
            int minCount = result;
            for(int i = 1; i < A.Count-count; i++)
            {
                if (A[i - 1] > B && A[i + count - 1] <= B)
                    result--;
                if (A[i - 1] <= B && A[i + count - 1] > B)
                    result++;
                if(result < minCount) minCount = result;
            }
            
            Console.WriteLine();
            Console.WriteLine(minCount);
            foreach (int i in A) { Console.Write(i + " "); }

        }
        internal static void SubArrayofLengthBSumCExist()
        {
            List<int> A = [6];
            int N = A.Count;
            int B = 1;//subarray length
            int C = 6;//subarray sum
            
            int sum = 0;
            for(int i = 0; i < B; i++)
            {
                sum += A[i];
            }
            if (N == B && sum == C)
                Console.WriteLine($"Subarray with sum {C} exists");
            for (int right = B; right < N; right++)
            {
                int left = right - B;
                sum += A[right] - A[left];
                if(sum == C)
                {
                    Console.WriteLine($"Subarray with sum {C} exists");
                }    

            }

            Console.WriteLine($"Subarray with sum {C} doesn't exists");
        }
    }
}
