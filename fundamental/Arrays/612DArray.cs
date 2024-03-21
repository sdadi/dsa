namespace fundamental.Arrays
{
    internal class _612DArray
    {
        internal static void Rotate90()
        {
            List<List<int>> a = [[1, 2], [3, 4]];
            int N = a.Count;
            for (int row = 0; row < N - 1; row++)
            {
                for (int col = row + 1; col < N; col++)
                {
                    int temp = a[row][col];
                    a[row][col] = a[col][row];
                    a[col][row] = temp;
                }
            }

            for (int i = 0; i < N; i++)
            {
                int left = 0, right = N - 1;
                while (left < right)
                {
                    int temp = a[i][left];
                    a[i][left] = a[i][right];
                    a[i][right] = temp;
                    right--;
                    left++;
                }
            }
            foreach (var i in a)
            {
                foreach (int j in i)
                    Console.Write(j + " ");
                Console.WriteLine();
            }
        }
        internal static void ColumnWiseSum()
        {
            List<List<int>> A = [[1, 2, 3, 4],
                [5, 6, 7, 8],
                [9, 2, 3, 4]];

            var result = new List<int>();
            int rN = A.Count;
            int cN = A[0].Count;

            for (int col = 0; col < cN; col++)
            {
                int sum = 0;
                for (int row = 0; row < rN; row++)
                {
                    sum += A[row][col];
                }
                result.Add(sum);
            }

            foreach (int i in result)
                Console.Write(i + " ");
        }
        internal static void PrintAllDiagonals()
        {
            List<List<int>> A = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];

            var result = new List<List<int>>();
            int N = A.Count;

            for (int c = 0; c < N; c++)
            {
                var item = new List<int>();
                int row = 0;
                int col = c;
                int valCount = 0;
                while (row < N && col >= 0)
                {
                    item.Add(A[row][col]);
                    row++;
                    col--;
                    valCount++;
                }
                for (int i = valCount; i < N; i++)
                {
                    item.Add(0);
                }
                result.Add(item);
            }

            for (int r = 1; r < N; r++)
            {
                var item = new List<int>();
                int row = r;
                int col = N - 1;
                int valCount = 0;
                while (row < N && col >= 0)
                {
                    item.Add(A[row][col]);
                    row++;
                    col--;
                    valCount++;
                }
                for(int i=valCount; i<N; i++)
                {
                    item.Add(0);
                }
                result.Add(item);
            }
            foreach (var i in result)
            {
                foreach (int j in i)
                    Console.Write(j + " ");
                Console.WriteLine();
            }
        }
        internal static void Transpose()
        {
            //List<List<int>> A = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
            //List<List<int>> A = [[24, 63, 39, 81, 84, 30], [21, 64, 95, 6, 88, 73], [33, 6, 63, 96, 86, 66], [62, 88, 23, 52, 94, 77], [81, 58, 74, 18, 16, 25], [26, 40, 88, 64, 72, 23], [45, 44, 86, 92, 50, 26], [64, 34, 83, 26, 29, 68], [43, 42, 7, 17, 45, 52], [94, 25, 62, 19, 95, 77]];
            List<List<int>> A = [[21, 62, 16, 44, 55, 100, 16, 86, 29], [62, 72, 85, 35, 14, 1, 89, 15, 73], [42, 44, 30, 56, 25, 52, 61, 23, 54], [5, 35, 12, 35, 55, 74, 50, 50, 80], [2, 65, 65, 82, 26, 36, 66, 60, 1], [18, 1, 16, 91, 42, 11, 72, 97, 35], [23, 57, 9, 28, 13, 44, 40, 47, 98]];
            int rN = A.Count;
            int cN = A[0].Count;
            int N = rN > cN ? rN : cN;


            Console.WriteLine("Input matrix");
            
            foreach (var i in A)
            {
                foreach (int j in i)
                    Console.Write(j + "   ");
                Console.WriteLine();
            }
            var result = new List<List<int>>();
            if (rN == cN)
            {
                for (int row = 0; row < N - 1; row++)
                {
                    for (int col = row + 1; col < N; col++)
                    {
                        int temp = A[row][col];
                        A[row][col] = A[col][row];
                        A[col][row] = temp;
                    }
                }
            }
            else
            {
                for (int row = 0; row < cN; row++)
                {
                    var item = new List<int>();
                    for (int col = 0; col < rN; col++)
                    {
                        item.Add(A[col][row]);
                    }
                    result.Add(item);
                }
            }
            Console.WriteLine("After Transpose");
            result = (rN == cN) ? A : result;
            foreach (var i in result)
            {
                foreach (int j in i)
                    Console.Write(j + "   ");
                Console.WriteLine();
            }
        }
    }
}
