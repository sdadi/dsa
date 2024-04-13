using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Advanced
{
    internal class Arrays1D
    {
        public static void FlipBinaryStringMax1s()
        {
            string A = "11110000110011";
            int start=0, left=0, right=0;
            int sum = 0, maxgain = 0;

            for(int i=0; i<A.Length; i++)
            {
                sum += A[i] == '0' ? 1 : -1;
                if(sum > maxgain)
                {
                    right = i;
                    left = start;
                    maxgain = sum;
                }

                if (sum < 0)
                {
                    sum = 0;
                    start = i + 1;
                }
            }
            if (maxgain == 0)
            {
                Console.WriteLine("[]");
            }
            else
                Console.WriteLine($"[{left+1},{right+1}]");

        }
        public static void MultipleQueriesItoJ()
        {
            int A = 5;
            List<List<int>> B = [[1, 2, 10], [2, 3, 20], [2, 5, 25]];
            int[] result = new int[A];
            int Q = B.Count;
            for (int q = 0; q < Q; q++)
            {
                int l = B[q][0];
                int r = B[q][1];
                int P = B[q][2];

                result[l-1] += P;
                if ((r) < A)
                    result[r] += -1 * P;
            }


            for (int i = 1; i < A; i++)
            {
                result[i] = result[i - 1] + result[i];
            }
            
            foreach (int i in result)
                Console.Write(i + "  ");
        }

        public static void ArrayDigitsPlusOne()
        {
            List<int> A = [0,0,3,0,0,9, 9];

            int n = A.Count;
            int carry = 1;
            int lastIndex = 0;
            var result = new List<int>();

            for (int i = n - 1; i >= 0; i--)
            {
                int val = A[i] + carry;

                if (val > 9)
                {
                    A[i] = (val % 10);
                    carry = val / 10;
                }
                else
                {
                    A[i] =  val;
                    carry = 0;
                }
                if (carry < 1)
                    break;
            }
            if (carry > 0)
                A.Insert(0, carry);
            for(int i = 0;i<n;i++)
            {
                if (A[i] == 0)
                {
                    lastIndex++;
                }
                else
                    break;
            }
            A.RemoveRange(0, lastIndex);

            foreach (int i in A)
                Console.Write(i + "  ");
        }
    }
}
