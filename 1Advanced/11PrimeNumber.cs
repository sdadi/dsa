using Helpers;
using System.Runtime.CompilerServices;

namespace _1Advanced
{
    internal class _11PrimeNumber
    {
        public static void LuckyNumber()
        {
            int A = 12;

            var result = new List<int>();
            for(int i = 0; i <= A; i++)
            {
                result.Add(0);
            }

            for(int i = 2;i <= A; i++)
            {
                if (result[i] == 0)
                {
                    for(int j=i*2;j<=A;j += i)
                    {
                        result[j] += 1;
                    }
                }
            }
            for(int i =0;i<result.Count;i++)
            {
                if (result[i] == 2)
                    Console.WriteLine(i);
            }
        }
        public static void PrimeSum()
        {
            int A = 10;

            var isPrime = new List<bool> { false, false };
            for (int i = 2; i <= A; i++)
                isPrime.Add(true);

            for(int i=2;i*i <= A; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= A; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }
            var result = new List<List<int>>();
            for(int i=1; i<=A; i++)
            {
                if (isPrime[i] && isPrime[A - i])
                {
                    result.Add(new List<int> { i, A - i });
                    break;
                }
            }

            foreach(var kv in result)
            {
                Console.WriteLine($"[{kv[0]},{kv[1]}]");
            }
        }
        public static void CountOfDivisors()
        {

            //List<int> A = [2, 3, 4, 5];//[2,2,3,2]
            List<int> A = [8, 9, 10]; //[4,3,4]

            int N = A.Count;
            var counts = new List<int>();
            var result = new List<int>();
            int maxN = int.MinValue;

            foreach(var i in A)
            {
                result.Add(0);
                if (i > maxN)
                    maxN = i;
            }
            for (int i = 0; i <= maxN; i++)
                counts.Add(0);

            for(int i = 1; i <= maxN; i++)
            {
                for(int j=i;j<=maxN; j += i)
                {
                    counts[j] += 1;
                }
            }

            for(int i=0;i<N; i++)
            {
                result[i] = counts[A[i]];
            }

            ArrayExtension.PrintArray(result);

        }
        public static void CountOfDivisors1()
        {
            List<int> A = [2, 3, 4, 5];//[2,2,3,2]
            //List<int> A = [8, 9, 10]; //[4,3,4]

            int N = A.Count;
            int maxValue = int.MinValue;
            var result = new List<int>();
            for(int i=0; i < N; i++)
            {
                result.Add(0);
                if (A[i] > maxValue)
                {
                    maxValue = A[i];
                }
            }

            var spf = new List<int> { -1, -1 };
            for (int i=2;i<=maxValue; i++)
            {
                spf.Add(i);
            }

            for (int i = 2; i * i <= maxValue; i++)
            {
                if (spf[i] == i)
                {
                    for (int j = i * i; j <= maxValue; j += 1)
                    {
                        if (spf[j] == j)
                            spf[j] = i;
                    }
                }
            }

            for(int i=0;i<N; i++)
            {
                int ans = 1;
                int val = A[i];
                var item = spf[val];

                while(item > 1)
                {
                    int cnt = 0;
                    while(val%item == 0)
                    {
                        cnt++;
                        val /= item;
                    }
                    ans *= (cnt + 1);
                    item = spf[val];
                }
                result.Add(ans);
            }

            foreach (var item in result)
                Console.Write(item + " ");
        }
        private static void SmallestPrimeFactor(int N)
        {
            //var spf = new List<int> { -1, -1 };
            //for (int i = 2; i <= maxValue; i++)
            //{
            //    spf.Add(i);
            //}

            //for (int i = 2; i * i <= maxValue; i++)
            //{
            //    if (spf[i] == i)
            //    {
            //        for (int j = i * i; j <= maxValue; j += 1)
            //        {
            //            if (spf[j] == j)
            //                spf[j] = i;
            //        }
            //    }
            //}
        }
        public static void PrintAllPrime()
        {
            int N = 47;
            List<bool> isPrime = new List<bool> { false,false};
            for(int i=2; i <= N; i++)
                isPrime.Add(true);
            
            int iteration = 0;
            for(int i = 2; i*i <= N; i++)
            {
                if (isPrime[i])
                {
                    for(int j = i*i; j <= N; j=j+i)
                    {
                        isPrime[j] = false;
                        iteration++;
                    }
                }
                iteration++;
            }
            int count = 0;
            for(int i =2;i<=N; i++)
            {
                if (isPrime[i])
                {
                    count++;
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine($"\nfor N={N} done in iterations {iteration} and found {count} primes");
        }
    }
}
