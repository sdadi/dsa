using System.Drawing;
using System.Xml.Linq;

namespace _4Advanced
{
    internal class DP_3
    {

        /// <summary>
        /// Given two integer arrays A and B of size N each which represent values and weights associated with N items respectively.
        /// Also given an integer C which represents knapsack capacity.
        /// Find out the maximum total value that we can fit in the knapsack.
        /// If the maximum total value is ans, then return ⌊ans × 100⌋ , i.e., floor of (ans × 100).
        /// NOTE:
        /// You can break an item for maximizing the total value of the knapsack
        /// Problem Constraints
        /// 1 <= N <= 10^5
        /// 1 <= A[i], B[i] <= 10^3
        /// 1 <= C <= 10^3
        /// </summary>
        public static void FractionalKnapsack()
        {
            List<int> A = [60, 100, 120];
            List<int> B = [10, 20, 30];
            int C = 50;//24000

            A = [10, 20, 30, 40];
            B = [12, 13, 15, 19];
            C = 10;//2105

            var list = new List<KPFPair>();
            for (int i = 0; i < A.Count; i++)
            {
                list.Add(new KPFPair(A[i], B[i]));
            }
            list.Sort(new KPFComparator());
            decimal result = 0, weight = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (weight >= C) break;

                if (list[i].weight <= C - weight)
                {
                    result += list[i].value * 100;
                    weight += list[i].weight;
                }
                else
                {
                    result += list[i].fraction * (C - weight);
                    weight += (C - weight);
                }
            }
            Console.WriteLine($"result is {(int)result} with weight {weight}");
        }
        class KPFPair
        {
            public int value;
            public int weight;
            public decimal fraction;
            public KPFPair(int val, int wgt)
            {
                value = val;
                weight = wgt;
                fraction = ((decimal)value / weight) * 100;
            }
        }
        class KPFComparator : IComparer<KPFPair>
        {
            public int Compare(KPFPair x, KPFPair y)
            {
                //return (y.value / y.weight) - (x.value / x.weight);
                //return (int)(y.fraction*100) - (int)(x.fraction*100);
                return (int)(y.fraction - x.fraction);
            }
        }

        /// <summary>
        /// Problem Description
        /// Given two integer arrays A and B of size N each which represent values and weights associated with N items respectively.
        /// Also given an integer C which represents knapsack capacity.
        /// Find out the maximum value subset of A such that sum of the weights of this subset is smaller than or equal to C.
        /// NOTE:
        /// You cannot break an item, either pick the complete item, or don’t pick it (0-1 property).
        /// Problem Constraints
        /// 1 <= N <= 10^3
        /// 1 <= C <= 10^3
        /// 1 <= A [i], B [i] <= 10^3
        /// </summary>
        public static void Knapsack0_1()
        {
            List<int> A = [60, 100, 120];// values
            List<int> B = [10, 20, 30]; //weights
            int C = 50;//bag weight capacity --result : 220 -- 

            //A = [10, 20, 30, 40];
            //B = [12, 13, 15, 19];
            //C = 10;//0

            A = [359, 963, 465, 706, 146, 282, 828, 962, 492];
            B = [96, 43, 28, 37, 92, 5, 3, 54, 93];
            C = 383;//5057

            var dp = new List<List<int>>();
            for (int i = 0; i <= A.Count; i++)
            {
                var row = new List<int>();
                for (int j = 0; j <= C; j++)
                {
                    row.Add(0);
                }
                dp.Add(row);
            }

            for (int i = 0; i <= A.Count; i++)
            {
                for (int j = 0; j <= C; j++)
                {
                    if (i == 0) dp[i][j] = 0;
                    else if (j >= B[i - 1])
                    {
                        dp[i][j] = Math.Max(dp[i - 1][j], (dp[i - 1][j - B[i - 1]] + A[i - 1]));
                    }
                    else
                        dp[i][j] = dp[i - 1][j];
                }
            }
            Console.WriteLine(dp[A.Count][C]);

            var result = new List<int>();
            for (int i = 0; i <= C; i++)
                result.Add(0);
            for (int i = 0; i < A.Count; i++)
            {
                for (int j = C; j >= B[i]; j--)
                {
                    int ans = A[i] + result[j - B[i]];
                    result[j] = Math.Max(result[j], ans);
                }
            }
            Console.WriteLine(result[C]);
        }

        /// <summary>
        /// Given a knapsack weight A and a set of items with certain value B[i] and weight C[i], 
        /// we need to calculate maximum amount that could fit in this quantity.
        /// This is different from classical Knapsack problem, 
        /// here we are allowed to use unlimited number of instances of an item.
        /// Problem Constraints
        /// 1 <= A <= 1000
        /// 1 <= |B| <= 1000
        /// 1 <= B[i] <= 1000
        /// 1 <= C[i] <= 1000
        /// </summary>
        public static void UnboundedKnapsack()
        {
            int A = 10;
            List<int> B = [5];//values
            List<int> C = [10];//weights - 5

            //A = 10;
            //B = [6, 7];
            //C = [5, 5];//14


            var dp = new List<int>(Enumerable.Repeat<int>(0, A + 1));//max total happiness with i items
            //for (int i = 0; i <= A; i++)
            //    dp.Add(0);
            for (int i = 0; i <= A; i++)
            {
                for (int j = 0; j < B.Count; j++)
                {
                    if (C[j] <= i)
                    {
                        dp[i] = Math.Max(dp[i], dp[i - C[j]] + B[j]);
                    }
                }
            }

            Console.WriteLine(dp[A]);
        }

        /// <summary>
        /// Given an array A of positive elements, you have to flip the sign of some of its elements such that, 
        /// the resultant sum of the elements of array should be minimum non-negative(as close to zero as possible).
        /// Return the minimum number of elements whose sign needs to be flipped such that,
        /// the resultant sum is minimum non-negative.
        /// Problem Constraints
        /// 1 <= length of(A) <= 100
        /// Sum of all the elements will not exceed 10,000.
        /// </summary>
        public static void FlipArray()
        {
            List<int> A = [15, 10, 6];//1

            A = [14, 10, 4];//1

            A = [8, 4, 5, 7, 6, 2];//3

            int sum = 0, N = A.Count;
            foreach (int i in A)
                sum += i;
            sum = sum / 2;

            var dp = new List<List<int>>();

            for (int i = 0; i <= N; i++)
            {
                dp.Add(new List<int>(Enumerable.Repeat<int>(0, sum + 1)));
            }

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    if (j - A[i - 1] == 0) dp[i][j] = 1;
                    else if (j - A[i - 1] > 0 && dp[i - 1][j - A[i - 1]] > 0)
                    {
                        if (dp[i - 1][j] > 0)
                            dp[i][j] = Math.Min(dp[i - 1][j], 1 + dp[i - 1][j - A[i - 1]]);
                        else
                            dp[i][j] = 1 + dp[i - 1][j - A[i - 1]];
                    }
                    else
                    {
                        dp[i][j] = dp[i - 1][j];
                    }
                }
            }
            Console.WriteLine(dp[N][sum]);

            #region Better approach
            var result = new List<int>(Enumerable.Repeat(0, sum+1));
            
            for (int i = 0; i < A.Count; i++)
            {
                for (int j = sum; j >= A[i];j--)
                {
                    if (j - A[i] == 0)
                        result[j] = 1;
                    else if (result[j - A[i]] > 0)
                    {
                        if (result[j] > 0)
                            result[j] = Math.Min(result[j], 1 + result[j - A[i]]);
                        else
                            result[j] = 1 + result[j - A[i]];
                    }
                }
            }
            Console.WriteLine(result[sum]);
            #endregion
        }
    }
}
