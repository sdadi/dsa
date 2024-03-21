using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamental
{
    internal class NumbersSample
    {
        internal static void NumberOfDivisors()
        {
            int A = 1012;
            int n = 0;
            int count = 0;
            int t = A;
            while (t != 0)
            {
                n = t % 10;
                if (n!=0 && A % n == 0)
                    ++count;

                t = t / 10;
            }
            
            Console.WriteLine(count);
        }
    }
}
