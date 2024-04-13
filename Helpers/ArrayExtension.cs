namespace Helpers
{
    public static class ArrayExtension
    {
        public static void ReverseArray<T>(this List<T> A, int start, int end)
        {
            while(start < end)
            {
                T temp = A[start];
                A[start] = A[end];
                A[end] = temp;
                start++;
                end--;
            }
        }
        public static void PrintArray<T>(this List<T> A)
        {
            foreach(var item in A)
            {
                Console.Write(item + "  ");
            }
        }
        public static void Swap<T>(this List<T> A, int i, int j)
        {
            T temp = A[i];
            A[i] = A[j]; 
            A[j] = temp;
        }
    }
}
