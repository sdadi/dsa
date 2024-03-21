namespace fundamental
{
    public static class Helper
    {
        public static void DisplayMatrix<T>(this List<List<T>> A)
        {
            for(int row=0;row<A.Count;row++)
            {
                for(int col =0;col < A[row].Count;col++) 
                {
                    Console.Write(A[row][col].ToString().PadLeft(3,' ') + "   ");
                }
                Console.WriteLine();
            }
        }
    }
}
