using System.Security.AccessControl;

namespace fundamental
{
    internal class RotateMatrixBy90
    {
        public static void Rotate90()
        {
            int[][] matrix = [
            [1, 2, 3, 4],
                [5, 6, 7,8],
                [9, 10, 11,12],
                [13, 14, 15, 16],
            ];
            Console.WriteLine("Input matrix");
            DisplayMatrix(matrix);
            //Transpose matrix
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = i+1; j < matrix[0].Length; j++)
                {
                    int temp = matrix[i][j];

                    matrix[i][j] = matrix[j][i];
                    matrix[j][i]=temp;
                }
            }
            Console.WriteLine("After transpose");
            DisplayMatrix(matrix);
            // left to right column movement
            int left = 0, right = matrix.Length-1;

            while (left < right)
            {
                for(int i = 0; i < matrix.Length;i++)
                {
                    int temp = matrix[i][left];
                    matrix[i][left] = matrix[i][right];
                    matrix[i][right] = temp;
                }
                left++;
                right--;
            }
            Console.WriteLine("After rotating to 90 degree");
           DisplayMatrix(matrix);

        }
        public static void DisplayMatrix(int[][] matrix)
        {
            foreach (int[] a in matrix)
            {
                foreach (int b in a)
                    Console.Write(b.ToString().PadLeft(2,' ') + "     ");
                Console.WriteLine();
            }
        }

        
    }
}
