namespace fundamental.Arrays
{
    internal class ArrayCarryForward
    {
        internal static void MaxMod()
        {
            //List<int> A = [683, 354, 95, 937, 78, 246, 319, 516, 913, 112];
            List<int> A = [1, 1, 1, 1];
            int N = A.Count;
            int mxValue = int.MinValue;
            int maxValue = int.MinValue;
            int maxMod = 0;
            for (int i = 0; i < N; i++)
            {
                if (A[i] > maxValue)
                {
                    mxValue = maxValue;
                    maxValue = A[i];
                }
                else if (A[i] > mxValue && A[i] != maxValue)
                    mxValue = A[i];
            }
            if (mxValue == int.MinValue) maxMod = 0;
            maxMod = mxValue % maxValue;

            Console.WriteLine($"first is {maxValue} second is {mxValue} and mod is {maxMod}");
        }
        /// <summary>Given an string or char[] find count of pairs i, j such that i< j & A[i]='a' & A[j]='g' </summary>
        internal static void PairsCount()
        {
            char[] A = ['a','b', 'e','g','a','g'];
            int count = 0;
            DateTime startTime = DateTime.Now;

            //Brute force
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < A.Length; j++)
                {
                    if (i<j && A[i] == 'a' && A[j] == 'g')
                        count++;
                }
            }
            DateTime endTime = DateTime.Now;
            TimeSpan ts = endTime - startTime;
            Console.WriteLine($"(a,g) pairs count is {count} found in {ts.Nanoseconds} Nanoseconds with TC as O(N^2) and SC as O(1)");

            // Solution 1
            startTime = DateTime.Now;
            count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != 'a') continue;
                for (int j = i + 1; j < A.Length; j++)
                {
                    if (A[j] == 'g')
                        count++;
                }
            }
            endTime = DateTime.Now;
            ts = endTime - startTime;
            Console.WriteLine($"(a,g) pairs count is {count} found in {ts.Nanoseconds} Nanoseconds with TC as O(N^2) and SC as O(1)");

            //Solution 2
            startTime = DateTime.Now;
            count = 0;
            int[] aprefixSum = new int[A.Length];
            aprefixSum[0] = (A[0] == 'a')?1:0;
            for (int i = 1; i < A.Length; i++)
                aprefixSum[i] =  (A[i] == 'a') ? aprefixSum[i-1]+ 1 : aprefixSum[i - 1];
            
            for (int j = 0; j < A.Length; j++)
            {
                if (A[j] == 'g') count += aprefixSum[j];
            }
            endTime = DateTime.Now;
            ts = endTime - startTime;
            Console.WriteLine($"(a,g) pairs count is {count} found in {ts.Nanoseconds} Nanoseconds with TC as O(N) and SC as O(N)");

            // Solution 3
            startTime = DateTime.Now;
            count = 0;
            int aCount = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == 'a') aCount++;
                if (A[i] == 'g') count += aCount;
            }
            endTime = DateTime.Now;
            ts = endTime - startTime;
            Console.WriteLine($"(a,g) pairs count is {count} found in {ts.Nanoseconds} Nanoseconds with TC as O(N) and SC as O(1)");

        }
    }
}
