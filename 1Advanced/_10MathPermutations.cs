using Helpers;
using System.Text;

namespace _1Advanced
{
    internal class _10MathPermutations
    {
        public static void ConsecutiveNumbers()
        {
            //int A = 15;//4
            //int A = 5;//2
            int A = 1;//1

            int result = 0;

            for(int i =1;i< Math.Sqrt(2*A);i++)
            {
                int T = A - (i*(i - 1) / 2);
                if (T % i == 0)
                    result += 1;
            }
            Console.WriteLine(result);
        }
        public static void SortedPermutationRank()
        {
            string A = "azyx";
            int rank = 0;
            if (A.Length == 0)
            {
                rank = 0;
                return;
            }
            else if (A.Length == 1)
            {
                rank = 1;
                Console.WriteLine(rank);
                return;
            }
            int result = 0;
            int mod = 1000003;

            for(int i=0;i<A.Length-1;i++)
            {
                int count = 0;
                for(int j=i+1;j<A.Length;j++)
                {
                    if (A[j] < A[i])
                        count++;
                }
                if (count == 0) continue;
                result += (count * Factorial(A.Length-i-1,mod)) % mod;
            }


            Console.WriteLine((result+1)%mod);
        }
        private static int Factorial(int n,int mod)
        {
            if (n < 2)
                return 1;
            return (Factorial(n - 1,mod)*n)%mod;
        }
        public static void ExcelColTitle()
        {
            //int A = 3;//C
            int A = 27;//AA

            StringBuilder sb = new StringBuilder();

            while(A > 0)
            {
                int r = (A - 1) % 26;
                sb.Insert(0,(char)(r + 'A'));
                A /= 26;
            }
            Console.WriteLine(sb.ToString());
        }
        public static void ExcelColNumber() {
            List<string> input = ["AB", "BB", "D", "AA","AAA"];
            List<int> output = [28, 54, 4, 27,703];

            foreach(string A in input)
            {
                int result = 0;
                int N = A.Length;
                for (int i = 0; i < N; i++)
                {
                    int pow = (int)Math.Pow(26, i);
                    result += pow*(A[N-1-i] - 'A'+1);
                }
                Console.WriteLine(result);
            }
        }
        public static void PrintPascalTriangle()
        {
            int A = 4;

            int N = A + 1;
            var matrix = new List<List<int>>();

            for(int i=0;i<= N; i++)
            {
                var item = new List<int>();
                for(int j = 0; j <= N; j++)
                {
                    item.Add(0);
                }
                matrix.Add(item);
            }

            for(int i = 0; i < N; i++)
            {
                matrix[i][0] = 1;
                matrix[i][i] = 1;
                for(int j=1;j<= i; j++)
                {
                    matrix[i][j] = matrix[i - 1][j-1] + matrix[i - 1][j];
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(matrix[i][j]+" ");
                }
                Console.WriteLine();
            }
        }

        public static void PascalTriangle()
        {
            int A = 5;

            var result = new List<List<int>>();

            for (int i = 0; i < A; i++)
            {
                var item = new List<int>();
                for (int j = 0; j < A; j++)
                    item.Add(0);
                result.Add(item);
            }

            for (int i = 0; i < A; i++)
            {
                result[i][0] = 1;
                result[i][i] = 1;
                for (int j = 1; j <= i - 1; j++)
                {
                    result[i][j] = result[i - 1][j - 1] + result[i - 1][j];
                }
            }

            MatrixExtensions.DisplayMatrix(result);
        }
        public static void nCrMODm()
        {
            //int n = 5, r = 2, m = 13;//10
            int n = 6, r = 2, m = 13;//2

            List<List<int>> ncr = new List<List<int>>();

            for(int i = 0; i <= n; i++)
            {
                var row = new List<int>();
                for(int j = 0; j <= r; j++)
                {
                    row.Add(0);
                }
                ncr.Add(row);
            }

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= Math.Min(i,r); j++)
                {
                    if(j==0 || i == j)
                    {
                        ncr[i][j] = 1;
                    }
                    else
                    {
                        int temp = (ncr[i-1][j-1]%m + ncr[i-1][j]%m)% m;
                        ncr[i][j] = temp;
                    }
                }
            }

            MatrixExtensions.DisplayMatrix(ncr);
            Console.WriteLine($"The {n}C{r} value is {ncr[n][r] % m}");
        }
    }
}
