using Helpers;

namespace Intermediate
{
    internal class Contest4_2
    {
        public static void NumerovilleMaxValue()
        {
            List<int> A = [6,4];
            long result = 0;
            A.Sort();

            for (int i = 0; i < A.Count; i++)
            {
                result += (i + 1) * A[i];
            }

            Console.WriteLine(result);
        }

        public static void EatingMangoesSlowly()
        {
            //List<int> A = [3, 6, 7, 11];
            //int B = 8;//4  B is max_hours

            //List<int> A = [30, 11, 23, 4, 20];
            //int B = 5;//30

            //List<int> A = [2];
            //int B = 14;//1

            List<int> A = [2, 5, 7, 10, 7, 1, 3, 7];
            int B = 17;//4

            int maxA = int.MinValue;

            for (int i = 0; i < A.Count; i++)
            {
                maxA = Math.Max(maxA, A[i]);
            }

            int left = 1, right = maxA;

            while (left <= right)
            {
                int mid = left + (right - left)/2;
                int time = 0;

                foreach (int mangoes in A)
                {
                    time += (int)Math.Ceiling((decimal)mangoes / mid);
                }

                if (time <= B)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            Console.WriteLine(left);
        }
    }
}
