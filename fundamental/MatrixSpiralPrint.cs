using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamental
{
    internal class MatrixSpiralPrint
    {
        internal static void PrintAllMagicSquares()
        {
            int a = (21-47) / (6-3);
            
            List<List<int>> s = new List<List<int>>();
            s = [[4, 8, 2],
                [4, 5, 7],
                [6, 1, 6]
                ];
            List<List<List<int>>> magicSquares = new List<List<List<int>>>() {
                    new List<List<int>>(){ new List<int>(){ 8, 1, 6 }, new List<int>(){ 3, 5, 7 }, new List<int>(){ 4, 9, 2 } }, 
                    new List<List<int>>(){ new List<int>(){ 6, 1, 8 }, new List<int>(){ 7, 5, 3 }, new List<int>(){ 2, 9, 4 } }, 
                    new List<List<int>>(){ new List<int>(){ 4, 9, 2 }, new List<int>(){ 3, 5, 7 }, new List<int>(){ 8, 1, 6 } }, 
                    new List<List<int>>(){ new List<int>(){ 2, 9, 4 }, new List<int>(){ 7, 5, 3 }, new List<int>(){ 6, 1, 8 } }, 
                    new List<List<int>>(){ new List<int>(){ 8, 3, 4 }, new List<int>(){ 1, 5, 9 }, new List<int>(){ 6, 7, 2 } }, 
                    new List<List<int>>(){ new List<int>(){ 4, 3, 8 }, new List<int>(){ 9, 5, 1 }, new List<int>(){ 2, 7, 6 } }, 
                    new List<List<int>>(){ new List<int>(){ 6, 7, 2 }, new List<int>(){ 1, 5, 9 }, new List<int>(){ 8, 3, 4 } },
                    new List<List<int>>(){ new List<int>(){ 2, 7, 6 }, new List<int>(){ 9, 5, 1 }, new List<int>(){ 4, 3, 8 } } };

            int minCost = int.MaxValue;
            

            for(int i=0;i<magicSquares.Count;i++)
            {
                int cost = 0;
                for(int r = 0; r < s.Count; r++)
                {
                    for(int c = 0;c<s.Count; c++)
                    {
                        cost += Math.Abs(magicSquares[i][r][c] - s[r][c]);
                    }
                }
                if(cost < minCost)
                    minCost = cost;
            }

            Console.WriteLine(minCost);
        }
        internal static void MagicSquareMinCost()
        {
            List<List<int>> s = new List<List<int>>();
            s = [[4, 8, 2],
                [4, 5, 7],
                [6, 1, 6]
                ];

            //s = [
            //    [4, 9, 2],
            //    [3, 5, 7],
            //    [8, 1, 5]
            //    ];
            int n = s.Count;
            int cost = 0;
            int magicSum = ((n * n) * (n * n + 1) / 2) / n;
            int center = magicSum / n;
            int total = 0;

            List<int> missingItems = [1, 2, 3, 4, 5, 6, 7, 8, 9];
            var duplicates = new List<int>();
            var hash = new HashSet<int>();
            foreach (var i in s)
            {
                foreach (int j in i)
                {
                    if (hash.Contains(j))
                    {
                        duplicates.Add(j);
                    }
                    else
                        hash.Add(j);
                    missingItems.Remove(j);

                    total += j;
                }
            }
            if (duplicates.Count > 1)
                cost = Math.Abs(duplicates.Sum() - missingItems.Sum());
            cost += Math.Abs(total - 45);
            //total = s[0][0] + s[1][1] + s[2][2];
            //total += s[2][0] + s[1][1] + s[0][2];

            //cost += Math.Abs(total - 30);


            Console.WriteLine(cost);
        }
        internal static void MagicSquarecost()
        {
            List<List<int>> s = new List<List<int>>();
            //s = [[4, 8, 2],
            //    [4, 5, 7],
            //    [6, 1, 6]
            //    ];

            s = [
                [4, 9, 2],
                [3, 5, 7],
                [8, 1, 5]
                ];

            int n = s.Count;
            int cost = 0;
            int magicSum = ((n * n) * (n * n + 1) / 2) / n;
            int center = magicSum / n;


            int val = center - 1;
            if (val == s[0][0] || val == s[2][2])
            {
                if (val == s[0][0])
                {
                    val = center + 1;
                    if (val != s[2][2])
                    {
                        cost += (int)Math.Abs(val - s[2][2]);
                        s[2][2] = val;
                    }

                    val = center - 3;
                    if (val != s[0][2])
                    {
                        cost += (int)Math.Abs(val - s[0][2]);
                        s[0][2] = val;
                    }

                    val = center + 3;
                    if (val != s[2][0])
                    {
                        cost += (int)Math.Abs(val - s[2][0]);
                        s[2][0] = val;
                    }
                }
                else if (val == s[2][2])
                {
                    val = center + 1;
                    if (val != s[0][0])
                    {
                        cost += Math.Abs(val - s[0][0]);
                        s[0][0] = val;
                    }

                    val = center + 3;
                    if (val != s[0][2])
                    {
                        cost += (int)Math.Abs(val - s[0][2]);
                        s[0][2] = val;
                    }

                    val = center - 3;
                    if (val != s[2][0])
                    {
                        cost += (int)Math.Abs(val - s[2][0]);
                        s[2][0] = val;
                    }
                }
            }

            val = center + 1;
            if (val == s[0][0] || val == s[2][2])
            {
                if (val == s[0][0])
                {
                    val = center - 1;
                    if (val != s[2][2])
                    {
                        cost += (int)Math.Abs((val - s[2][2]));
                        s[2][2] = val;
                    }

                    val = center + 3;
                    if (val != s[0][2])
                    {
                        cost += (int)Math.Abs(val - s[0][2]);
                        s[0][2] = val;
                    }
                    val = center - 3;
                    if (val != s[2][0])
                    {
                        cost += (int)Math.Abs(val - s[2][0]);
                        s[2][0] = val;
                    }
                }
                else if (val == s[2][2])
                {
                    val = center - 1;
                    if (val != s[0][0])
                    {
                        cost += (int)Math.Abs(val - s[0][0]);
                        s[0][0] = val;
                    }

                    val = center - 3;
                    if (val != s[0][2])
                    {
                        cost += (int)Math.Abs(val - s[0][2]);
                        s[0][2] = val;
                    }

                    val = center + 3;
                    if (val != s[2][0])
                    {
                        cost += (int)Math.Abs(val - s[2][0]);
                        s[2][0] = val;
                    }
                }

                val = magicSum - s[0][0] - s[0][2];
                if (val != s[0][1])
                {
                    cost += (int)Math.Abs(val - s[0][1]);
                    s[0][1] = val;
                }
                val = magicSum - s[2][0] - s[2][2];
                if (val != s[2][1])
                {
                    cost += (int)Math.Abs(val - s[2][1]);
                    s[2][1] = val;
                }

                val = magicSum - s[0][0] - s[2][0];
                if (val != s[1][0])
                {
                    cost += (int)Math.Abs(val - s[1][0]);
                    s[1][0] = val;
                }
                val = magicSum - s[0][2] - s[2][2];
                if (val != s[1][2])
                {
                    cost += (int)Math.Abs(val - s[1][2]);
                    s[1][2] = val;
                }
            }
            Console.WriteLine(cost);
        }
        public static void SpiralPrint()
        {
            int[][] matrix = [
            [1, 2, 3, 4],
                [5, 6, 7, 8],
                [9, 10, 11, 12],
                [13, 14, 15, 16],
            ];
            Console.WriteLine("Input matrix");
            DisplayMatrix(matrix);

            int cmin = 0, cmax = matrix[0].Length - 1;
            int rmin = 0, rmax = matrix.Length - 1;
            int count = 0, elementCount = matrix.Length * matrix[0].Length;
            while (count < elementCount)
            {
                //top row
                for (int col = cmin; col <= cmax && count < elementCount; col++)
                {
                    Console.Write(matrix[rmin][col] + ", ");
                    count++;
                }
                rmin++;

                // right column
                for (int row = rmin; row <= rmax && count < elementCount; row++)
                {
                    Console.Write(matrix[row][cmax] + ", ");
                    count++;
                }
                cmax--;

                //bottom row (right to left)
                for (int col = cmax; col >= cmin && count < elementCount; col--)
                {
                    Console.Write(matrix[rmax][col] + ", ");
                    count++;
                }
                rmax--;
                //left column (bottom to top)
                for (int row = rmax; row >= rmin && count < elementCount; row--)
                {
                    Console.Write(matrix[row][cmin] + ", ");
                    count++;
                }
                cmin++;
            }

        }
        public static void SpiralSquares()
        {
            int n = 7;

            int[][] matrix = new int[n][];

            int nCount = n * n;
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
            }

            int cmin = 0, cmax = n - 1;
            int rmin = 0, rmax = n - 1;
            int count = 1;
            while (count < nCount + 1)
            {
                //top row
                for (int col = cmin; col <= cmax && count <= nCount; col++)
                {
                    matrix[rmin][col] = count;
                    count++;
                }
                rmin++;

                // right column
                for (int row = rmin; row <= rmax && count <= nCount; row++)
                {
                    matrix[row][cmax] = count;
                    count++;
                }
                cmax--;

                //bottom row (right to left)
                for (int col = cmax; col >= cmin && count <= nCount; col--)
                {
                    matrix[rmax][col] = count;
                    count++;
                }
                rmax--;
                //left column (bottom to top)
                for (int row = rmax; row >= rmin && count <= nCount; row--)
                {
                    matrix[row][cmin] = count;
                    count++;
                }
                cmin++;
            }
            DisplayMatrix(matrix);
        }
        public static void DisplayMatrix(int[][] matrix)
        {
            foreach (int[] a in matrix)
            {
                foreach (int b in a)
                    Console.Write(b.ToString().PadLeft(2, ' ') + "     ");
                Console.WriteLine();
            }
        }
    }
}
