using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            for(int i=0;i<A.Count;i++)
            {
                list.Add(new SalePair(A[i], B[i]));
            }
            list.Sort(SalePair.Comparator);

            int T = 0, mod = 1000000007;
            long profit = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if(T < list[i].expiry)
                {
                    profit += list[i].price%mod;
                    heap.Insert(list[i].price);
                    T++;
                }
                else {
                    int root = heap.PeekMin();
                    if(root != int.MinValue && list[i].price > root)
                    {
                        profit -= heap.GetMin()%mod;// remove min from heap
                        profit += list[i].price%mod;
                        heap.Insert(list[i].price);
                    }
                }
            }
            Console.WriteLine((int)(profit%mod));
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
    }
}
