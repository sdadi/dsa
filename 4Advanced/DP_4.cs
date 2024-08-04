namespace _4Advanced
{
    internal class DP_4
    {
        #region Cutting a Rod
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
        #endregion

        #region Coin Sum Infinite
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
            var dp = new List<int>(Enumerable.Repeat<int>(0, B + 1));
            //for (int i = 0; i <= B; i++)
            //    dp.Add(0);
            dp[0] = 1;
            int mod = 1000007;

            #region Ordered Selection -> more combinations
            //for (int i = 1; i <= B; i++)//sum of coins
            //{
            //    for (int j = 0; j < A.Count; j++)//index of array
            //    {
            //        if (A[j] <= i)
            //            dp[i] = dp[i] + dp[i - A[j]];
            //    }
            //} 
            #endregion
            #region Unordered selection -> combination not repeated
            for (int i = 0; i < N; i++)//index of array
            {
                for (int j = 1; j <= B; j++)//sum of coins
                {
                    if (A[i] <= j)
                        dp[j] = (dp[j] % mod + dp[j - A[i]] % mod) % mod;
                }
            }
            #endregion

            Console.WriteLine((int)(dp[B] % mod));
        }
        #endregion

        #region 0-1 Knapsack II
        /// <summary>
        /// Given two integer arrays A and B of size N each which represent values and weights associated with N items respectively.
        /// Also given an integer C which represents knapsack capacity.
        /// Find out the maximum value subset of A such that sum of the weights of this subset is smaller than or equal to C.
        /// NOTE: You cannot break an item, either pick the complete item, or don’t pick it (0-1 property).
        /// Problem Constraints
        /// 1 <= N <= 500
        /// 1 <= C, B [i] <= 10^6
        /// 1 <= A [i] <= 50
        /// </summary>
        public static void Knapsack0_1()
        {
            List<int> A = [6, 10, 12];
            List<int> B = [10, 20, 30];
            int C = 50;//22

            //A = [1, 3, 2, 4];
            //B = [12, 13, 15, 19];
            //C = 10;//0

            A = [18, 35, 1, 20, 25, 29, 9, 13, 15, 6, 46, 32, 28, 12, 42, 46, 43, 28, 37, 42, 5, 3, 4, 43, 33, 22, 17, 19, 46, 48, 27, 22, 39, 20, 13, 18, 50, 36, 45, 4, 12, 23, 34, 24, 15, 42, 12, 4, 19, 48, 45, 13, 8, 38, 10, 24, 42, 30, 29, 17, 36, 41, 43, 39, 7, 41, 43, 15, 49, 47, 6, 41, 30, 21, 1, 7, 2, 44, 49, 30, 24, 35, 5, 7, 41, 17, 27, 32, 9, 45, 40, 27, 24, 38, 39, 19, 33, 30, 42, 34, 16, 40, 9, 5, 31, 28, 7, 24, 37, 22, 46, 25, 23, 21, 30, 28, 24, 48, 13, 37, 41, 12, 37, 6, 18, 6, 25, 32, 3, 1, 1, 42, 25, 17, 31, 8, 42, 8, 38, 8, 38];
            B = [3652, 5620, 2574, 3471, 3957, 4692, 4855, 3740, 991, 5446, 5089, 2066, 4314, 1740, 2476, 1798, 4994, 3206, 5406, 4370, 3471, 3350, 5458, 6175, 4982, 4908, 3504, 4251, 3804, 893, 5139, 3420, 3263, 2234, 2851, 1815, 5971, 1644, 3276, 1454, 2193, 1766, 4670, 1177, 2712, 1593, 5798, 3759, 4293, 5488, 5232, 4670, 2768, 5252, 1561, 5195, 3396, 206, 5801, 5381, 4786, 3923, 2488, 4077, 1170, 3607, 2707, 4420, 5189, 1150, 2848, 4085, 1618, 1004, 5853, 1801, 4675, 2103, 4535, 5587, 3603, 4176, 4239, 5384, 3981, 1067, 5498, 4585, 5126, 5766, 2509, 3762, 3696, 3845, 5401, 4180, 1494, 1705, 4219, 3584, 252, 1672, 4467, 5470, 5473, 1460, 1743, 1637, 1292, 2491, 1367, 1531, 4693, 5524, 1604, 2675, 3483, 5577, 1390, 5271, 2833, 931, 3553, 3622, 2825, 3333, 4988, 3127, 451, 3774, 5249, 1886, 3543, 2042, 3272, 2971, 3624, 4364, 3204, 5095, 4711];
            C = 809580;//3643

            int N = A.Count;
            var dp = new List<List<int>>();
            for (int i = 0; i <= N; i++)
            {
                dp.Add(new List<int>(Enumerable.Repeat(0, C+ 1)));
            }

            for (int h = 1; h <= N; h++)//happiness
            {
                for (int w = 0; w <= C; w++)//weight
                {
                    if (h == 0 || w == 0) dp[h][w] = 0;// no happiness or no weight selection
                    else if (w >= B[h-1])
                    {
                        dp[h][w] = Math.Max(dp[h - 1][w], dp[h - 1][w - B[h-1]] + A[h-1]);
                    }
                    else
                    {
                        dp[h][w] = dp[h - 1][w];
                    }
                }
            }
            Console.WriteLine(dp[N][C]);



            var result = new int[C + 1];
            for (int i = 0; i < N; i++)
            {
                for (int j = C; j >= B[i]; j--)
                {
                    result[j] = Math.Max(result[j], result[j - B[i]] + A[i]);
                }
            }
            Console.WriteLine(result[C]);
        }
        #endregion
    }
}
