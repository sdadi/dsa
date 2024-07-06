namespace _4Advanced
{
    internal class HashingClass_3
    {
        /// <summary>
        /// Shaggy has an array A consisting of N elements. 
        /// We call a pair of distinct indices in that array a special if elements at those indices in the array are equal.
        /// Shaggy wants you to find a special pair such that the distance between that pair is minimum.
        /// Distance between two indices is defined as |i-j|. If there is no special pair in the array, then return -1.
        /// Problem Constraints
        /// 1 <= |A| <= 10^5
        /// </summary>
        public static void ShaggyAndDistances()
        {
            List<int> A = [7, 1, 3, 4, 1, 7];//3

            //A = [1, 1];//1
            A = [7, 1, 3, 4, 1, 7, 7];//1

            var map = new Dictionary<int, int>();
            int min = int.MaxValue;
            for (int i = 0; i < A.Count; i++)
            {
                if (map.ContainsKey(A[i]))
                {
                    int diff = i - map[A[i]];
                    min = Math.Min(min, diff);
                }
                map[A[i]] = i;
            }
            Console.WriteLine(min == int.MaxValue ? -1 : min);
        }

        /// <summary>
        /// Given an array A of N integers.
        /// Find the length of the longest subarray in the array which sums to zero.
        /// If there is no subarray which sums to zero then return 0.
        /// Problem Constraints
        /// 1 <= N <= 10^5
        /// -10^9 <= A[i] <= 10^9
        /// </summary>
        public static void LongestSubArrayZeroSum()
        {
            List<int> A = [1, -2, 1, 2];//3

            A = [3, 2, -1]; //0

            int longest = 0;
            int N = A.Count;
            long sum = A[0];
            List<long> prefix = [A[0]];

            for (int i = 1; i < N; i++)
            {
                prefix.Add(prefix[i - 1] + (long)A[i]);
            }
            if (prefix[N - 1] == 0)
                longest = N - 1;
            for(int left =0;left< N; left++)
            {
                for(int right = left; right < N; right++)
                {
                    sum = prefix[right];
                    if(left > 0) sum -= prefix[left-1];
                    if(sum == 0)
                    {
                        longest = Math.Max(longest, (right-left+1));
                    }
                }
            }
            Console.WriteLine(longest);
        }
    }
}
