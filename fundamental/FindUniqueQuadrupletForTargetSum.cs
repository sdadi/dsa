using System.Security.Cryptography;

namespace fundamental
{
    internal class FindUniqueQuadrupletForTargetSum
    {
        public static void BruteForceFind()
        {
            int[] a = { 1, 0, -1, 0, -2, 2 };//-2 -1 0 0 1 2
            int targetSum = 0;

            Console.WriteLine("\n Input array");
            foreach (int i in a)
                Console.Write(i + " ");
            
            //Array.Sort(a);
            //Console.WriteLine("\n Array after sorting"); 
            //foreach (int i in a)
            //    Console.Write(i + " ");

            int a1, a2, a3, a4;
            Console.WriteLine("\nBrute force sequences");
            for (int i = 0; i < a.Length-3; i++)
            {
                for(int j = i+1;j< a.Length-2; j++)
                {
                    for (int k = j+1;k< a.Length-1; k++)
                    {
                        for (int l = k+1; l < a.Length; l++)
                        {
                            if (targetSum == a[i] + a[j] + a[k] + a[l] && i!=j && j!=k && k!=l && j!=l)
                                Console.WriteLine($"targetSum matching {a[i]}, {a[j]}, {a[k]}, {a[l]}");
                        }
                    }

                }

            }
        }
        public static void OptimizeFind()
        {
            int[] a = { 1, 0, -1, 0, -2, 2 };//-2 -1 0 0 1 2
            int targetSum = 0;

            Console.WriteLine("\n Input array");
            foreach (int i in a)
                Console.Write(i + " ");

            Array.Sort(a);
            Console.WriteLine("\n Array after sorting");
            foreach (int i in a)
                Console.Write(i + " ");

            int a1, a2, a3, a4;
            Console.WriteLine("\nfind...");
            for (int i = 0; i < a.Length - 3; i++)
            {
                for (int j = i + 1; j < a.Length - 2; j++)
                {
                    int left = j + 1, right = a.Length - 1;
                    while(left < right)
                    {
                        if (targetSum == (a[i] + a[j] + a[left] + a[right]))
                        {
                            Console.WriteLine($"targetSum matching {a[i]}, {a[j]}, {a[left]}, {a[right]}");
                            left++;
                            right--;
                        }
                        else if ((a[i] + a[j] + a[left] + a[right]) < targetSum) left++;
                        else right--;
                    }
                }
            }
        }
    }
}
