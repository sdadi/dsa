using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _4Advanced
{
    internal class Greedy
    {
        /// <summary>
        /// In the recent expansion into grocery delivery, Flipkart faces a crucial challenge in effective inventory management. Each grocery item on the platform carries its own expiration date and profit margin, represented by two arrays, A and B of size N. A[i] denotes the time left before expiration date for the ith item, and B[i] denotes profit margin for the ith item. To mitigate potential losses due to expiring items, Flipkart is seeking a strategic solution.
        /// The objective is to identify a method to strategically buy certain items, ensuring they are sold before their expiration date, thereby maximizing overall profit.Can you assist Flipkart in developing an innovative approach to optimize their grocery inventory and enhance profitability?
        /// Your task is to find the maximum profit one can earn by buying groceries considering that you can only buy one grocery item at a time.
        /// NOTE:
        /// You can assume that it takes 1 minute to buy a grocery item, so you can only buy the ith grocery item when the current time <= A[i] - 1.
        /// You can start buying from day = 0.
        /// Return your answer modulo 10^9 + 7.
        /// Problem Constraints
        /// 1 <= N <= 10^5
        /// 1 <= A[i] <= 10^9
        /// 0 <= B[i] <= 10^9
        /// </summary>
        public static void FlipkartChallengeInEffectiveInventoryManagement()
        {
            List<int> A = [1, 3, 2, 3, 3];
            List<int> B = [5, 6, 1, 3, 9];//20

            //A = [3, 8, 7, 5];
            //B = [3, 1, 7, 19];//30

            var heap = new MinHeapClass();
            var list = new List<SalePair>();
            for (int i = 0; i < A.Count; i++)
            {
                list.Add(new SalePair(A[i], B[i]));
            }
            list.Sort(SalePair.Comparator);

            int T = 0, mod = 1000000007;
            long profit = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (T < list[i].expiry)
                {
                    profit += list[i].price % mod;
                    heap.Insert(list[i].price);
                    T++;
                }
                else
                {
                    int root = heap.PeekMin();
                    if (root != int.MinValue && list[i].price > root)
                    {
                        profit -= heap.GetMin() % mod;// remove min from heap
                        profit += list[i].price % mod;
                        heap.Insert(list[i].price);
                    }
                }
            }
            Console.WriteLine((int)(profit % mod));
        }
        class SalePair
        {
            public int expiry;
            public int price;

            public SalePair(int ex, int pr)
            {
                expiry = ex;
                price = pr;
            }

            public static int Comparator(SalePair a, SalePair b)
            {
                if (a.expiry == b.expiry)
                    return b.price - a.price;
                return a.expiry - b.expiry;
            }
        }

        /// <summary>
        /// There are N jobs to be done, but you can do only one job at a time.
        /// Given an array A denoting the start time of the jobs and an array B denoting the finish time of the jobs.
        /// Your aim is to select jobs in such a way so that you can finish the maximum number of jobs.
        /// Return the maximum number of jobs you can finish.
        /// Problem Constraints
        /// 1 <= N <= 10^5
        /// 1 <= A[i] < B[i] <= 10^9
        /// </summary>
        public static void FinishMaximumJobs()
        {
            List<int> A = [1, 5, 7, 1]; //start time
            List<int> B = [7, 8, 8, 8];//2 -- end time

            A = [3, 2, 6];
            B = [9, 8, 9];//1

            var list = new List<JobPair>();
            for (int i = 0; i < A.Count; i++)
            {
                list.Add(new JobPair(A[i], B[i]));
            }
            list.Sort(JobPair.Comparator);
            int sum = 1;
            int end = list[0].end;

            for (int i = 1; i < A.Count; i++)
            {
                if (list[i].start >= end)
                {
                    sum++;
                    end = list[i].end;
                }
            }

            Console.WriteLine(sum);
        }
        class JobPair
        {
            public int start;
            public int end;
            public JobPair(int s, int e) { start = s; end = e; }

            public static int Comparator(JobPair a, JobPair b)
            {
                if (a.end == b.end)
                    return a.start - b.start;
                return a.end - b.end;
            }
        }

        /// <summary>
        /// The monetary system in DarkLand is really simple and systematic. 
        /// The locals-only use coins. The coins come in different values. The values used are:
        /// 1, 5, 25, 125, 625, 3125, 15625, ...
        /// Formally, for each K >= 0 there are coins worth 5K.
        /// Given an integer A denoting the cost of an item, 
        /// find and return the smallest number of coins necessary to pay exactly the cost of the item
        /// (assuming you have a sufficient supply of coins of each of the types you will need).
        /// Problem Constraints
        /// 1 <= A <= 2×10^9
        /// </summary>
        public static void SmallestNoOfCoins()
        {
            int A = 47;//7
            //A = 9;//5
            //A = 33;//5
            //A = 3125;//1


            int count = 0; 
            int mod = 1;
            //while (mod * 5 <= A)
            //{
            //    mod *= 5;
            //}
            //while (A > 0)
            //{
            //    count += A / mod;
            //    A = A % mod;
            //    mod /= 5;
            //} ;

            while(A >= 1)
            {
                count += A % 5;
                A = A / 5;
            }

            Console.WriteLine(count);
        }

    }
}
