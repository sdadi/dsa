using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _4Advanced
{
    internal class DP_4
    {
        /// <summary>
        /// Given a rod of length N units and an array A of size N denotes prices that contains prices of all pieces of size 1 to N.
        /// Find and return the maximum value that can be obtained by cutting up the rod and selling the pieces.
        /// Problem Constraints
        /// 1 <= N <= 1000
        /// 0 <= A[i] <= 10^6
        /// </summary>
        public static void CuttingARod()
        {
            List<int> A = [3, 4, 1, 6, 2];//15

            //A = [1, 5, 2, 5, 6];//11

            int N = A.Count;

            var dp = new List<int>(Enumerable.Repeat<int>(0, N + 1));
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    dp[i] = Math.Max(dp[i], dp[i - j] + A[j - 1]);
                }
            }

            Console.WriteLine(dp[N]);
        }

        /// <summary>
        /// You are given a set of coins A. 
        /// In how many ways can you make sum B assuming you have infinite amount of each coin in the set.
        /// NOTE:
        /// Coins in set A will be unique.Expected space complexity of this problem is O(B).
        /// The answer can overflow.So, return the answer % (10^6 + 7).
        /// Problem Constraints
        /// 1 <= A <= 500
        /// 1 <= A[i] <= 1000
        /// 1 <= B <= 50000
        /// </summary>
        public static void CoinSumInfiniteUnique()
        {
            List<int> A = [1, 2, 3];
            int B = 4;//4

            //A = [10];
            //B = 10;//1

            A = [18, 24, 23, 10, 16, 19, 2, 9, 5, 12, 17, 3, 28, 29, 4, 13, 15, 8];
            B = 458;//867621

            int N = A.Count;
            var dp = new List<long>();
            for (int i = 0; i <= B; i++)
                dp.Add(0);
            dp[0] = 1;
            int mod = 10000007;

            for (int i = 0; i < N; i++)//index of array
            {
                for (int j = 1; j <= B; j++)//sum of coins
                {
                    if (A[i] <= j)
                        dp[j] =  (dp[j]%mod + dp[j - A[i]]%mod)%mod;
                }
            }

            Console.WriteLine((int)(dp[B]%mod));
        }
    }
}
