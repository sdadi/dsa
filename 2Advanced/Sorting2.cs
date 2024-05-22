using Helpers;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace _2Advanced
{
    internal class Sorting2
    {
        #region Factors sort
        /// <summary>
        /// You are given an array A of N elements. 
        /// Sort the given array in increasing order of number of distinct factors of each element, 
        ///     i.e., element having the least number of factors should be the first to be displayed 
        ///     and the number having highest number of factors should be the last one. 
        /// If 2 elements have same number of factors, then number with less value should come first.
        /// Note: You cannot use any extra space
        /// 1 <= N <= 10^4
        /// 1 <= A[i] <= 10^4
        /// </summary>
        public static void FactorsSort()
        {
            //List<int> A = [6, 8, 9];//[9,8,6]
            //List<int> A = [2, 4, 7];//[2,7,4]
            List<int> A = [36, 13, 13, 26, 37, 28, 27, 43, 7];

            A.Sort(new CompareFactors());

            ArrayExtension.PrintArray(A);
        }
        class CompareFactors:IComparer<int>
        {
            public int Compare(int x, int y)
            {
                int a = Factors(x);
                int b = Factors(y);
                if (a == b)
                    return x - y;
                return a - b;
            }
            private int Factors(int a)
            {
                int cnt = 0;
                for (int i = 1; i * i <= a; i++)
                {
                    if (a % i == 0)
                    {
                        if (i == a / i)
                            cnt++;
                        else
                            cnt += 2;
                    }
                }
                return cnt;
            }
        }
        #endregion

        #region B Closest Point to Origin
        /// <summary>
        /// You are developing a feature for Zomato that helps users find the nearest restaurants to their current location. It uses GPS to determine the user's location and has access to a database of restaurants, each with its own set of coordinates in a two-dimensional space representing their geographical location on a map. The goal is to identify the "B" closest restaurants to the user, providing a quick and convenient way to choose where to eat.
        /// Given a list of restaurant locations, denoted by A(each represented by its x and y coordinates on a map), and an integer B representing the number of closest restaurants to the user.The user's current location is assumed to be at the origin (0, 0).
        /// Here, the distance between two points on a plane is the Euclidean distance.
        /// You may return the answer in any order.The answer is guaranteed to be unique (except for the order that it is in.)
        /// NOTE: Euclidean distance between two points P1(x1, y1) and P2(x2, y2) is sqrt((x1-x2)2 + (y1-y2)2).
        /// 
        /// 1 <= B <= length of the list A <= 10^5
        /// -105 <= A[i][0] <= 10^5
        /// -105 <= A[i][1] <= 10^5
        /// </summary>
        public static void BClosestPointsToOrigin()
        {
            //List<List<int>> A = [
            //                        [1, 3],
            //                        [-2, 2]
            //                    ];
            //int B = 1;//[-2,2]

            List<List<int>> A = [
                                   [1, -1],
                                   [2, -1]
                                 ];
            int B = 1;//[1,-1]

            var result = new List<List<int>>();
            A.Sort(new CompareDistance());

            for (int i = 0; i < B; i++)
            {
                var item = new List<int>();
                item.Add(A[i][0]);
                item.Add(A[i][1]);
                result.Add(item);
            }

            MatrixExtensions.DisplayMatrix(result);
        }
        class CompareDistance : IComparer<List<int>>
        {
            public int Compare(List<int> x, List<int> y)
            {
                int a = x[0] * x[0] + x[1] * x[1];
                int b = y[0] * y[0] + y[1] * y[1];

                if (a == b)
                    return x[0] - y[0];
                else
                    return a - b;
            }
        } 
        #endregion

        /// <summary>
        /// Given an array A of non-negative integers, arrange them such that they form the largest number.
        /// Note: The result may be very large, so you need to return a string instead of an integer.
        /// 1 <= len(A) <= 100000
        /// 0 <= A[i] <= 2*10^9
        /// </summary>
        public static void LargestNumber()
        {
            //List<int> A = [3, 30, 34, 5, 9];//9534330
            //List<int> A = [2, 3, 9, 0];//9320
            List<int> A = [0, 0, 0, 0];

            string result = "";
            A.Sort(new CompareStrings());
            StringBuilder sb = new StringBuilder();
            foreach (var num in A)
            {
                sb.Append(num);
            }
            if (sb[0] == '0')
                result = "0";
            else
                result = sb.ToString();

            Console.WriteLine(result);
        }
        class CompareStrings : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                string a = x.ToString();
                string b = y.ToString();

                string text1 = a + b;
                string text2 = b + a;

                return string.Compare(text2, text1);
            }
        }
        public static void QuickSortRun()
        {
            List<int> A = [23, 5, 66, 11, 8, 20];

            Console.WriteLine("Input Array");
            ArrayExtension.PrintArray(A);

            QuickSort(A, 0, A.Count - 1);

            Console.WriteLine("\nSorted Array");
            ArrayExtension.PrintArray(A);
        }
        private static void QuickSort(List<int> A, int l, int r)
        {
            if (l >= r) return;
            int pivot = Partition(A, l, r);
            QuickSort(A, l, pivot - 1);//sort left
            QuickSort(A, pivot + 1, r);//sort right
        }
        private static int Partition(List<int> A, int l, int r)
        {
            int partition = A[l];
            int l_ind = l;
            while (l <= r)
            {
                if (A[l] <= partition) l++;
                else if (A[r] > partition) r--;
                else Swap(A, l, r);
            }
            Swap(A, l_ind, r);
            return r;
        }
        private static void Swap(List<int> A, int l, int r)
        {
            int temp = A[l];
            A[l] = A[r];
            A[r] = temp;
        }
    }
}
