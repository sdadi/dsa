using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using System.Xml.Linq;

namespace _2Advanced
{
    internal class Searching2
    {
        #region MedianOf Sorted Arrays
        /// <summary>
        /// There are two sorted arrays A and B of sizes N and M respectively.
        /// Find the median of the two sorted arrays(The median of the array formed by merging both the arrays ).
        /// NOTE:
        /// The overall run time complexity should be O(log(m+n)).
        /// IF the number of elements in the merged array is even, then the median is the average of(n/2)th and(n/2+1)th element.For example, if the array is [1 2 3 4], the median is (2 + 3) / 2.0 = 2.5.
        /// Problem Constraints
        /// 1 <= N + M <= 2*10^6
        /// </summary>
        public static void MedianOfSortedArrays()
        {
            List<int> A = [2, 3];
            List<int> B = [1, 4, 5];//3.0

            A = [1, 2, 3];
            B = [4];//2.5

            A = [];
            B = [20];//20

            //A = [-50, -41, -40, -19, 5, 21, 28];
            //B = [-50, -21, -10];//-20.0

            int N = A.Count, M = B.Count;
            int S = N + M;
            int size = S / 2;
            int i = 0, j = 0, m1 = -1, m2 = -1;

            for (int count = 0; count <= size; count++)
            {
                m2 = m1;

                if (i < N && (j >= M || A[i] < B[j]))
                {
                    m1 = A[i++];
                }
                else
                {
                    m1 = B[j++];
                }
            }
            double result = (double)m1;
            if (S > 1 && S % 2 == 0)
            {
                result = ((double)(m1 + m2)) / 2;
            }
            Console.WriteLine(result);
        }
        #endregion
        public static void MedianOf2SortedArrays()
        {
            List<int> A = [2, 3];
            List<int> B = [1, 4, 5];//3.0

            A = [1, 2, 3];
            B = [4];//2.5

            A = [];
            B = [20];//20

            //A = [-50, -41, -40, -19, 5, 21, 28];
            //B = [-50, -21, -10];//-20.0

            A = [];
            B = [-35, 5, 11, 34, 35];//11

            A = [-35, 5, 11, 34, 35];
            B = [1, 3, 6, 7, 8];//6.5
            A = [1,2,3,4,5,6,7,8,9,10];
            B = [11,12,13,14,15,16,17,18,19,20];

            int m = A.Count;
            int n = B.Count;
            double result = 0.0;

            int total = m + n;
            int half = (total + 1) / 2;

            int l = 0, r = m;

            while (l <= r)
            {
                int midA = l + (r - l) / 2;
                int midB = half - midA;
                if (midB < 0)
                    midB = 0;

                int leftA = (midA > 0) ? A[midA - 1] : int.MinValue;
                int rightA = (midA < m) ? A[midA] : int.MaxValue;

                int leftB = (midB > 0) ? B[midB - 1] : int.MinValue;
                int rightB = (midB < n) ? B[midB] : int.MaxValue;

                if (leftA <= rightB && leftB <= rightA)
                {
                    int maxLeft = Math.Max(leftA, leftB);
                    int minRight = Math.Min(rightA, rightB);

                    if (total % 2 == 0)
                    {
                        result = (double)((maxLeft + minRight)) / 2;
                        break;
                    }
                    result = maxLeft;
                    break;
                }
                else if (leftA > rightB)
                {
                    r = midA - 1;
                }
                else
                {
                    l = midA + 1;
                }
            }
            Console.WriteLine(result);
        }
        public static void SquareRoot()
        {
            int A = 17;
            int l = 1, r = A;
            int result = 0;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;

                if (mid <= A / mid)
                {
                    result = mid;
                    l = mid + 1;
                }
                else
                    r = mid - 1;
            }

            Console.WriteLine(result);
        }
        /// <summary>
        /// You are given three positive integers, A, B, and C.
        /// Any positive integer is magical if divisible by either B or C.
        /// Return the Ath smallest magical number.Since the answer may be very large, return modulo 109 + 7.
        /// Note: Ensure to prevent integer overflow while calculating.
        /// 1 <= A <= 109
        /// 2 <= B, C <= 40000
        /// </summary>
        public static void AthMagicalNumber()
        {
            int A = 1, B = 2, C = 3;//2


            //int A = 4, B = 2, C = 3;//6
            //int A = 807414236, B = 3788, C = 38141;//238134151


            long l = Math.Min(B, C), r = A * (long)Math.Min(B, C);
            int lcm = LCD(B, C);
            int mod = 1000000007;
            while (l <= r)
            {
                long mid = l + (r - l) / 2;
                long count = mid / B + mid / C - mid / lcm;

                if (count == A && (mid % B == 0 || mid % C == 0))
                {
                    Console.WriteLine((int)(mid % mod));
                    return;
                }

                if (count < A)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
            Console.WriteLine(0);
        }
        private static int LCD(int x, int y)
        {
            int a = x, b = y;
            while (y != 0)
            {
                int temp = y;
                y = x % y;
                x = temp;
            }
            return (a * b) / x;
        }
        /// <summary>Rotated Sorted Array Search</summary>
        public static void RotatedArraySearch()
        {
            //List<int> A = [4, 5, 6, 7, 0, 1, 2, 3];
            //int B = 4;//0

            List<int> A = [9, 10, 3, 5, 6, 8];
            int B = 5;//3

            int N = A.Count;
            int l = 0, r = N - 1;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;

                if (A[mid] == B)
                {
                    Console.WriteLine(mid);
                    return;
                }
                if (B < A[0])//B is in part2
                {
                    if (A[mid] < A[0])// mid in part2
                    {
                        if (B < A[mid])//still in part2
                        {
                            r = mid - 1;
                        }
                        else
                            l = mid + 1;
                    }
                    else//mid is in part 1
                    {
                        l = mid + 1;
                    }
                }
                else//B is in part1
                {
                    if (A[mid] > A[0])// mid is in part1
                    {
                        if (B < A[mid])// B is in part 1
                        {
                            r = mid - 1;
                        }
                        else
                        {
                            l = mid + 1;
                        }
                    }
                    else//mid is in part2
                    {
                        r = mid - 1;
                    }
                }
            }

            Console.WriteLine(-1);
        }
    }
}
