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
        public static void PaintersBoard()
        {
            int A = 3, B = 10;
            List<int> C = [185, 186, 938, 558, 655, 461, 441, 234, 902, 681];//18670

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

            int l = maxC*B, r = sumC*B;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
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
            result = l % mod;
            //result = (result%mod * B%mod)%mod;
            Console.WriteLine(result);
        }

        private static int PaintersNeeded(List<int> C, int unit, int time)
        {

            int cnt = 1, remT = time;
            for (int i = 0; i < C.Count; i++)
            {
                int ti = C[i] * unit;
                if (ti > time) return -1;
                if (ti <= remT)
                {
                    remT -= ti;
                }
                else
                {
                    cnt++;
                    remT = time - ti;
                }
            }
            return cnt;
        }
    }
}
