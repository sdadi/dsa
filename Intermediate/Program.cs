using System.Linq;
namespace Intermediate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Contest1Run();
            //Contest2Run();

            //Contest3.LongestPossibleRoute();
            //Contest3.LongestRouteMoveRun();

            //Contest4.DecreasingOrderWords();
            //Contest4.LongestPalindrome();
            //Contest4.SearchRange();


            //Contest4_2.NumerovilleMaxValue();
            //Contest3_2.EatingMangoesSlowly();

            //Contest4.WarmerTemparature();
            //Contest4.MaximumGoodPair();
            //Contest4.RemoveLoopFromLinkedList();

            //Contest4_2.ContainerWithMostWater();
            Contest4_2.ReverseEvenNodes();
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
            Contest_1.ToggleCase();
            Console.WriteLine("\n\n\n-----     Problem: Count of Non Negative Profit      -----");
            Contest_1.CountOfNonNegativeProfit();
            Console.WriteLine("\n\n\n-----     Problem: Network Super Stream              -----");
            Contest_1.SuperStream();
        }
        static void Contest2Run()
        {
            //Contest2.BenjaminAND();
            //Contest2.MaxPossibleSubArraywithDecreasingDishes();
            Contest1.SearchRowWiseColWiseSortedMatrix();
        }
        static void test()
        {

        }
    }


}
