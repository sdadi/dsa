using System.Data;
using System.Numerics;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _4Advanced
{
    internal class DP_1
    {
        /// <summary>
        /// Given a positive integer A, write a program to find the Ath Fibonacci number.
        /// In a Fibonacci series, each term is the sum of the previous two terms and 
        /// the first two terms of the series are 0 and 1. i.e.f(0) = 0 and f(1) = 1. Hence, f(2) = 1, f(3) = 2, f(4) = 3 and so on.
        /// NOTE: 0th term is 0. 1th term is 1 and so on.
        /// Problem Constraints
        /// 0 <= A <= 44
        /// </summary>
        public static void FibonacciNumber()
        {
            int A = 4;//3
            //A = 6;//8

            int a = 0, b = 1, c = 1;

            for (int i = 2; i <= A; i++)
            {
                c = a + b;
                a = b; 
                b = c;
            }
            Console.WriteLine(c);
        }

        /// <summary>
        /// You are climbing a staircase and it takes A steps to reach the top.Each time you can either climb 1 or 2 steps.
        /// In how many distinct ways can you climb to the top?
        /// Return the number of distinct ways modulo 1000000007
        /// Problem Constraints
        /// 1 <= A <= 10^5
        /// </summary>
        public static void DistinctWaysOfStairsClimb()
        {
            int A = 2;//2
            //A = 3;//3
            A = 5;//8
            A = 55007;//784052921

            long a = 1, b = 1, c = 2;
            int mod = 1000000007;
            for (int i = 2; i <= A; i++)
            {
                c = (a % mod + b % mod) % mod;
                a = b % mod;
                b = c % mod;
            }
            Console.WriteLine((int)(c%mod));
        }

        /// <summary>
        /// Given an integer A. Return minimum count of numbers, sum of whose squares is equal to A.
        /// Problem Constraints
        /// 1 <= A <= 10^5
        /// </summary>
        public static void MinimumNoOfSquares()
        {
            int A = 6;//3
            //A = 5;//2

            var counts = new List<int>();
            counts.Add(0);
            for(int i = 1; i <= A; i++)
            {
                counts.Add(i);
                for(int x=1;x*x <=i; x++)
                {
                    counts[i] = Math.Min(counts[i], counts[i-x*x]+1);
                }
            }
            Console.WriteLine(counts[A]);
        }

        /// <summary>
        /// Given a 2 x N grid of integers, A, your task is to choose numbers from the grid such that sum of these numbers is maximized. 
        /// However, you cannot choose two numbers that are adjacent horizontally, vertically, or diagonally.
        /// Return the maximum possible sum.
        /// Note: You are allowed to choose more than 2 numbers from the grid.
        /// Problem Constraints
        /// 1 <= N <= 20000
        /// 1 <= A[i] <= 2000
        /// </summary>
        public static void MaxSumWithoutAdjacentElements()
        {
            List<List<int>> A = [
                                   [1],
                                    [2]
                                ];//2

            //A = [
            //        [1, 2, 3, 4],
            //        [2, 3, 4, 5]
            //     ];//8

            A = [[16, 5, 54, 55, 36, 82, 61, 77, 66, 61], [31, 30, 36, 70, 9, 37, 1, 11, 68, 14]];//321
            
            var maxCol = new List<int>();
            var resultSum = new List<int>();
            int maxSum = int.MinValue;

            for (int i = 0; i < A[0].Count; i++)
            {
                maxCol.Add(Math.Max(A[0][i], A[1][i]));
            }
            int a = maxCol[0];
            int b = Math.Max(maxCol[1], a);

            int c = 0;
            for(int i=2;i<maxCol.Count; i++)
            {
                c = Math.Max(a + maxCol[i], b);
                a = b;
                b = c;
            }

            Console.WriteLine(c);
        }

        /// <summary>
        /// Given an integer array A of size N. 
        /// Find the contiguous subarray within the given array (containing at least one number) which has the largest product.
        /// Return an integer corresponding to the maximum product possible.
        /// NOTE: Answer will fit in 32-bit integer value.
        /// Problem Constraints
        /// 1 <= N <= 5 * 10^5
        /// -100 <= A[i] <= 100
        /// </summary>
        public static void MaxProductSubarray()
        {
            List<int> A = [4, 2, -5, 1];//8

            //A = [-3, 0, -5, 0];//0
            A = [-3, 0, 0, 3, 3, 0, 0,-1, -5, 0];//9

            int maxP = A[0], minP = A[0];
            var maxProduct = maxP;
            for(int i=1;i<A.Count; i++)
            {
                if (A[i] < 0)
                {
                    int temp = minP;
                    minP = maxP;
                    maxP = temp;
                }
                maxP = Math.Max(A[i], maxP * A[i]);
                minP = Math.Min(A[i], minP * A[i]);
                maxProduct = Math.Max(maxProduct, maxP);
            }
            Console.WriteLine(maxProduct);
        }

        /// <summary>
        /// A message containing letters from A-Z is being encoded to numbers using the following mapping:
        /// 'A' -> 1
        /// 'B' -> 2
        /// ...
        /// 'Z' -> 26
        /// Given an encoded message denoted by string A containing digits, 
        /// determine the total number of ways to decode it modulo 10^9 + 7.
        /// Problem Constraints
        /// 1 <= length(A) <= 10^5
        /// </summary>
        public static void WaysToDecode()
        {
            string A = "12";//2
            A = "0799733";//0

            int count = 0;
            int mod = 1000000007;
            int[] dp = new int[A.Length+1];
            dp[0] = dp[1] = 1;


            for(int i = 2; i <= A.Length; i++)
            {
                if (A[i-1] >= '1' && A[i-1] <= '9')
                    dp[i] = dp[i - 1];

                if (A[i-2] == '1')
                {
                    dp[i] += dp[i - 2];
                }
                else if( A[i-2] == '2' && A[i-1] > '0' &&A[i-1] < '7')
                {
                    dp[i] += dp[i - 2];
                }
            }
            Console.WriteLine(dp[A.Length]);
        }
    }
}
