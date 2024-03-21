namespace fundamental
{
    internal class FindMajorityElement
    {
        public static void Find()
        {
            int[] arr = { 4, 4, 3, 7,4,3,4, 8,1,4,4};

            Console.WriteLine($"Array to find Majority element in array of length {arr.Length} appearing {Math.Ceiling((decimal)arr.Length/2)} or more times");
            foreach (int i in arr) { Console.Write(i + " "); }
            Dictionary<int,int> dict = new Dictionary<int,int>(); ;

            foreach(int i in arr)
            {
                if (dict.ContainsKey(i))
                    dict[i]++;
                else dict.Add(i, 1);
            }
            //var candidate = dict.OrderByDescending(x => x.Value).First();
            KeyValuePair<int, int> candidate = new KeyValuePair<int, int>();
            int maxValue = 0;
            foreach (KeyValuePair<int, int> pair in dict)
            {
                if (pair.Value > maxValue)
                {
                    maxValue = Math.Max(maxValue, pair.Value);
                    candidate = pair;
                }

            }
            if (candidate.Value > arr.Length / 2)
                Console.WriteLine($"\nMajority element is {candidate.Key} appearing {maxValue} times");
            else Console.WriteLine("\nMajority element is not available");

        }
        public static void FindByMooresVotingAlgorithm() {
            int[] arr = { 4, 4, 3,4, 7, 3, 4, 8, 1, 4, 4 };
            Console.WriteLine($"Array to find Majority element in array of length {arr.Length} appearing {Math.Ceiling((decimal)arr.Length / 2)} or more times");
            foreach (int i in arr) { Console.Write(i + " "); }

            int candidate = arr[0];
            int count = 0;
            for(int i=0;i<arr.Length; i++)
            {
                if(candidate == arr[i])
                    count++;
                else
                    count--;
                if(count == 0)
                {
                    candidate = arr[i];
                    count = 1;
                }
            }
            count = 0;
            foreach(int i in arr)
                if(i == candidate) count++;
            
            if (count > arr.Length / 2)
                Console.WriteLine($"\nMajority element is {candidate} appearing {count} times");
            else
                Console.WriteLine("\nMajority element is not available");
        }
    }
}
