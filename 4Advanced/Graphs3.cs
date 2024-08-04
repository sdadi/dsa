using Helpers;

namespace _4Advanced
{
    internal class Graphs3
    {
        #region Commutable Islands
        /// <summary>
        /// There are A islands and there are M bridges connecting them. 
        /// Each bridge has some cost attached to it.
        /// We need to find bridges with minimal cost such that all islands are connected.
        /// It is guaranteed that input data will contain at least 
        /// one possible scenario in which all islands are connected with each other.
        /// Problem Constraints
        /// 1 <= A, M <= 6*10^4
        /// 1 <= B[i][0], B[i][1] <= A
        /// 1 <= B[i][2] <= 10^3
        /// </summary>
        public static void CommutableIslands()
        {
            int A = 4;
            List<List<int>> B = [  [1, 2, 1],//src,dest,wgt
                                    [2, 3, 4],
                                    [1, 4, 3],
                                    [4, 3, 2],
                                    [1, 3, 10]
                               ];//6

            //A = 4;
            //B = [  [1, 2, 1],
            //        [2, 3, 2],
            //        [3, 4, 4],
            //        [1, 4, 3]
            //    ];//6

            A = 3;
            B = [[1, 2, 10], [2, 3, 5], [1, 3, 9]];//14

            var visit = new List<bool>(Enumerable.Repeat<bool>(false, A + 1));
            var minHeap = new PriorityQueue<Tuple<int, int>, int>();//src, dest, wgt
            var dict = new Dictionary<int, List<Tuple<int, int>>>();//dest,wgt
            int cost = 0;

            for (int i = 0; i < B.Count; i++)
            {
                if (!dict.ContainsKey(B[i][0]))
                {
                    dict.Add(B[i][0], new List<Tuple<int, int>>());
                }
                dict[B[i][0]].Add(Tuple.Create(B[i][1], B[i][2]));
                if (!dict.ContainsKey(B[i][1]))
                {
                    dict.Add(B[i][1], new List<Tuple<int, int>>());
                }
                dict[B[i][1]].Add(Tuple.Create(B[i][0], B[i][2]));
            }

            visit[0] = visit[1] = true;
            foreach (var edge in dict[1])
            {
                minHeap.Enqueue(edge, edge.Item2);
            }

            while (minHeap.Count > 0)
            {
                Tuple<int, int> item = minHeap.Dequeue();

                if (visit[item.Item1]) continue;
                visit[item.Item1] = true;
                cost += item.Item2;
                if (dict.ContainsKey(item.Item1))
                {
                    foreach (var edge in dict[item.Item1])
                    {
                        minHeap.Enqueue(edge, edge.Item2);
                    }
                }
            }
            Console.WriteLine(cost);
        } 
        #endregion

        #region Dijkstra
        /// <summary>
        /// Given a weighted undirected graph having A nodes and M weighted edges, and a source node C.
        /// You have to find an integer array D of size A such that:
        /// D[i]: Shortest distance from the C node to node i.
        /// If node i is not reachable from C then -1.
        /// Note:
        /// There are no self-loops in the graph.
        /// There are no multiple edges between two pairs of vertices.
        /// The graph may or may not be connected.
        /// Nodes are numbered from 0 to A-1.
        /// Your solution will run on multiple test cases. If you are using global variables, make sure to clear them.
        /// Problem Constraints
        /// 1 <= A <= 1e5
        /// 0 <= B[i][0],B[i][1] < A
        /// 0 <= B[i][2] <= 1e3
        /// 0 <= C<A
        /// </summary>
        public static void Dijkstra()
        {
            int A = 6;
            List<List<int>> B = [   [0, 4, 9],
                                    [3, 4, 6],
                                    [1, 2, 1],
                                    [2, 5, 1],
                                    [2, 4, 5],
                                    [0, 3, 7],
                                    [0, 1, 1],
                                    [4, 5, 7],
                                    [0, 5, 1]
                    ];
            int C = 4;//[7, 6, 5, 6, 0, 6]


            //A = 5;
            //B = [   [0, 3, 4],
            //        [2, 3, 3],
            //        [0, 1, 9],
            //        [3, 4, 10],
            //        [1, 3, 8]
            //];
            //C = 4;//[14, 18, 13, 10, 0]

            A = 94;
            B = [[65, 71, 7], [31, 41, 7], [39, 91, 7], [17, 67, 10], [59, 82, 4], [27, 29, 9], [22, 43, 3], [0, 36, 9], [49, 62, 1], [38, 58, 10], [81, 93, 5], [63, 68, 10], [59, 81, 7], [1, 37, 8], [5, 14, 8], [35, 45, 4], [75, 83, 2], [64, 89, 9], [9, 53, 10], [51, 55, 1], [38, 92, 2], [19, 56, 9], [22, 56, 8], [14, 68, 5], [50, 88, 10], [75, 79, 3], [5, 70, 9], [17, 84, 9], [23, 71, 4], [6, 73, 8], [66, 67, 6], [12, 61, 5], [19, 52, 1], [58, 65, 1], [16, 60, 5], [32, 86, 7], [5, 58, 5], [42, 45, 10], [8, 62, 8], [8, 30, 6], [47, 90, 10], [7, 11, 7], [54, 66, 8], [14, 24, 2], [71, 90, 7], [16, 23, 6], [52, 87, 1], [3, 58, 8], [29, 54, 1], [24, 75, 9], [16, 20, 5], [61, 92, 5], [61, 83, 7], [24, 70, 10], [6, 51, 7], [27, 93, 5], [24, 46, 6], [29, 67, 5], [53, 58, 8], [29, 49, 5], [43, 66, 2], [13, 74, 7], [15, 78, 3], [29, 90, 1], [58, 92, 2], [22, 74, 8], [77, 88, 6], [3, 13, 7], [17, 41, 7], [33, 63, 6], [31, 64, 5], [5, 7, 1], [11, 61, 6], [14, 35, 8], [11, 40, 10], [52, 59, 4], [68, 80, 8], [56, 85, 3], [31, 86, 4], [5, 27, 8], [4, 16, 9], [29, 77, 6], [6, 54, 6], [10, 16, 6], [52, 60, 7], [14, 30, 5], [51, 88, 8], [53, 88, 1], [51, 75, 8], [65, 69, 7], [59, 87, 8], [40, 56, 10], [67, 92, 3], [48, 87, 4], [10, 70, 8], [13, 36, 1], [8, 77, 4], [5, 37, 3], [64, 82, 9], [52, 77, 7], [12, 87, 5], [43, 74, 3], [37, 93, 1], [50, 68, 4], [52, 68, 4], [80, 87, 9]];
            C = 25;//-1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 0 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 

            var result = new List<int>(Enumerable.Repeat(-1, A));
            var dict = new Dictionary<int, List<Tuple<int, int>>>();
            var minHeap = new PriorityQueue<Tuple<int, int>, int>();

            for (int i = 0; i < B.Count; i++)
            {
                if (!dict.ContainsKey(B[i][0]))
                {
                    dict.Add(B[i][0], new List<Tuple<int, int>>());
                }
                dict[B[i][0]].Add(Tuple.Create(B[i][1], B[i][2]));

                if (!dict.ContainsKey(B[i][1]))
                {
                    dict.Add(B[i][1], new List<Tuple<int, int>>());
                }
                dict[B[i][1]].Add(Tuple.Create(B[i][0], B[i][2]));
            }
            minHeap.Enqueue(Tuple.Create(C, 0), 0);
            while (minHeap.Count > 0)
            {
                var item = minHeap.Dequeue();
                if (result[item.Item1] != -1) continue;


                result[item.Item1] = item.Item2;
                if (dict.ContainsKey(item.Item1))
                {
                    foreach (var edge in dict[item.Item1])
                    {
                        if (result[edge.Item1] == -1)
                        {
                            int dist = edge.Item2 + result[item.Item1];
                            minHeap.Enqueue(Tuple.Create(edge.Item1, dist), dist);
                        }
                    }
                }
            }

            result.PrintArray();
        }
        #endregion

        #region Construction cost
        /// <summary>
        /// Given a graph with A nodes and C weighted edges. 
        /// Cost of constructing the graph is the sum of weights of all the edges in the graph.
        /// Find the minimum cost of constructing the graph by selecting some given edges such that 
        /// we can reach every other node from the 1st node.
        /// NOTE: Return the answer modulo 10^9+7 as the answer can be large.
        /// Problem Constraints
        /// 1 <= A <= 100000
        /// 0 <= C <= 100000
        /// 1 <= B[i][0], B[i][1] <= N
        /// 1 <= B[i][2] <= 10^9
        /// </summary>
        public static void ConstructionCost()
        {
            int A = 3;
            List<List<int>> B = [   [1, 2, 14],
                                    [2, 3, 7],
                                    [3, 1, 2]
                    ];//9

            //A = 3;
            //B = [   [1, 2, 20],
            //        [2, 3, 17]
            //    ];//37
            A = 1;
            B = [[]];//0

            //if(B == null || B.Count == 0) return 0;
            long cost = 0;
            int mod = 1000000007;
            var visit = new List<bool>(Enumerable.Repeat<bool>(false, A+1));
            var dict = new Dictionary<int, List<Tuple<int, int>>>();
            var minHeap = new PriorityQueue<Tuple<int,int>,int>();

            for (int i = 0; i < B.Count; i++)
            {
                if (!dict.ContainsKey(B[i][0]))
                    dict.Add(B[i][0], new List<Tuple<int, int>>());
                dict[B[i][0]].Add(Tuple.Create(B[i][1], B[i][2]));

                if (!dict.ContainsKey(B[i][1]))
                    dict.Add(B[i][1], new List<Tuple<int, int>>());
                dict[B[i][1]].Add(Tuple.Create(B[i][0], B[i][2]));
            }

            visit[0] = visit[1] = true;
            foreach(var edge in dict[1])
            {
                minHeap.Enqueue(edge, edge.Item2);
            }

            while(minHeap.Count > 0)
            {
                var item = minHeap.Dequeue();
                if (visit[item.Item1])
                    continue;

                visit[item.Item1] = true;
                cost = (cost % mod + item.Item2 % mod) % mod;
                if (dict.ContainsKey(item.Item1))
                {
                    foreach (var edge in dict[item.Item1])
                    {
                        if (!visit[edge.Item1])
                        {
                            minHeap.Enqueue(edge, edge.Item2);
                        }
                    }
                }
            }
            int result = (int)(cost%mod);
            Console.WriteLine(result);
        }
        #endregion

        #region Damaged Records
        /// <summary>
        /// You are the Prime Minister of a country and once you went for a world tour.
        /// After 5 years, when you returned to your country, 
        /// you were shocked to see the condition of the roads between the cities.
        /// So, you plan to repair them, but you cannot afford to spend a lot of money.
        /// The country can be represented as a (N+1) x(M+1) grid, where Country(i, j) is a city.
        /// The cost of repairing a road between (i, j) and (i + 1, j) is A[i]. 
        /// The cost of repairing a road between(i, j) and(i, j + 1) is B[j].
        /// Return the minimum cost of repairing the roads such that 
        /// all cities can be visited from city indexed(0, 0).
        /// As the cost can be large, return the cost modulo 10^9+7.
        /// Problem Constraints
        /// 1 <= N, M <= 10^5
        /// 1 <= A[i], B[i] <= 10^3
        /// </summary>
        public static void DamagedRecords()
        {
            List<int> A = [1, 1, 1];
            List<int> B = [1, 1, 2];//16


            A = [1, 2, 3];
            B = [4, 5, 6];//39

            int mod = 1000000007;
            long cost = 0;


            Console.WriteLine((int)(cost%mod));
        }
        #endregion
    }
}
