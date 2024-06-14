using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Intermediate
{
    /// <summary>Contest-1 on 21 March 2024</summary>
    internal class Contest_1
    {
        internal static void ToggleCase()
        {
            string A = "ScaLeR";
            Console.WriteLine(A+"   -- Input string");
            StringBuilder result = new StringBuilder();

            #region Normal approach
            for (int i = 0; i < A.Length; i++)
            {
                char c = A[i];
                if (c >= 'A' && c <= 'Z')
                    result.Append((char)(c + 32));
                else if (c >= 'a' && c <= 'z')
                    result.Append((char)(c - 32));
            }
            Console.WriteLine(result.ToString() + "  -- Normal approach");
            #endregion

            #region Bitwise XOR approach
            result.Clear();
            for (int i = 0; i < A.Length; i++)
            {
                char c = A[i];
                result.Append((char)(c ^ 32));
            }
            Console.WriteLine(result.ToString() + "  -- bitwise XOR approach");
            #endregion
        }

        internal static void CountOfNonNegativeProfit()
        {
            List<int> A = [1, -2, 1, 0];
            List<List<int>> B = [[0, 2], [1, 2]];
            foreach(var item in A)
                Console.Write(item + " ");
            Console.Write("     ----- Input array\n ");
            A[0] = A[0] < 0 ? 0 : 1;

            for (int i = 1; i < A.Count; i++)
            {
                A[i] = A[i - 1] + (A[i] < 0 ? 0 : 1);
            }

            Console.WriteLine();
            int count = 0;
            for(int i=0; i < B.Count; i++)
            {
                count = A[B[i][1]] + (B[i][0] == 0 ? 0:A[B[i][0] -1]) ;
                Console.Write($"Count{count} between {B[i][0]} and {B[i][1]}");
            }
        }

        internal static void SuperStream()
        {
            List<int> A = [30, 25, 18, 22, 15, 40];// packet ack time in milli secs
            int B = 3;//consequitive times to check
            int C = 20;// threshold value for better network

            foreach (var item in A)
                Console.Write(item + " ");
            Console.Write("     ----- Input array\n ");

            int sum = 0;
            decimal avg = 0;
            for(int i = 0; i < B; i++)
            {
                sum += A[i];
            }
            avg = sum / B;
            if(avg <= C)
            {
                Console.WriteLine("better network available");
                return;
            }
            for(int i = B; i < A.Count; i++)
            {
                sum += A[i] - A[i-B];
                avg = sum / B;
                if(avg <= C)
                {
                    Console.WriteLine("better network available");
                    return;
                }
            }

            Console.WriteLine("better network NOT available");
        }
    }
}
