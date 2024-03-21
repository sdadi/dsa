namespace fundamental.Arrays
{
    internal class _71SortingBasics
    {
        internal static void NobleInteger()
        {
            List<int> A = [-4, -2, 0, -1, -6];
            A.Sort();
            int N = A.Count;

            int left = 0, right = N - 1;
            while(left < right)
            {
                int temp = A[left];
                A[left] = A[right];
                A[right] = temp;
                left++;
                right--;
            }

            int ans = 0;
            if (A[0] == 0)
                ans++;

            int eCount = 0;
            for (int i = 1;i< N;i++)
            {
                if (A[i] < A[i - 1])
                    eCount = i;
                if (A[i] == eCount)
                    Console.WriteLine($"Noble Integer found at {A[i]}");
            }
            
            Console.WriteLine("No Noble Integer found");
        }
    }
}
