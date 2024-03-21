using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace fundamental
{
    internal class PermutationSample
    {
        public static void PrintPermutation()
        {
            int[] array = { 1, 2, 3 };
            PrintAtPosition(array, 0, new bool[array.Length], new List<int>());

        }
        static void PrintAtPosition(int[] array,int position, bool[] selected, List<int> result)
        {
            if(position == array.Length)
            {
                Console.WriteLine();
                foreach(int i in result)
                    Console.Write(i+ " ");
                return;
            }
            for(int i =0; i < array.Length; i++)
            {
                if (!selected[i])
                {
                    selected[i] = true;
                    result.Add(array[i]);
                    PrintAtPosition(array, position + 1, selected, result);
                    selected[i] = false;
                    result.Remove(array[i]);
                }
            }
        }
    }
}
