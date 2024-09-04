using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate
{
    internal class Contest6_4
    {
        public static void MatrixMinPathSum()
        {
            List<List<int>> A = [[1,3,2], [4,3,1], [5,6,1]];//8
            A = [[1, -3, 2], [2, 5, 10], [5, -5, 1]];//-1
            int N = A.Count;
            int M = A[0].Count;

            if (N == 1 && M == 1)
            {
                Console.WriteLine(A[0][0]);
                return;
            }

            for (int r = 1; r < N; r++)
            {
                A[r][0] += A[r - 1][0];
            }

            for (int c = 1; c < M; c++)
            {
                A[0][c] += A[0][c - 1];
            }

            for (int r = 1; r < N; r++)
            {
                for (int c = 1; c < M; c++)
                {
                    A[r][c] += Math.Min(A[r - 1][c], A[r][c - 1]);
                }
            }
            Console.WriteLine( A[N - 1][M - 1]);
        }
    }
}
