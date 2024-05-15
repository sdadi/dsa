public class Solution
{
    private List<List<int>> result = new List<List<int>>();
    public int solve(List<int> A)
    {
        if (A.Count == 1)
            return 0;
        A.Sort();
        SquareFull(A, new bool[A.Count], 0, -1);
        return result.Count;
    }
    public void SquareFull(List<int> A, bool[] visited, int visitedCnt, int lastNum)
    {
        if (visitedCnt == A.Count)
        {
            result.Add(new List<int>(A));
            return;
        }
        for (int i = 0; i < A.Count; ++i)
        {
            if (visited[i] || 
                (i > 0 && A[i] == A[i - 1] && !visited[i - 1]) ||
                (lastNum != -1 && !IsSquare(lastNum + A[i]))
                )
            {
                continue;
            }
            visited[i] = true;
            SquareFull(A, visited, visitedCnt + 1, A[i]);
            visited[i] = false;
        }
    }
    public bool IsSquare(int a)
    {
        int sqrt = (int)Math.Sqrt(a);
        return sqrt * sqrt == a;
    }
}