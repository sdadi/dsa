using Helpers;

namespace _1Advanced
{
    internal class _2DArray
    {
        public static void MinSwapsLessThanBTogether()
        {
            List<int> A = [11, 12, 10,1, 3, 14, 10, 5];
            int B = 8;

            int countB = 0;
            int min_swap = 0;
            int result = 0;

            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] <= B)
                    countB++;
            }

            for (int i = 0; i < countB; i++)
            {
                if (A[i] > B)
                    min_swap++;
            }
            result = min_swap;
            for (int i = countB; i < A.Count; i++)
            {
                if (A[i] > B)
                    min_swap++;
                if (A[i - countB] > B)
                    min_swap--;

                if(min_swap < result)
                    result = min_swap;
            }
            Console.WriteLine(min_swap);
        }
        public static void AddSpiralMatrix()
        {
            int A = 5; 
            int totalCount = A* A;
            var result = new List<List<int>>();
            for (int row = 0; row < A; row++)
            {
                var item = new List<int>();
                for (int col = 0; col < A; col++)
                {
                    item.Add(0);
                }
                result.Add(item);
            }

            int row_min = 0, row_max = A - 1;
            int col_min = 0, col_max = A - 1;
            int count = 1;

            while(count <= totalCount)
            {
                //top row
                for(int col=col_min;col<=col_max && count <= totalCount;col++)
                {
                    result[row_min][col] = count++;
                }
                row_min++;

                //right column
                for(int row=row_min;row <= row_max && count <= totalCount; row++)
                {
                    result[row][col_max] = count++;
                }
                col_max--;

                //bottom row
                for(int col=col_max;col >= col_min && count <= totalCount; col--)
                {
                    result[row_max][col] = count++;
                }
                row_max--;

                //left column
                for(int row=row_max;row >=row_min && count <= totalCount; row--)
                {
                    result[row][col_min] = count++;
                }
                col_min++;
            }
            MatrixExtensions.DisplayMatrix(result);
        }
        public static void SortedMatrixFindB()
        {
            //List<List<int>> A = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
            //int B = 2;
            List<List<int>> A = [[2,8,8,8], [2, 8, 8, 8], [2, 8, 8, 8]];
            int B = 8;
            int N = A.Count;
            int M = A[0].Count;
            int result = -1;
            bool resultFound = false;

            int row = 0, col = M - 1;
            while (row < N && col >= 0)
            {
                if (A[row][col] == B)
                {
                    result = ((row + 1) * 1009 + (col + 1));
                    resultFound = true;
                    col--;
                }
                else if (A[row][col] < B)
                {
                    if (resultFound)
                        break;
                    row++;
                }
                else
                {
                    if (resultFound)
                        break;
                    col--;
                }
            }
            Console.WriteLine(result);
        }
    }
}
