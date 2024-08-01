namespace _4Advanced
{
    internal class Graphs1
    {
        /// <summary>
        /// Given an directed graph having A nodes labelled from 1 to A containing M edges given by matrix B of size M x 2 
        /// such that there is a edge directed from node
        /// B[i][0] to node B[i][1].
        /// Find whether a path exists from node 1 to node A.
        /// Return 1 if path exists else return 0.
        /// NOTE:
        /// There are no self-loops in the graph.
        /// There are no multiple edges between two nodes.
        /// The graph may or may not be connected.
        /// Nodes are numbered from 1 to A.
        /// Your solution will run on multiple test cases. If you are using global variables make sure to clear them.
        /// Problem Constraints
        /// 2 <= A <= 10^5
        /// 1 <= M <= min(200000, A*(A-1))
        /// 1 <= B[i][0], B[i][1] <= A
        /// </summary>
        public static void PathInDirectedGraph()
        {
            int A = 5;
            List<List<int>> B = [  [1, 2],
                                    [4, 1],
                                    [2, 4],
                                    [3, 4],
                                    [5, 2],
                                    [1, 3] ];//0

            A = 5;
            B = [  [1, 2],
                    [2, 3],
                    [3, 4],
                    [4, 5] ];//1

            var visited = new List<bool>(Enumerable.Repeat<bool>(false, B.Count + 1));
            var result = 0;

            for (int i = 1; i <= A; i++)
            {
                if (!visited[i] && DFS_PathDG(B, visited, i, A) == 1)
                {

                    result = 1; break;
                }
            }
            Console.WriteLine(result);
        }
        private static int DFS_PathDG(List<List<int>> graph, List<bool> visited, int i, int target)
        {
            visited[i] = true;
            int edge = graph[i - 1][1];
            if (edge == target)
                return 1;
            if (!visited[edge])
            {
                return DFS_PathDG(graph, visited, edge, target);
            }
            return 0;
        }

        /// <summary>
        /// Given a matrix of integers A of size N x M consisting of 0 and 1. 
        /// A group of connected 1's forms an island. From a cell (i, j) 
        /// such that A[i][j] = 1 you can visit any cell that shares a corner with (i, j) 
        /// and value in that cell is 1.
        /// More formally, from any cell(i, j) if A[i][j] = 1 you can visit:
        /// (i-1, j) if (i-1, j) is inside the matrix and A[i - 1][j] = 1.
        /// (i, j-1) if (i, j-1) is inside the matrix and A[i][j - 1] = 1.
        /// (i+1, j) if (i+1, j) is inside the matrix and A[i + 1][j] = 1.
        /// (i, j+1) if (i, j+1) is inside the matrix and A[i][j + 1] = 1.
        /// (i-1, j-1) if (i-1, j-1) is inside the matrix and A[i - 1][j - 1] = 1.
        /// (i+1, j+1) if (i+1, j+1) is inside the matrix and A[i + 1][j + 1] = 1.
        /// (i-1, j+1) if (i-1, j+1) is inside the matrix and A[i - 1][j + 1] = 1.
        /// (i+1, j-1) if (i+1, j-1) is inside the matrix and A[i + 1][j - 1] = 1.
        /// Return the number of islands.
        /// NOTE: Rows are numbered from top to bottom and columns are numbered from left to right.
        /// Problem Constraints
        /// 1 <= N, M <= 100
        /// 0 <= A[i] <= 1
        /// </summary>
        public static void NumberOfIslands()
        {
            List<List<int>> A = [
                                   [0, 1, 0],
                                   [0, 0, 1],
                                   [1, 0, 0]
                                 ];//2


            //A = [
            //        [1, 1, 0, 0, 0],
            //        [0, 1, 0, 0, 0],
            //        [1, 0, 0, 1, 1],
            //        [0, 0, 0, 0, 0],
            //        [1, 0, 1, 0, 1]
            //    ];//5

            int result = 0;
            for(int r = 0;r < A.Count;r++)
            {
                for(int c = 0;c < A[r].Count; c++)
                {
                    if(A[r][c] == 1)
                    {
                        result++;
                        CheckConnectedIsland(A, r, c);
                    }
                }
            }
            Console.WriteLine(result);
        }
        private static void CheckConnectedIsland(List<List<int>> A,int r, int c)
        {
            A[r][c] = 2;
            int[] row = [-1, -1, -1, 0, 0, 1, 1, 1];
            int[] col = [-1, 0, 1, -1, 1, -1, 0, 1];

            for(int i = 0; i < 8; i++)
            {
                int r_new = r + row[i];
                int c_new = c + col[i];
                if(0 <= r_new && r_new < A.Count &&
                    0<= c_new && c_new < A[r].Count &&
                    A[r_new][c_new] == 1)
                {
                    CheckConnectedIsland(A,r_new,c_new);
                }
            }
        }

        /// <summary>
        /// Given an directed graph having A nodes. 
        /// A matrix B of size M x 2 is given which represents the M edges 
        /// such that there is a edge directed from node B[i][0] to node B[i][1].
        /// Find whether the graph contains a cycle or not, return 1 if cycle is present else return 0.
        /// NOTE:
        /// The cycle must contain atleast two nodes.
        /// There are no self-loops in the graph.
        /// There are no multiple edges between two nodes.
        /// The graph may or may not be connected.
        /// Nodes are numbered from 1 to A.
        /// Your solution will run on multiple test cases. If you are using global variables make sure to clear them.
        /// Problem Constraints
        /// 2 <= A <= 10^5
        /// 1 <= M <= min(200000, A*(A-1))
        /// 1 <= B[i][0], B[i][1] <= A
        /// </summary>
        public static void CyclicInDirectedGraph()
        {
            int A = 5;
            List<List<int>> B = [  [1, 2],
                                    [4, 1],
                                    [2, 4],
                                    [3, 4],
                                    [5, 2],
                                    [1, 3] 
                                ];//1

            //A = 5;
            //B = [  [1, 2],
            //        [2, 3],
            //        [3, 4],
            //        [4, 5]
            //    ];//0

            bool result = false;
            var visit = new List<bool>(Enumerable.Repeat<bool>(false, A+1));
            var path = new List<bool>(Enumerable.Repeat<bool>(false, A+1));

            for (int i = 1; i <= A; i++)
            {
                if (!visit[i] && CyclicPath(B, visit, path, i))
                {
                    result = true;
                    break;
                }
            }


            Console.WriteLine(result?1:0);
        }
        private static bool CyclicPath(List<List<int>> graph, List<bool> visit, List<bool> path,int i)
        {
            visit[i] = true;
            path[i] = true;

            
            foreach(var edge in graph)
            {
                if (edge[0] == i)
                {
                    if (path[edge[1]]) 
                        return true;
                    if (!visit[edge[1]] && CyclicPath(graph, visit, path, edge[1]))
                    {
                        return true;
                    }
                }
            }

            path[i] = false;
            return false;
        }
    }
}
