namespace fundamental.Arrays
{
    internal class SortedArray
    {
        internal static void RemoveDuplicates()
        {
            List<int> a = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
            int len = a.Count;
            Console.WriteLine($"Array length is {len}");
            for (int i = a.Count - 1; i > 0; i--)
            {
                if (a[i] == a[i - 1])
                {
                    a.RemoveAt(i);
                    len--;
                }
            }
            Console.WriteLine($"unique elements count is {len}");
            foreach (int i in a)
                Console.Write(i + " ");
        }
    }
}
