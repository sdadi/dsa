using Helpers;
using System;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _4Advanced
{
    internal class HashingClass_3
    {
        /// <summary>
        /// Shaggy has an array A consisting of N elements. 
        /// We call a pair of distinct indices in that array a special if elements at those indices in the array are equal.
        /// Shaggy wants you to find a special pair such that the distance between that pair is minimum.
        /// Distance between two indices is defined as |i-j|. If there is no special pair in the array, then return -1.
        /// Problem Constraints
        /// 1 <= |A| <= 10^5
        /// </summary>
        public static void ShaggyAndDistances()
        {
            List<int> A = [7, 1, 3, 4, 1, 7];//3

            //A = [1, 1];//1
            A = [7, 1, 3, 4, 1, 7, 7];//1

            var map = new Dictionary<int, int>();
            int min = int.MaxValue;
            for (int i = 0; i < A.Count; i++)
            {
                if (map.ContainsKey(A[i]))
                {
                    int diff = i - map[A[i]];
                    min = Math.Min(min, diff);
                }
                map[A[i]] = i;
            }
            Console.WriteLine(min == int.MaxValue ? -1 : min);
        }

        /// <summary>
        /// Given an array A of N integers.
        /// Find the length of the longest subarray in the array which sums to zero.
        /// If there is no subarray which sums to zero then return 0.
        /// Problem Constraints
        /// 1 <= N <= 10^5
        /// -10^9 <= A[i] <= 10^9
        /// </summary>
        public static void LongestSubArrayZeroSum()
        {
            List<int> A = [1, -2, 1, 2];//3

            //A = [3, 2, -1]; //0
            //A = [1, 2, 3, 4, -3, -4, 5, 6];//4
            A = [9, -20, -11, -8, -4, 2, -12, 14, 1];

            int longest = 0;
            int N = A.Count;
            long sum = 0;
            var map = new Dictionary<long, int>();
            map.Add(0, -1);

            for (int i = 0; i < N; i++)
            {
                sum += A[i];
                if (map.ContainsKey(sum))
                {
                    int distance = i - map[sum];
                    if (distance > longest)
                        longest = distance;
                }
                else
                {
                    map[sum] = i;
                }
            }
            Console.WriteLine(longest);
        }

        /// <summary>
        /// Misha likes finding all Subarrays of an Array. 
        /// Now she gives you an array A of N elements and told you to find the number of subarrays of A, that have unique elements.
        /// Since the number of subarrays could be large, return value % 109 +7.
        /// Problem Constraints
        /// 1 <= N <= 10^5
        /// 1 <= A[i] <= 10^6
        /// </summary>
        public static void SubArrayCountWithUniqueElements()
        {
            List<int> A = [1, 1, 3];//4

            //A = [2, 1, 2];//5
            A = [93, 9, 12, 32, 97, 75, 32, 77, 40, 79, 61, 42, 57, 19, 64, 16, 86, 47, 41, 67, 76, 63, 24, 10, 25, 96, 1, 30, 73, 91, 70, 65, 53, 75, 5, 19, 65, 6, 96, 33, 73, 55, 4, 90, 72, 83, 54, 78, 67, 56, 8, 70, 43, 63];//775

            int left = 0, right = 0;
            var hashSet = new HashSet<int>();
            int mod = 1000000007;
            long ans = 0;
            while (right < A.Count)
            {
                while (hashSet.Contains(A[right]))
                {
                    hashSet.Remove(A[left]);
                    left++;
                }

                ans = (ans % mod + (right - left + 1) % mod) % mod;
                hashSet.Add(A[right]);
                right++;
            }

            Console.WriteLine((int)(ans % mod));
        }


        public static void SortArrayIn_B_Order()
        {
            List<int> A = [1, 2, 3, 4, 5, 4];
            List<int> B = [5, 4, 2];


            A = [5, 17, 100, 11];
            B = [1, 100];

            var dict = new Dictionary<int, int>();
            var result = new List<int>();
            for (int i = 0; i < A.Count; i++)
            {
                if (!dict.ContainsKey(A[i]))
                    dict.Add(A[i], 0);
                dict[A[i]] = dict[A[i]] + 1;
            }
            for (int i = 0; i < B.Count; i++)
            {
                while (dict.ContainsKey(B[i]))
                {
                    result.Add(B[i]);
                    if (dict[B[i]] == 1)
                        dict.Remove(B[i]);
                    else
                        dict[B[i]] = dict[B[i]] - 1;
                }
            }
            foreach (var kv in dict.OrderBy(k => k.Key))
            {
                while (dict.ContainsKey(kv.Key))
                {
                    result.Add(kv.Key);
                    dict[kv.Key] -= 1;
                    if (kv.Value == 1)
                        break;
                }
            }
            //result.Sort();
            result.PrintArray();
        }

        /// <summary>
        /// Determine the "GOOD"ness of a given string A, where the "GOOD"ness is defined by the length of the longest substring that contains no repeating characters. The greater the length of this unique-character substring, the higher the "GOOD"ness of the string.
        /// Your task is to return an integer representing the "GOOD"ness of string A.
        /// Note: The solution should be achieved in O(N) time complexity, where N is the length of the string.
        /// Problem Constraints
        /// 1 <= size(A) <= 10^6
        /// String consists of lowerCase, upperCase characters and digits are also present in the string A.
        /// </summary>
        public static void LongestSubArrayWithoutRepeat()
        {
            string A = "abcabcbb";//3

            A = "AaaA";//2
            //A = "u";//1
            //A = "dadbc";//4

            int count = 0;
            int result = int.MinValue;
            var dict = new HashSet<char>();
            int left = 0, right = 0;

            while (right < A.Length)
            {
                if (dict.Contains(A[right]))
                {
                    result = Math.Max(result, count);
                    while (dict.Contains(A[right]))
                    {
                        dict.Remove(A[left]);
                        left++;
                        count--;
                    }
                }
                count++;
                dict.Add(A[right]);
                right++;
            }
            result = Math.Max(result, count);

            Console.WriteLine(result);
        }

        /// <summary>
        /// Given a number A, find if it is COLORFUL number or not.
        /// If number A is a COLORFUL number return 1 else, return 0.
        /// What is a COLORFUL Number:
        /// A number can be broken into different consecutive sequence of digits.
        /// The number 3245 can be broken into sequences like 3, 2, 4, 5, 32, 24, 45, 324, 245 and 3245. 
        /// This number is a COLORFUL number, since the product of every consecutive sequence of digits is different
        /// Problem Constraints
        /// 1 <= A <= 2 * 10^9
        /// </summary>
        public static void ColorfulNumber()
        {
            int A = 23;//1

            //A = 236;//0
            A = 263;//1

            int result = 1;
            var prductSet = new HashSet<long>();
            int product = 1;
            var list = new List<int>();

            while (A > 0)
            {
                int mod = A % 10;
                list.Add(mod);
                A = A / 10;
            }
            for(int l=0; l < list.Count; l++)
            {
                product = 1;
                for(int r=l;r<list.Count; r++)
                {
                    product = product * list[r];
                    if (prductSet.Contains(product))
                    {
                        result = 0;
                        break;
                    }
                    prductSet.Add(product);
                }
                if (result == 0)
                    break;
            }


            Console.WriteLine(result);
        }
    }
}
