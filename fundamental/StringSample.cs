using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamental
{
    internal class StringSample
    {
        internal static void Encrypt()
        {
            string s = "chillout";
            Console.WriteLine(s);
            s = s.Replace(" ", "");
            Console.WriteLine(s);

            int L = s.Length;
            int sqrt = (int)Math.Ceiling(Math.Sqrt(L));

            int rows = sqrt;
            int columns = sqrt;
            //columns = (rows*columns >= L)?columns: columns + 1;
            //if (rows*columns < L)
            //{
            //    if ((rows + 1) * columns < rows * (columns + 1))
            //        rows = rows + 1;
            //    else 
            //        columns = columns + 1;
            //}

            char[,] matrix = new char[rows,columns];

            int r = 0, c = 0;
            for (int i = 0; i < L; i++)
            {
                matrix[r,c] = s[i];
                if (c < columns-1) c++;
                else
                {
                    r++; 
                    c = 0;
                }
            }
            StringBuilder sb = new StringBuilder();
            for(int col=0; col < columns; col++)
            {
                for(int row =0; row < rows; row++)
                {
                    sb.Append(matrix[row,col]);
                }
                if(col<columns-1)
                    sb.Append(" ");
            }
            //string val = sb.ToString();
            //val = val.Substring(0, val.Length - 1);
            Console.WriteLine($"'{sb.ToString().Substring(0, sb.Length - 1)}'");
        }
    }
}
