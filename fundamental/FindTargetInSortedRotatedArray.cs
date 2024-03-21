namespace fundamental
{
    internal class FindTargetInSortedRotatedArray
    {
        public static void FindTargetIndex()
        {
            int[] array = { 22, 34, 33, 39, 45, 56, 1, 2, 3, 4, 5 };
            string indices = "", values = "";
            for (int i = 0; i < array.Length; i++)
            {
                indices += i.ToString().PadLeft(2, ' ') + ", ";
                values += array[i].ToString().PadLeft(2, ' ') + ", ";
            }
            Console.WriteLine("Indices are      :"+indices.Substring(0, indices.Length - 1));
            Console.WriteLine("Array values are :"+values.Substring(0, values.Length - 1));

            int target = 1;
            int minIndex = FindMinIndex(array);

            int resultIndex = BinarySearch(array, 0, minIndex, target);
            if(-1 == resultIndex)
                resultIndex = BinarySearch(array,minIndex,array.Length-1, target);

            Console.WriteLine($"Index of target {target} is at index {resultIndex}");

        }
        static int BinarySearch(int[] array,int left, int right, int target)
        {
            while(left <= right)
            {
                int mid = (left + right) / 2;
                if (array[mid] == target)
                {
                    return mid;
                }
                else if (array[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return -1;
        }
        public static void FindMinvalue()
        {
            int[] array = { 22, 34, 33, 39, 45, 56, 1, 2, 3, 4, 5 };
            string indices = "", values = "";
            for (int i = 0; i < array.Length; i++)
            {
                indices += i.ToString().PadLeft(2, ' ') + ", ";
                values += array[i].ToString().PadLeft(2, ' ') + ", ";
            }
            Console.WriteLine("Indices are      :" + indices.Substring(0, indices.Length - 1));
            Console.WriteLine("Array values are :" + values.Substring(0, values.Length - 1));

            int minIndex = FindMinIndex(array);
            Console.WriteLine($"Minimum value is {array[minIndex]} at index {minIndex}");
        }
        static int FindMinIndex(int[] array)
        {
            int left = 0, right = array.Length-1;
            while(left < right)
            {
                int mid = (left+right)/2;
                if (array[mid] < array[right])
                    right = mid; 
                else
                    left = mid + 1;
            }
            return left;
        }
    }
}
