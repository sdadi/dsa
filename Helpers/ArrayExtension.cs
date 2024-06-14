using System.Text;

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
        public static string PrintString<T>(this List<T> A)
        {
            StringBuilder op = new StringBuilder();
            for (int i=0;i<A.Count;i++)
            {
                op.Append(A[i]);
                if(i!=A.Count-1)
                    op.Append(" ");
            }
            return op.ToString();
        }
        public static void PrintArray<T>(this List<T> A)
        {
            Console.WriteLine(PrintString(A));
        }
        public static void Swap<T>(this List<T> A, int i, int j)
        {
            T temp = A[i];
            A[i] = A[j]; 
            A[j] = temp;
        }
    }
}
