using Helpers;

namespace Intermediate
{
    internal class Contest3
    {
        public static void SearchRange()
        {
            //List<int> A = [5, 7, 7, 8, 8, 10];
            //int B = 8;//[3,4]

            List<int> A = [5, 17, 100, 111];
            int B = 3;//[-1,-1]

            int N = A.Count;
            var result = new List<int> { -1, -1 };

            int l = 0, r = N - 1;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;

                if (A[mid] == B)
                {
                    if (mid == 0 || A[mid - 1] < B)
                    {
                        result[0] = mid;
                        break;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }
                else if (A[mid] > B)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            if (result[0] == -1)
            {
                Console.WriteLine($"[{result[0]},{result[1]}]");
                return;
            }

            l = result[0];
            r = N - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;

                if (A[mid] == B)
                {
                    if (mid == N - 1 || A[mid + 1] > B)
                    {
                        result[1] = mid;
                        break;
                    }
                    else
                    {
                        l = mid + 1;
                    }

                }
                else if (A[mid] > B)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            Console.WriteLine($"[{result[0]},{result[1]}]");
        }
        public static void LongestPalindrome()
        {
            string A = "dccbcdaac";

            var freq = new List<int>();
            for(int i = 0; i < 26; i++)
            {
                freq.Add(0);
            }
            for(int i=0; i < A.Length; i++)
            {
                freq[A[i] - 'a']++;
            }
            int count = 0;
            bool oddUsed = false;
            for(int i = 0;i<26; i++)
            {
                if (freq[i] %2 == 0)
                {
                    count += freq[i];
                }
                else
                {
                    count += freq[i] - 1;
                    if(oddUsed == false)
                    {
                        count++;
                        oddUsed = true;
                    }
                }
            }
            Console.WriteLine(count);
        }
        public static void DecreasingOrderWords()
        {
            //List<string> A = ["hi", "hello", "he"];
            List<string> A = ["cat", "bat", "could", "but"];

            A = A.OrderByDescending(x => x.Length).ToList();

            ArrayExtension.PrintArray(A);
        }

        class CompareStrings : IComparer<string>
        {
            public int Compare(string a, string b)
            {
                return System.Numerics.BigInteger.Compare(a.Length, b.Length);
            }
        }
    }
}
