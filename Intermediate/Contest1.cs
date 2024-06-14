using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate
{
    internal class Contest1
    {
        public static void BenjaminAND()
        {
            //List<int> A = [1, 2, 3];
            //List<int> B = [0, 1, 2];

            //List<int> A = [2, 5, 6, 7];
            //List<int> B = [1, 2];

            List<int> A = [28, 7,3,6,23,16,5,29,23];
            List<int> B = [5, 0, 1];

            var result = new List<int>();
            for(int i=0;i<B.Count;i++)
            {
                int count = 0;
                for(int j = 0; j < A.Count; j++)
                {
                    if ((A[j] & (1 << B[i])) > 0)
                    {
                        count++;
                    }
                }
                count = count * (count - 1) / 2;
                result.Add(count);
            }
            foreach (var r in result)
                Console.Write($"{r} ");
            Console.WriteLine();
        }
        public static void MaxPossibleSubArraywithDecreasingDishes()
        {
            List<int> A = [3, 2, 1];//6
            //List<int> A = [3, 3, 5, 0, 1];//5
            //List<int> A = [10, 4, 9, 1, 3, 5];//14

            int N = A.Count;

            int sum = A[N-1];
            int result = sum;
            for (int i=N-2; i >= 0; i--)
            {
                if (A[i] > A[i + 1])
                {
                    sum += A[i];
                    if(sum > result)
                        result = sum;
                } else
                {
                    sum = A[i];
                }

            }
            Console.WriteLine(result);
        }


        public static void SearchRowWiseColWiseSortedMatrix()
        {
            List<List<int>> A = [[1, 2, 3], [4, 5, 6,], [5, 8, 9]];//1011
            int B = 5;

            //List<List<int>> A = [[1, 2], [3, 3]];//2019
            //int B = 3;


            int N = A.Count;
            int M = A[0].Count;
            int result = int.MaxValue;

            int row = 0, col = M - 1;

            while(row < N && col >= 0)
            {
                if (A[row][col] == B)
                {
                    result = Math.Min(result,((row + 1) * 1009 + (col + 1)));
                    col--;
                }
                else if (B < A[row][col])
                {
                    col--;
                }
                else
                {
                    row++;
                }
            }
            if (result == int.MaxValue)
                result = -1;

            Console.WriteLine(result);
        }
    }
}
