using _3Advanced;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate
{
    internal class Contest4
    {

        public static void WarmerTemparature()
        {
            List<int> A = [73, 74, 75, 76, 77, 78, 79, 80];//[1 1 1 1 1 1 1 0]
            A = [75,71,69,72,76,73];//[4,2,1,1,0,0]


            List<int> result = new List<int>();
            foreach (var i in A)
                result.Add(0);
            var stack = new Stack<int>();

            for (int i = A.Count - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && A[stack.Peek()] <= A[i])
                {
                    stack.Pop();
                }
                if(stack.Count > 0)
                    result[i] = stack.Peek()-i;
                stack.Push(i);
            }

            result.PrintArray();
        }

        public static void MaximumGoodPair()
        {
            string A = "bcc";
            string B = "abc";//1

            A = "add";
            B = "abcd";//2

            A = "aabbbbcc";
            B = "abbccccccd";//2

            int i = 0, j = 0,N = A.Length, M = B.Length;
            int result = int.MinValue;
            int diff = 0;

            while (i < N && j < M)
            {
                char first = A[i];
                char second = B[j];

                if(first >= second)
                {
                    j++;
                }
                else if(first < second)
                {
                    if (i > j-1)
                        diff = 0;
                    else
                        diff = Math.Abs(j - 1 - i);
                    result = Math.Max(result, diff);
                        i++;
                    j = i;
                }
            }
            if (i >= N)
                i = N - 1;
            if (i > j-1)
                diff = 0;
            else
                diff = Math.Abs(j - 1 - i);
            result = Math.Max(result, diff);

            Console.WriteLine(result);
        }
    }
}
