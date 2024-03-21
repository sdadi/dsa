
namespace fundamental
{
    internal class FindTargetSumIndices
    {
        public static void Sum2()
        {
            int[] arr = { 12, 5, 23, 53, 26, 2, 7 };
            int targetSum = 19;
            int[] res = new int[2];

            Dictionary<int, int> hashMap = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int targetNo = targetSum - arr[i];
                if (hashMap.ContainsKey(targetNo))
                {
                    res[0] = hashMap.GetValueOrDefault(targetNo);
                    res[1] = i;
                    break;
                }
                hashMap.Add(arr[i], i);
            }
            for (int i = 0; i < arr.Length; i++)
                Console.Write(i + "->" + arr[i] + "; ");

            Console.WriteLine();
            Console.WriteLine($"Indices for Sum {targetSum} are at {res[0]} : {arr[res[0]]} and {res[1]}:{arr[res[1]]}");
        }
        public static void Sum3()
        {
            int[] arr = { 12, 5, 23, 26, 2, 7 };
            int targetSum = 14;
            int[] res = new int[3];

            int left = 1, right = arr.Length - 1;
            for (int i = 0; i < arr.Length; i++)
            {
                while (left < right)
                {
                    if (targetSum == (arr[i] + arr[left] + arr[right]))
                    {
                        res = [arr[i], arr[left], arr[right]];
                        left++;
                        right--;
                    }
                }
            }
        }

        public static void SumSubsets()
        {
            int[] array = { 10, 20, 30, 40 };
            int targetSum = 40;
            List<int> result = new List<int>();

            TargetSumSubset(array, 0, targetSum, result);
        }

        private static void TargetSumSubset(int[] array, int position, int targetSum, List<int> result)
        {
            if (targetSum < 0) return;
            if(position >= array.Length)
            {
                if(targetSum == 0)
                {
                    Console.WriteLine();
                    foreach (int i in result)
                        Console.Write(i + " ");
                    return;
                }
            }
            //select
            result.Add(array[position]);
            TargetSumSubset(array, position + 1, (targetSum - array[position]), result);
            result.Remove(array[position]);

            //reject
            TargetSumSubset(array, position+1, targetSum, result);
        }
    }
}
