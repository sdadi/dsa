using System.Runtime.Serialization;

namespace fundamental.Arrays
{
    internal class SubArray
    {
        public static int solve()
        {
            //List<int> A = [-533, -666, -500, 169, 724, 478, 358, -38, -536, 705, -855, 281, -173, 961, -509, -5, 942, -173, 436, -609, -396, 902, -847, -708, -618, 421, -284, 718, 895, 447, 726, -229, 538, 869, 912, 667, -701, 35, 894, -297, 811, 322, -667, 673, -336, 141, 711, -747, -132, 547, 644, -338, -243, -963, -141, -277, 741, 529, -222, -684, 35];
            List<int> A = [5,-2,3,1,2];
            int B = 3;
            int N = A.Count;
            var pSum = new List<int>();
            var sSum = new List<int>(N);

            pSum.Add(A[0]);
            for(int i=1;i < N;i++)
                pSum.Add(A[i] + pSum[i-1]);
            foreach(int i in A)
                sSum.Add(0);
            sSum[N-1] = A[N - 1];
            for (int i = N - 2; i >= 0; i--)
                sSum[i] = (A[i] + sSum[i + 1]);

            int result = Math.Max(pSum[B-1], sSum[N-B]);

            for(int i = 1; i < B; i++)
            {
                int sum = pSum[i - 1]+ sSum[N - B + i];
                result = Math.Max(sum,result);
            }
            return result;

            //int leftSum = A[0], rightSum =A[A.Count-1];
            //int result = Math.Max(leftSum, rightSum);

            //int left = 0, right = A.Count - 2;
            //for (int i = 1; i < B; i++)
            //{
            //    leftSum += A[left];
            //    rightSum += A[right];

            //    if(result + leftSum >= result + rightSum)
            //    {
            //        result += leftSum;
            //        left++;
            //    } else
            //    {
            //        result += rightSum;
            //        right--;
            //    }
            //}

            return result;
        }
        internal static void PrintSubArrayLtoR()
        {
            List<int> A = [4, 2, 10, 3, 12, -2, 5];
            int L = 2, R = 5;

            for (int i = L; i < R && R < A.Count; i++)
            {
                Console.Write(A[i] + "    ");
            }
        }

        internal static void PrintPossibleSubArrays()
        {
            List<int> A = [4, 2, 10, 3, 12, -2, 5];
            int count = 0;
            
            UnSortedArray.DisplayArray(A, "Input array");
            for (int L = 0; L < A.Count; L++)
            {
                for (int R = L; R < A.Count; R++)
                {
                    for (int i = L; i <= R; i++)
                    {
                        Console.Write(A[i] + " ");
                    }
                    count++;
                    Console.WriteLine();
                }
            }
            Console.WriteLine($"total subarray count is {count} with TC O(N^3) and SC O(1)");
            
        }
        internal static void PrintUniqueSubArrays()
        {
            List<int> A = [93, 9, 12, 32, 97, 75, 32, 77, 40, 79, 61, 42, 57, 19, 64, 16, 86, 47, 41, 67, 76, 63, 24, 10, 25, 96, 1, 30, 73, 91, 70, 65, 53, 75, 5, 19, 65, 6, 96, 33, 73, 55, 4, 90, 72, 83, 54, 78, 67, 56, 8, 70, 43, 63];// [4, 2, 10, 3, 12, -2, 5];//[1, 1, 3];//
            int mod = 1000000007;
            int N = A.Count;

            int count = 0;
            int l = 0, r = 0;
            var dict = new Dictionary<int, int>();
           
            while (r < N)
            {
                if (!dict.ContainsKey(A[r]))
                {
                    dict.Add(A[r], r);
                    count += r - l + 1;
                    count %= mod;
                    r++;
                }
                else
                {
                    {
                        if (dict[A[r]] >= l)
                        {
                            l = dict[A[r]] + 1 ;
                        }
                        dict.Remove(A[r]);
                    }
                }
            }
            
            Console.WriteLine($"total subarray count is {count} with TC O(NLogN) and SC O(1)");
        }

        internal static void LengthOfSmallestSubArray()
        {
            List<int> A = [5,8,2,3,8,10,6,1,2];

            int minA = A[0], maxA = A[0];
            UnSortedArray.DisplayArray(A, "");
            int result = A.Count;

            for (int i = 1; i < A.Count; i++)
            {
                if (A[i] < minA) minA = A[i];
                if (A[i] > maxA) maxA = A[i];
            }

            //Solution 1
            Console.WriteLine($"min is {minA} and max is {maxA}");
            for (int L=0;L< A.Count; L++)
            {
                for(int R=L+1; R < A.Count; R++)
                {
                    bool maxVisited = false, 
                        minVisited = false ;
                    for(int i=L;i<=R;i++)
                    {
                        if (A[i] == maxA) maxVisited = true;
                        if (A[i] == minA) minVisited = true;

                        if (maxVisited == true && minVisited == true)
                        {
                            if ((R - L + 1) < result)
                                result = R - L + 1;
                        }
                    }

                }
            }
            Console.WriteLine("Solution with Bruteforce");
            Console.WriteLine($"    Length of smallest subarray is {result} with TC O(N^3); SC O(1)");

            // Solution 2
            Console.WriteLine("Solution2 with 2 forloops");
            result = A.Count;
            for(int L=0;L< A.Count; L++)
            {
                bool maxVisited = false,minVisited = false ;
                for(int R=L;R< A.Count; R++)
                {
                    if (A[R] == minA) minVisited = true;
                    if (A[R] == maxA) maxVisited = true;

                    if (maxVisited == true && minVisited == true)
                        result = Math.Min(result, (R - L + 1));
                }
            }
            Console.WriteLine($"    Length of smallest subarray is {result} with TC O(N^2); SC O(1)");

            // Solution 3
            Console.WriteLine("Solution3 with carry forward");
            result = A.Count;
            int minIndex = -1, maxIndex = -1;
            for(int i=A.Count-1;i>=0;i--)
            {
                if (A[i] == minA)
                {
                    minIndex = i;
                    if(maxIndex > -1)
                        result = Math.Min(result, (maxIndex - minIndex + 1));
                }
                if (A[i] == maxA)
                {
                    maxIndex = i;
                    if (minIndex > -1)
                        result = Math.Min(result, minIndex - maxIndex + 1);
                }
            }
            Console.WriteLine($"    Length of smallest subarray is {result} with TC O(N); SC O(1)");
        }
    }
}
