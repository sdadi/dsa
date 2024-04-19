using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.PortableExecutable;
using System;

namespace _1Advanced
{
    internal class _7Recursion2
    {
        public static List<List<int>> towerOfHanoi()
        {
            int A = 1;
            var result = new List<List<int>>();
            int source = 1, helper = 2, destination = 3;
            ToH(A, source, helper, destination, result);

            return result;
        }

        private static void ToH(int A, int source, int helper, int destination, List<List<int>> result)
        {
            if (A == 0)
                return;

            ToH(A - 1, source, destination, helper, result);
            result.Add(new List<int>() { A, source, destination });
            ToH(A - 1, helper, source, destination, result);
        }
        /// <summary>given A, B and C, Find (AB % C)./// </summary>
        public static void PowerFunction()
        {
            int A = 71045970, B = 41535484, C = 64735492;
            // Just write your code below to complete the function. Required input is available to you as the function arguments.
            // Do not print the result or any output. Just return the result via this function.
            //int N = A<0?(-1*A):A;
            int result = Power(A, B, C);
            if (A < 0)
                result = (result+C)%C;

            Console.WriteLine(result);
        }
        private static int Power(int A, int B, int C)
        {
            if (A == 0) return 0;
            if (B == 0) return 1;
            long ans = Power(A, B/2, C) % C;
            ans = (ans * ans) % C;
            if (B % 2 == 1)
                ans = (ans * A) % C;
            return (int)ans;
        }
        /// <summary>
        /// Given a number A, check if it is a magic number or not.
        ///A number is said to be a magic number if the sum of its digits is calculated till a single digit recursively 
        ///by adding the sum of the digits after every addition.
        ///If the single digit comes out to be 1, then the number is a magic number.
        /// </summary>
        public static void MagicNumber()
        {
            //int A = 83557;//1
            int A = 1291;//0

            int result = MagicNumber(A);
            result = result ==1 ? 1 : 0;
            Console.WriteLine(result);
        }
        private static int MagicNumber(int A)
        {
            if (A < 10) return A;
            int res = 0;
            while (A > 0)
            {
                res += A % 10;
                A /= 10;
            }
            return MagicNumber(res);
        }
        public static void KthSymbol()
        {
            //int A = 3, B = 0;//0
            int A = 4, B = 4;//1

            List<int> result = [0];
            int k = 2;
            result = KthSymbol(A,k,result);
            Console.WriteLine(result[B]);
        }

        private static List<int> KthSymbol(int A,int k, List<int> result)
        {
            if(k>A)
                return result;
            var ans = new List<int>();
            foreach(var i in result)
            {
                if(i == 0)
                {
                    ans.Add(0);
                    ans.Add(1);
                }
                else
                {
                    ans.Add(1);
                    ans.Add(0);
                }
            }
            k += 1;
            return KthSymbol(A,k,ans);
        }
        /// <summary>
        /// On the first row, we write a 0. 
        /// Now in every subsequent row, we look at the previous row and replace each occurrence of 0 with 01, 
        /// and each occurrence of 1 with 10.
        /// Given row number A and index B, return the Bth indexed symbol in row A. (The values of B are 0-indexed.).
        /// </summary>
        public static void KthSymbolHard()
        {
            //int A = 3; long B = 0;//0
            int A = 4; long B = 4;//1

            int count = KthSymbolHard(A, B);
            Console.WriteLine(count);
        }
        private static int KthSymbolHard(int A, long B)
        {
            if (A == 1 && B == 0) return 0;
            int val = KthSymbolHard(A-1, B / 2);
            if (B % 2 == 0)
                return val;
            else
                return 1 - val;
        }
    }
}
