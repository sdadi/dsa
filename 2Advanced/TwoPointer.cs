using System.Collections.Generic;
using System;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;

namespace _2Advanced
{
    internal class TwoPointer
    {
        public static void ContainerWithMaxWater()
        {
            //List<int> A = [1, 5, 4, 3]; //6

            List<int> A = [1];//0

            int left = 0, right = A.Count - 1;
            int result = 0;
            while(left < right)
            {
                int area = (right - left) * Math.Min(A[left], A[right]);
                result = Math.Max(result, area);

                if (A[left] == A[right])
                {
                    left++;
                    right--;
                } 
                else if (A[left] < A[right])
                {
                    left++;
                }
                else 
                    right--;
            }

            Console.WriteLine(result);
        }
        /// <summary>
        /// Given an array of positive integers A and an integer B, find and return first continuous subarray which adds to B.
        /// If the answer does not exist return an array with a single integer "-1".
        /// First sub-array means the sub-array for which starting index in minimum.
        /// 1 <= length of the array <= 100000
        /// 1 <= A[i] <= 10^9
        /// 1 <= B <= 10^9
        /// </summary>
        public static void SubArrayWithSum()
        {
            //List<int> A = [1, 2, 3, 4, 5];
            //int B = 5;//[2,3]


            List<int> A = [5, 10, 20, 100, 105];
            int B = 110;//[-1]

            int left = 0, right = 0;
            int N = A.Count;
            int sum = A[0];
            var result = new List<int>(2);

            while(right < N)
            {
                if(sum == B)
                {
                    result.Add(A[left]);
                    result.Add(A[right]);
                    break;
                }
                else if(sum < B)
                {
                    right++;
                   if(right < N)
                        sum += A[right];
                }
                else
                {
                    sum -= A[left++];
                }
            }
            if (result.Count == 0)
                Console.WriteLine(-1);
            else
                Console.WriteLine($"[{result[0]},{result[1]}]");
        }
        /// <summary>
        /// Given an one-dimensional integer array A of size N and an integer B.
        /// Count all distinct pairs with difference equal to B.
        /// Here a pair is defined as an integer pair(x, y), where x and y are both numbers in the array and their absolute difference is B.
        /// Problem Constraints
        /// 1 <= N <= 10^4
        /// 0 <= A[i], B <= 10^5
        /// </summary>
        public static void PairsWithGiveDifference()
        {
            List<int> A = [1, 5, 3, 4, 2];
            int B = 3;//2

            //List<itn> A = [8, 12, 16, 4, 0, 20];
            //int B = 4;//5


            //List<int> A = [1, 1, 1, 2, 2];
            //int B = 0;//2

            int left = 0, right = 1;
            int result = 0;

            while(left < right)
            {
                if (A[right] - A[left] == B)
                {
                    result++;
                }
            }

        }

        /// <summary>
        /// Given a sorted array of integers (not necessarily distinct) A and an integer B, 
        /// find and return how many pair of integers ( A[i], A[j] ) such that i != j have sum equal to B.
        /// Since the number of such pairs can be very large, return number of such pairs modulo(109 + 7).
        /// Problem Constraints
        /// 1 <= |A| <= 100000
        /// 1 <= A[i] <= 10^9
        /// 1 <= B <= 10^9
        /// </summary>
        public static void PairsWithSumInArrayDuplicates()
        {
            //List<int> A = [1, 1, 1];
            //int B = 2;//3


            //List<int> A = [1, 5, 7, 10];
            //int B = 8;//1

            //List<int> A = [2, 2, 3, 4, 4, 5, 6, 7, 10];
            //int B = 8;

            List<int> A = [979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702, 979702];
            int B = 241993;//

            int result = 0, mod = 1000000007;
            int left = 0, right = A.Count - 1;
            while (left < right)
            {
                int x = A[left];
                int y = A[right];
                int cntL = 0,cntR = 0;

                if(x == y)
                {
                    if(x+y == B)
                    {
                        int cnt = right - left + 1;
                        result += (((cnt % mod) * ((cnt - 1) % mod) / 2) % mod) % mod;
                    }
                    break;
                }

                if (x + y == B)
                {
                    while (A[left] == x) { cntL++; left++; }
                    while (A[right] == y) { cntR++; right--; }
                    result += ((cntL%mod) * (cntR%mod))%mod;

                }
                else if (x + y < B)
                {
                    while (A[left] == x) { left++; }
                }
                else
                {
                    while (A[right] == y) { right--; }
                }
            }

            Console.WriteLine(result);
        }
        public static void PairKExist()
        {
            List<int> A = [-3, 0, 1, 2, 5, 6, 8, 11];
            int B = 8;

            bool exist = false;
            int left = 0, right = A.Count;

            while(left < right)
            {
                if (A[left] + A[right] == B)
                {
                    exist = true; 
                    break;
                }
                if (A[left] + A[right] > B)
                    right--;
                else
                    left++;
            }
        }
    }
}
