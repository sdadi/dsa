using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Advanced
{
    internal class SampleQuestions
    {

        public static void MinimumJumps()
        {
            List<int> A = [2, 3, 1, 1, 4];//2
            //A = [2, 3, 0, 1, 4];//2
            //A = [0];//0
            //A = [1];//0
            A = [1, 1, 1, 1];//3

            if (A == null || A[0] == 0) { Console.WriteLine(0); return;  }

            #region TC - O(N)
            int count = 0;
            int far = 1, near = 1, max = A[0];
            while (far < A.Count)
            {
                for (int k = near; k <= far; k++)
                {
                    if (k + A[k] > max)
                    {
                        max = k + A[k];
                    }
                }
                count++;
                near = far + 1;
                far = max;
            }
            Console.WriteLine(count);
            #endregion

            #region TC = O(2N)
            count = 0;

            for (int i = 1; i < A.Count; i++)
            {
                A[i] = Math.Max(A[i - 1], i + A[i]);
            }
            int j = 0;
            while (j < A.Count - 1)
            {
                count++;
                j = A[j];
            }
            Console.WriteLine(count);
            #endregion
        }
    }
}
