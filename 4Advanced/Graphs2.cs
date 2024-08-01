using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace _4Advanced
{
    internal class Graphs2
    {
        #region Problem 1
        #endregion

        #region Problem 1
        #endregion

        #region RottenOranges
        /// <summary>
        /// Given a matrix of integers A of size N x M consisting of 0, 1 or 2.
        /// Each cell can have three values:
        /// The value 0 representing an empty cell.
        /// The value 1 representing a fresh orange.
        /// The value 2 representing a rotten orange.
        /// Every minute, any fresh orange that is adjacent (Left, Right, Top, or Bottom) to a rotten orange becomes rotten.
        /// Return the minimum number of minutes that must elapse until no cell has a fresh orange. 
        /// If this is impossible, return -1 instead.
        /// Note: Your solution will run on multiple test cases. 
        /// If you are using global variables, make sure to clear them.
        /// Problem Constraints
        /// 1 <= N, M <= 1000
        /// 0 <= A[i][j] <= 2
        /// </summary>
        public static void RottenOranges()
        {
            List<List<int>> A = [   [2, 1, 1],
                                    [1, 1, 0],
                                    [0, 1, 1]
                                ];//4



            //A = [   [2, 1, 1],
            //        [0, 1, 1],
            //        [1, 0, 1]
            //    ];//-1

            var que = new Queue<Tuple<int, int, int>>();
            for (int r = 0; r < A.Count; r++)
            {
                for (int c = 0; c < A[r].Count; c++)
                {
                    if (A[r][c] == 2)
                    {
                        var item = Tuple.Create(r, c, 0);
                        que.Enqueue(item);
                    }
                }
            }
            int time = 0;
            int[] dr = [-1, 0, 1, 0];
            int[] dc = [0, 1, 0, -1];

            while (que.Count > 0)
            {
                var item = que.Dequeue();
                time = Math.Max(time, item.Item3);
                for (int i = 0; i < 4; i++)
                {
                    int row = item.Item1 + dr[i];
                    int col = item.Item2 + dc[i];
                    if (0 <= row && row < A.Count &&
                        0 <= col && col < A[0].Count &&
                        A[row][col] == 1)
                    {
                        A[row][col] = 2;//it can be any value > 1
                        que.Enqueue(Tuple.Create(row, col, item.Item3 + 1));
                    }
                }
            }


            for (int r = 0; r < A.Count; r++)
            {
                for (int c = 0; c < A[r].Count; c++)
                {
                    if (A[r][c] == 1)
                    {
                        time = -1;
                        break;
                    }
                }
                if (time == -1)
                    break;
            }
            Console.WriteLine(time);
        }
        #endregion

        #region Problem 1
        #endregion

        #region Topological Sort
        /// <summary>
        /// Given an directed acyclic graph having A nodes. 
        /// A matrix B of size M x 2 is given which represents the M edges 
        /// such that there is a edge directed from node B[i][0] to node B[i][1].
        /// Topological sorting for Directed Acyclic Graph(DAG) is a linear ordering of vertices 
        /// such that for every directed edge uv, vertex u comes before v in the ordering.
        /// Topological Sorting for a graph is not possible if the graph is not a DAG.
        /// Return the topological ordering of the graph and if it doesn't exist then return an empty array.
        /// If there is a solution return the correct ordering.If there are multiple solutions print the lexographically smallest one.
        /// Ordering (a, b, c) is said to be lexographically smaller than ordering (e, f, g) if a<e or if(a==e) then b<f and so on.
        /// NOTE:
        /// There are no self-loops in the graph.
        /// The graph may or may not be connected.
        /// Nodes are numbered from 1 to A.
        /// Your solution will run on multiple test cases. 
        /// If you are using global variables make sure to clear them.
        /// Problem Constraints
        /// 2 <= A <= 10^4
        /// 1 <= M <= min(100000, A*(A-1))
        /// 1 <= B[i][0], B[i][1] <= A
        /// </summary>
        public static void TopologicalSort()
        {
            int A = 6;
            List<List<int>> B = [  [6, 3],
                                    [6, 1],
                                    [5, 1],
                                    [5, 2],
                                    [3, 4],
                                    [4, 2]
                                ];//[5, 6, 1, 3, 4, 2]

            A = 3;
            B = [  [1, 2],
                    [2, 3],
                    [3, 1]
                ];//[]


        }

        #endregion
    }
}
