namespace fundamental
{
    internal class Sumof3FindTriplets
    {
        internal static void FindTriplets()
        {
            int[] arr = { 7, -6, 3, 8, -1, 8, -11 };
            int targetSum = 0;
            Find(arr, targetSum, arr.Length);
        }
        public static void Find(int[] input, int targetSum, int n)
        {
            Array.Sort(input);
            for (int i = 0; i < n; i++)
                Console.Write($"{input[i]}, ");
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                if (i == 0 || (input[i] != input[i - 1]))
                {
                    int j = i + 1, k = n - 1;
                    int target = targetSum - input[i];
                    while (j < k)
                    {
                        if (input[j] + input[k] == target)
                        {
                            Console.WriteLine($"{input[i]}, {input[j]}, {input[k]}");
                            while (j < k && input[j] == input[j + 1]) j++;
                            while (j < k && input[k] == input[k - 1]) k--;
                            j++;
                            k--;
                        }
                        else if (input[j] + input[k] < target)
                        {
                            j++;
                        }
                        else
                        {
                            k--;
                        }
                    }
                }
            }
        }
    }
}
