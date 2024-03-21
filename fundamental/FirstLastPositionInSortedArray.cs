namespace fundamental
{
    internal class FirstLastPositionInSortedArray
    {
        public static void Find()
        {
            int[] array = { 1, 2, 3, 5, 5, 5, 5, 5, 6, 7, 8 };//SortedArray
            int target = 5;
            string indices = "", values = "";
            for (int i = 0; i < array.Length; i++)
            {
                indices += i.ToString().PadLeft(2,' ')+", ";
                values += array[i].ToString().PadLeft(2,' ') + ", ";
            }
            Console.WriteLine(indices.Substring(0, indices.Length - 1));
            Console.WriteLine(values.Substring(0,values.Length - 1));

            int left = 0, right = array.Length - 1;
            int first = -1, last = -1, mid = -1;

            while (left <= right)// find firstIndex
            {
                mid = (left + right) / 2;
                if (array[mid] == target)
                {
                    first = mid;
                    right = mid - 1;
                }
                else if (array[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            left = 0;
            right = array.Length - 1;
            while (left <= right)// find lastIndex
            {
                mid = (left + right) / 2;
                if (array[mid] == target)
                {
                    last = mid;
                    left = mid + 1;
                }
                else if (array[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            Console.WriteLine($"\nTarget {target}: First index at {first} and Last index at {last}");
        }
    }
}
