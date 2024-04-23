namespace _1Advanced
{
    internal class _4BitManipulation
    {
        public static void Count1s()
        {
            int A = 100;
            string binaryA = Convert.ToString(A, 2);

            int count = 0;
            while (A>0)
            {
                A = (A & (A - 1));
                count++;
            }
            Console.WriteLine($"100 binary form is {binaryA} and 1's count is {count}");
        }
        public static void IsPowerOf2()
        {
            int A = 128;

            int result = (A&(A-1));

            Console.WriteLine($"{A} is {(result==0?"":"not ")} power of 2");
        }
        public static void IsIthbitset() {
            int A = 10;

            Console.WriteLine($"{A} and binary is {Convert.ToString(A, 2)}");
            Console.WriteLine($"0th bit is {((A & (1 << 0)) == 0 ? "not set" : "set")}");
            Console.WriteLine($"1th bit is {((A & (1 << 1)) == 0 ? "not set" : "set")}");
            Console.WriteLine($"2th bit is {((A & (1 << 2)) == 0 ? "not set" : "set")}");
            Console.WriteLine($"3th bit is {((A & (1 << 3)) == 0 ? "not set" : "set")}");
            Console.WriteLine($"4th bit is {((A & (1 << 4)) == 0 ? "not set" : "set")}");
        }
        public static void PossibleSubsets()
        {
            List<int> A = [1, 23, 56];
            int N = A.Count;

            for(int i=0;i < (1<<N);++i)
            {
                for(int j = 0; j < N; ++j)
                {
                    if ((i & (1 << j))>0)
                    {
                        Console.Write(A[j]+" ");
                    }
                }
                Console.WriteLine();
            }

        }
        public static void FindNthMagicNumber5()
        {
            int A = 10;

            int ans = 0;
            int power = 5;

            while (A > 0)
            {
                ans += A % 2 * power;
                A /= 2;
                power *= 5;
            }
            Console.WriteLine(ans);
        }
    }
}
