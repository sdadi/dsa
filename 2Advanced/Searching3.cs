using System.Data;

namespace _2Advanced
{
    internal class Searching3
    {

        public static void SpecialInteger()
        {
            //List<int> A = [1, 2, 3, 4, 5];
            //int B = 10;

            List<int> A = [5, 17, 100, 11];
            int B = 130;



            int N = A.Count;
            int ans = N, sum = 0;

            int left = 0, right = 0;
            while(right < N)
            {
                sum += A[right++];

                while(sum > B && left < right)
                {
                    sum -= A[left++];
                    ans = Math.Min(ans, (right-left));
                }
            }

            Console.WriteLine(ans);
        }
        /// <summary>
        /// A: Number of Painters
        /// B: Time taken by painter to paint 1 unit of board
        /// C: Array of integers representing units of board at each index
        /// </summary>
        public static void PaintersBoard()
        {

            //int A = 3, B = 10;
            //List<int> C = [185, 186, 938, 558, 655, 461, 441, 234, 902, 681];//18670

            int A = 1, B = 1000000;
            List<int> C = [1000000, 1000000];//9400003

            //int A = 2, B = 5;
            //List<int> C = [1, 10];//50

            //int A = 10, B = 1;
            //List<int> C = [1, 8, 11, 3];//11

            int mod = 10000003;
            int maxC = C[0], sumC = C[0];

            for (int i = 1; i < C.Count; i++)
            {
                if (C[i] > maxC)
                    maxC = C[i];
                sumC += C[i];
            }
            int result = 0;

            //long l = ((long)maxC)*((long)(B)), r = ((long)(sumC) * (long)(B));
            int l = maxC * B, r = sumC * B;

            while (l <= r)
            {
                int mid = (l + (r - l) / 2);
                int cnt1 = PaintersNeeded(C,B, mid);
                int cnt2 = PaintersNeeded(C,B, mid - 1);

                if (cnt1 <= A && cnt2 > A)
                {
                    result = (mid % mod);
                    break;
                }

                if (cnt1 > A)
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            Console.WriteLine(result);
        }

        private static int PaintersNeeded(List<int> C, int unitTime, int totalTime)
        {

            int cnt = 1;
            int remTime = totalTime;
            for (int i = 0; i < C.Count; i++)
            {
                //long ti = (long)(C[i]) * (long)(unitTime);
                int ti = C[i] * unitTime;
                if (ti > totalTime) return -1;
                if (ti <= remTime)
                {
                    remTime -= ti;
                }
                else
                {
                    cnt++;
                    remTime = totalTime - ti;
                }
            }
            return cnt;
        }
    }
}
