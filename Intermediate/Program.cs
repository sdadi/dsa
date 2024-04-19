namespace Intermediate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Contest1Run();
            //Contest2Run();
            print(-3);
        }
        static void print(int n)
        {
            if (n == 0) return;
            Console.WriteLine(n);
            print(n - 1);
        }
        static void Contest1Run()
        {
            Console.WriteLine("-----     Problem: Toggle Case                       -----");
            Contest1.ToggleCase();
            Console.WriteLine("\n\n\n-----     Problem: Count of Non Negative Profit      -----");
            Contest1.CountOfNonNegativeProfit();
            Console.WriteLine("\n\n\n-----     Problem: Network Super Stream              -----");
            Contest1.SuperStream();
        }
        static void Contest2Run()
        {
            //Contest2.BenjaminAND();
            //Contest2.MaxPossibleSubArraywithDecreasingDishes();
            Contest2.SearchRowWiseColWiseSortedMatrix();
        }
        static void test()
        {

        }
    }
}
