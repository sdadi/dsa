namespace _1Advanced
{
    internal class _6Recursion1
    {
        public static void SimpleRecursion()
        {
            Console.WriteLine(foo(3, 5));
        }
        private static int foo(int x, int y)
        {
            if (y == 0) return 1;
            return bar(x, foo(x,y-1));
        }
        private static int bar(int x, int y) { 
            if(y == 0) return 0;
            return x + bar(x, y - 1);
        }
        public static void FindFactorial()
        {
            int N = 10;
            int fact = Factorial(N);
            Console.WriteLine($"Factorial of {N} is {fact}");
            Console.WriteLine("----------\n");
        }
        private static int Factorial(int n)
        {
            if (n < 2) return n;
            return Factorial(n - 1) * n;
        }

        public static void FindFibonacci()
        {
            int N = 7;
            int result = Fibonacci(N);
            Console.WriteLine($"Fibonacci number at {N} is {result}");
            Console.WriteLine("----------\n");
        }
        private static int Fibonacci(int n)
        {
            if(n < 2) return n;
            return Fibonacci(n-1) + Fibonacci(n-2);
        }

        public static void PrintNNumbers()
        {
            int N = 8;
            Console.WriteLine($"Print numbers 1 to {N}");
            Print(N);
            //Console.WriteLine("\n----------\n");
        }
        private static void Print(int n)
        {
            if(n < 1) return;
            Print(n - 1);
            Console.Write($"{n} ");
        }

        public static void SimpleRecursion1()
        {
            int ans = FuncTest(2, 10);
            Console.WriteLine(ans);
        }
        private static int FuncTest(int x, int n)
        {
            if (n == 0) return 1;
            else if(n%2 == 0) return FuncTest(x*x,n/2);
            else
            {
                 return x*FuncTest(x*x, (n-1)/2);
            }
        }

        public static void PalindromeRun()
        {
            string A = "namnan";
            int left = 0, right = A.Length - 1;
            Console.WriteLine(IsPalindrome(A, left, right));
        }

        private static int IsPalindrome(string A, int left, int right)
        {
            if (left >= right) return 1;

            int c = (A[left] == A[right]) ? 1 : 0;
            int l = left+1, r = right-1;
            int p = IsPalindrome(A, l,r);
            return c & p;
        }
    }
}
