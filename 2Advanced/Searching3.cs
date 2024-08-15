using Microsoft.VisualBasic;
using System.Data;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;

namespace _2Advanced
{
    internal class Searching3
    {

        public static void SpecialInteger()
        {
            //List<int> A = [1, 2, 3, 4, 5];
            //int B = 10;

            List<int> A = [5, 17, 100, 11];
            int B = 130;



            int N = A.Count;
            int ans = N, sum = 0;

            int left = 0, right = 0;
            while(right < N)
            {
                sum += A[right++];

                while(sum > B && left < right)
                {
                    sum -= A[left++];
                    ans = Math.Min(ans, (right-left));
                }
            }

            Console.WriteLine(ans);
        }
        /// <summary>
        /// Given 2 integers A and B and an array of integers C of size N. 
        /// Element C[i] represents the length of ith board.
        /// You have to paint all N boards[C0, C1, C2, C3 … CN - 1]. There are A painters available and each of them takes B units of time to paint 1 unit of the board.
        /// Calculate and return the minimum time required to paint all boards under the constraints that any painter will only paint contiguous sections of the board.
        /// NOTE:
        /// 1. 2 painters cannot share a board to paint.That is to say, a board cannot be painted partially by one painter, and partially by another.
        /// 2. A painter will only paint contiguous boards.This means a configuration where painter 1 paints boards 1 and 3 but not 2 is invalid.
        /// Return the ans % 10000003.
        /// Problem Constraints
        /// 1 <= A <= 1000
        /// 1 <= B <= 10^6
        /// 1 <= N <= 10^5
        /// 1 <= C[i] <= 10^6
        /// A: Number of Painters
        /// B: Time taken by painter to paint 1 unit of board
        /// C: Array of integers representing units of board at each index
        /// </summary>
        public static void PaintersBoard()
        {

            //int A = 3, B = 10;
            //List<int> C = [185, 186, 938, 558, 655, 461, 441, 234, 902, 681];//18670

            //int A = 1, B = 1000000;
            //List<int> C = [1000000, 1000000];//9400003

            //int A = 2, B = 5;
            //List<int> C = [1, 10];//50

            int A = 10, B = 1;
            List<int> C = [1, 8, 11, 3];//11

            A = 4;
            B = 10;
            C = [884, 228, 442, 889];//8890
            A = 4;
            B = 5;
            C = [12, 15, 78];//390

            int mod = 10000003;
            int maxC = C[0], sumC = C[0];

            for (int i = 1; i < C.Count; i++)
            {
                if (C[i] > maxC)
                    maxC = C[i];
                sumC += C[i];
            }
            long result = 0;

            int l = maxC, r = sumC;

            while (l <= r)
            {
                int mid = (l + (r - l) / 2);
                int cnt1 = PaintersNeeded(C, mid);
                int cnt2 = PaintersNeeded(C, mid - 1);
                if (cnt1 <= A && cnt2 > A)
                {
                    result = ((1L*mid*B) % mod);
                    break;
                }
                if(cnt1 > A)
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            Console.WriteLine((int)(result));
        }

        private static int PaintersNeeded(List<int> C, int totalTime)
        {

            int cnt = 1;
            int remTime = totalTime;
            for (int i = 0; i < C.Count; i++)
            {
                if (C[i] > totalTime) return int.MaxValue;
                if (C[i] <= remTime)
                {
                    remTime -= C[i];
                }
                else
                {
                    cnt++;
                    remTime = totalTime - C[i];
                }
            }
            return cnt;
        }
    }
}
