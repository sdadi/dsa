using System.Buffers.Text;
using System.Drawing;
using System.Xml;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;

namespace _4Advanced
{
    internal class DP_2
    {
        #region N digit numbers
        /// <summary>
        /// Find out the number of A digit positive numbers, whose digits on being added equals to a given number B.
        /// Note that a valid number starts from digits 1-9 except the number 0 itself.i.e.leading zeroes are not allowed.
        /// Since the answer can be large, output answer modulo 1000000007
        /// Problem Constraints
        /// 1 <= A <= 1000
        /// 1 <= B <= 10000
        /// </summary>
        public static void NDigitSum1()
        {
            int A = 2;
            int B = 4;//4

            //A = 1; B = 3;//1

            int mod = 1000000007;
            var dp = new List<List<int>>();
            for (int i = 0; i <= A; i++)
            {
                dp.Add(new List<int>(Enumerable.Repeat<int>(0, B+1)));
            }

            for (int i = 1;i < 10 &&  i <= B; i++)
            {
                dp[1][i] = 1;
            }

            for (int i = 2; i <= A; i++)
            {
                for(int j=1; j <= B; j++)
                {
                    for(var d=0; d < 10; d++)
                    {
                        if(j >= d)
                        {
                            dp[i][j] = (dp[i][j] % mod + dp[i - 1][j - d] % mod) % mod;

                        }
                    }
                }
            }
            Console.WriteLine(dp[A][B]);
        }
        public static void NDigitSum()
        {
            int A = 2;
            int B = 4;//4

            //A = 1; B = 3;//1

            var dp = new List<List<int>>();
            for (int i = 0; i < A; i++)
            {
                var row = new List<int>();
                for (int j = 0; j < B; j++)
                {
                    row.Add(-1);
                }
                dp.Add(row);
            }
            int mod = 1000000007;

            int ans = 0;
            for (int i = 1; i < 10; i++)
            {
                ans += NDigitSumRecursive(dp, A - 1, B - i);
                ans %= mod;
            }
            Console.WriteLine(ans);
        }

        private static int NDigitSumRecursive(List<List<int>> dp, int digit, int sum)
        {
            if (sum < 0) return 0;
            if (digit == 0 && sum == 0) return 1;
            if (digit == 0) return 0;
            if (dp[digit][sum] != -1) return dp[digit][sum];

            int ans = 0;
            int mod = 1000000007;

            for (int i = 0; i < 10; i++)
            {
                ans += NDigitSumRecursive(dp, digit - 1, sum - i);
                ans %= mod;
            }
            dp[digit][sum] = ans;
            return ans;
        } 
        #endregion


        /// <summary>
        /// Given a grid of size n * m, lets assume you are starting at (1,1) and your goal is to reach (n, m). 
        /// At any instance, if you are on(x, y), you can either go to(x, y + 1) or(x + 1, y).
        /// Now consider if some obstacles are added to the grids.
        /// Return the total number unique paths from(1, 1) to(n, m).
        /// Note: 1. An obstacle is marked as 1 and empty space is marked 0 respectively in the grid.
        /// 2. Given Source Point and Destination points are 1-based index.
        /// Problem Constraints
        /// 1 <= n, m <= 100
        /// A[i][j] = 0 or 1
        /// </summary>
        public static void UniquePathsInGrid()
        {
            List<List<int>> A = [
                                    [0, 0, 0],
                                    [0, 1, 0],
                                    [0, 0, 0]
                                 ];//2

            //A = [
            //       [0, 0, 0],
            //        [1, 1, 1],
            //        [0, 0, 0],
            //     ];//0

            A = [[1, 0]];//0
            A = [[0, 1]];//0
            A = [[0]];//1
            //A = [[1]];//0

            var ways = new List<List<int>>();
            for (int r = 0; r < A.Count; r++)
            {
                var row = new List<int>();
                for(int c = 0; c < A[0].Count; c++)
                {
                    if (r == 0 && c == 0 && A[r][c] == 0)
                        row.Add(1);
                    else if (r == 0 && c == 0 && A[r][c] == 1)
                        row.Add(0);
                    else
                        row.Add(-1);
                }
                ways.Add(row);
            }

            UniquePathsInGridRec(A, ways, A.Count - 1, A[0].Count - 1);
            Console.WriteLine(ways[A.Count - 1][A[0].Count-1] == -1 ? 0: ways[A.Count - 1][A[0].Count-1]);
        }
        private static int UniquePathsInGridRec(List<List<int>> A, List<List<int>> ways,int r, int c)
        {
            if (r == 0 && c == 0) return (A[r][c] == 1)?0:1;
            if(r < 0 || c < 0 ) return 0;
            if (A[r][c] == 1) return 0;
            if (ways[r][c] != -1) return ways[r][c];

            ways[r][c] = UniquePathsInGridRec(A, ways, r, c - 1) + UniquePathsInGridRec(A, ways, r - 1, c);
            return ways[r][c];
        }

        /// <summary>
        /// The demons had captured the princess and imprisoned her in the bottom-right corner of a dungeon. The dungeon consists of M x N rooms laid out in a 2D grid. Our valiant knight was initially positioned in the top-left room and must fight his way through the dungeon to rescue the princess.
        /// The knight has an initial health point represented by a positive integer.If at any point his health point drops to 0 or below, he dies immediately.
        /// Some of the rooms are guarded by demons, so the knight loses health (negative integers) upon entering these rooms; other rooms are either empty(0's) or contain magic orbs that increase the knight's health (positive integers).
        /// In order to reach the princess as quickly as possible, the knight decides to move only rightward or downward in each step.
        /// Given a 2D array of integers A of size M x N.Find and return the knight's minimum initial health so that he is able to rescue the princess.
        /// Problem Constraints
        /// 1 <= M, N <= 500
        /// -100 <= A[i] <= 100
        /// </summary>
        public static void DungeonPrincess()
        {
            List<List<int>> A = [
                                   [-2, -3, 3],
                                   [-5, -10, 1],
                                   [10, 30, -5]
                                 ];//7


            //A = [
            //      [1, -1, 0],
            //       [-1, 1, -1],
            //       [1, 0, -1]
            //    ];//1

            A = [[-5]];//6
            A = [[-5, 6]];//6
            A = [[-3],
                    [-1]
                ];//5

            int N = A.Count, M = A[0].Count;

            var health = new List<List<int>>();
            for(int r =0; r < N; r++)
            {
                var row = new List<int>();
                for(int c = 0; c < M; c++)
                {
                    row.Add(0);
                }
                health.Add(row);
            }

            for(int r = N-1; r >= 0; r--)
            {
                for(int c = M-1; c >= 0; c--)
                {
                    if (r == N - 1 && c == M-1)
                        health[r][c] = Math.Max(1, 1 - A[r][c]);
                    else if(r == N - 1)
                        health[r][c] = Math.Max(1, health[r][c+1] - A[r][c]);
                    else if(c == M-1)
                        health[r][c] = Math.Max(1, health[r + 1][c] - A[r][c]);
                    else
                    {
                        health[r][c] = Math.Max(1, Math.Min(health[r + 1][c], health[r][c + 1]) - A[r][c]);
                    }
                }
            }
            Console.WriteLine(health[0][0]);
        }

        /// <summary>
        /// Given an integer A, how many structurally unique BST's (binary search trees) exist that can store values 1...A?
        /// Problem Constraints
        /// 1 <= A <=18
        /// </summary>
        public static void UniqueBSTCount()
        {
            int A = 1;//1

            A = 2;//2

            var catalan = new List<int> { 1, 1 };
            for (int i = 2; i <= A; i++)
                catalan.Add(0);
            
            for(int i=2;i<=A; i++)
            {
                for(int j=0;j<= i - 1; j++)
                {
                    catalan[i] += catalan[j] * catalan[i-j - 1];
                }
            }
            Console.WriteLine(catalan[A]);
        }
    }
}
