using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamental
{
    internal class FindTargetInRowColumnSortedMatrix
    {
        public static void FindTarget()
        {
            int[][] matrix = [
                                 [1, 6, 7, 8, 10]
                                ,
                [2, 11, 13, 15]
                                ,
                [3, 17, 18, 19]
                                ,
                [5, 24, 29, 31]
                                ];
            int target = 35;

            int left = 0, right = matrix.Length - 1;
            bool found = false;

            while (left < matrix.Length && right >= 0)
            {
                if (matrix[left][right] == target)
                {
                    found = true;
                    break;
                }
                else if (matrix[left][right] < target)
                    left++;
                else
                    right--;
            }
            if (found)
                Console.WriteLine($"target {target} found at matrix [{left}][{right}]");
            else
                Console.WriteLine($"target {target} not found");

        }
    }
}
