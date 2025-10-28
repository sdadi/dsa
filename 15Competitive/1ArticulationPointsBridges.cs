namespace _15Competitive {
    internal class _1ArticulationPointsBridges {
        /// <summary>
        /// Given an undirected graph having A nodes. A matrix B of size M x 2 is given which represents the M edges such that there is a edge between node B[i][0] and node B[i][1].
        /// You have to find all the Articulation Points in the graph.
        ///A vertex in an undirected connected graph is an articulation point iff removing it (and edges through it) disconnects the graph.
        ///For a disconnected undirected graph, an articulation point is a vertex removing which increases number of connected components.
        ///Return an one-dimensional array which contains all the Articulation Points.
        ///You can return the Articulation points in any order.
        ///NOTE:
        ///There are no self-loops in the graph.
        ///There are no multiple edges between two nodes.
        ///The graph may or may not be connected.
        ///Nodes are numbered from 1 to A.
        ///Your solution will run on multiple test cases. If you are using global variables make sure to clear them.
        ///
        ///Problem Constraints
        ///
        ///1 <= A, M <= 3×105
        ///1 <= B[i][0], B[i][1] <= A
        /// </summary>
        public void ArticulationPoints() {
            int A = 5;
            List<List<int>> B = [  [1, 2]
                            ,[4, 1]
                            ,[2, 4]
                            ,[3, 4]
                            ,[5, 2]
                            ,[3, 1] ];//[2]

            //A = 5;
            //B = [  [1, 2]
            //,[2, 3]
            //,[3, 4]
            //,[4, 5] ]; //[2,3,4]

            A = 52;
            B = [[44, 50], [23, 26], [20, 45], [4, 26], [12, 33], [9, 41], [30, 51], [2, 26], [2, 23], [16, 18], [32, 51], [30, 49], [46, 52], [13, 31], [2, 37], [11, 44], [22, 23], [31, 40], [1, 5], [13, 44], [6, 13], [23, 37], [29, 37], [8, 43], [13, 37], [30, 36], [11, 39], [11, 42], [29, 32], [28, 32], [26, 37], [28, 45], [7, 31], [15, 46], [31, 51], [15, 19], [22, 36], [6, 47], [10, 48], [19, 27], [2, 19], [11, 40], [33, 35], [8, 38], [38, 43], [3, 36], [1, 16], [22, 32], [18, 20], [31, 43], [18, 44], [5, 33], [21, 42], [17, 29], [2, 51], [12, 19], [13, 47], [18, 38], [22, 27], [15, 21], [10, 31], [16, 20], [44, 45], [2, 11], [7, 36], [8, 47], [25, 38], [10, 36], [1, 41], [5, 49], [11, 38], [32, 40], [32, 37], [17, 45], [6, 37], [2, 10], [13, 48], [3, 26], [5, 9], [43, 50], [17, 52], [2, 42], [10, 27], [24, 37], [37, 51], [10, 29], [24, 46], [38, 46], [46, 51], [14, 44], [6, 39], [31, 35], [39, 41], [2, 15], [3, 13], [16, 27], [20, 23], [16, 28], [12, 20], [3, 4], [26, 35], [12, 50], [35, 41], [21, 30], [27, 52], [2, 45], [23, 45], [14, 51]];//[38]

            var edges = new Dictionary<int, List<int>>();
            for (int i = 0; i <= A; i++) {
                edges.Add(i, new List<int>());
            }
            for (int i = 0; i < B.Count; i++) {
                if (!edges.ContainsKey(B[i][0]))
                    edges.Add(B[i][0], new List<int>());
                edges[B[i][0]].Add(B[i][1]);

                if (!edges.ContainsKey(B[i][1]))
                    edges.Add(B[i][1], new List<int>());
                edges[B[i][1]].Add(B[i][0]);

            }

            var visited = new List<bool>(Enumerable.Repeat(false, A + 1));
            var marked = new List<bool>(Enumerable.Repeat(false, A + 1));
            var entryTime = new List<int>(Enumerable.Repeat(0, A + 1));
            var minTime = new List<int>(Enumerable.Repeat(0, A + 1));

            for (int i = 1; i <= A; i++) {
                if (!visited[i]) {
                    DFS(i, -1, edges, visited,entryTime,minTime,marked);
                }
            }
            Console.WriteLine();
            for(int i=1;i<=A;i++){
                if (marked[i])
                    Console.Write($"{i} ");
            }
        }
        int timer = 1;
        private void DFS(int node, int parent, Dictionary<int, List<int>> edges, List<bool> visited, List<int> entryTime, List<int> minTime,List<bool> marked) {
            visited[node] = true;
            minTime[node] = entryTime[node] = timer++;
            int subtree = 0;
            Console.Write($" {node} -> ");
            foreach (var neighbor in edges[node]) {
                if (node == parent) continue;
                
                if (!visited[neighbor]) { //tree edge
                    DFS(neighbor, node, edges, visited, entryTime, minTime,marked);
                    minTime[node] = Math.Min(minTime[node],minTime[neighbor]);

                    if (minTime[neighbor] >= entryTime[node] && parent != -1) {
                        marked[node] = true;
                    }
                    subtree++;
                } else {//backedge
                    minTime[node] = Math.Min(minTime[node],entryTime[neighbor]);
                }
            }
            if(subtree > 1 && parent == -1) {
                marked[node] = true;
            }
        }


        #region 2. Bridges in graph
        ///Given an undirected graph having A nodes. A matrix B of size M x 2 is given which represents the M edges such that there is a edge between node B[i][0] and node B[i][1].
        ///        You have to find all the bridges in the graph.
        ///        An edge in an undirected connected graph is a bridge if removing it disconnects the graph.For a disconnected undirected graph, the definition is similar, a bridge is an edge removing which increases the number of disconnected components.
        ///        Return an two-dimensional arrays which contains all the edges that are bridges.
        ///        You can return the bridges in any order but for nodes in a bridge order them in ascending order.
        ///        For example:
        ///        If there are 3 bridges in the graph having 7 nodes, (2, 1), (5, 3), (1, 7) Then you can return any one of the following array of array integers:
        ///[ [1, 2], [3, 5], [1, 7] ]
        ///[ [1, 2], [1, 7], [3, 5] ]
        ///[ [3, 5], [1, 2], [1, 7] ]
        ///[ [3, 5], [1, 7], [1, 2] ]
        ///[ [1, 7], [1, 2], [3, 5] ]
        ///[ [1, 7], [3, 5], [1, 2] ]
        ///NOTE:
        ///There are no self-loops in the graph.
        ///There are no multiple edges between two nodes.
        ///The graph may or may not be connected.
        ///Nodes are numbered from 1 to A.
        ///Your solution will run on multiple test cases. If you are using global variables make sure to clear them.
        ///Problem Constraints
        ///1 <= A <= 10^5
        ///1 <= B[i][0], B[i][1] <= A
        public void BridgesInGraph() {
            int A = 5;
            List<List<int>> B = [  [1, 2]
                        ,[4, 1]
                        ,[2, 4]
                        ,[3, 4]
                        ,[5, 2]
                        ,[3, 1] ];//[ [2,5] ]

            A = 5;
            B = [  [1, 2],
                    [2, 3],
                    [3, 4],
                    [4, 5] ];// [   [1, 2], [2, 3], [3, 4], [4, 5] ]
            A = 7;
            B = [[4, 6], [5, 6], [1, 6], [1, 4], [3, 4], [1, 7], [1, 3], [4, 5]];// [ [1,7] ]

            var edges = new Dictionary<int, List<int>>();
            var visited = new List<bool>(Enumerable.Repeat(false, A + 1));
            var marked = new List<bool>(Enumerable.Repeat(false, A + 1));
            var entryTime = new List<int>(Enumerable.Repeat(0, A + 1));
            var minTime = new List<int>(Enumerable.Repeat(0, A + 1));
            var bridges = new List<List<int>>();


            for (int i = 0; i <= A; i++) {
                edges.Add(i, new List<int>());
            }
            for (int i = 0; i < B.Count; i++) {
                if (!edges.ContainsKey(B[i][0]))
                    edges.Add(B[i][0], new List<int>());
                edges[B[i][0]].Add(B[i][1]);

                if (!edges.ContainsKey(B[i][1]))
                    edges.Add(B[i][1], new List<int>());
                edges[B[i][1]].Add(B[i][0]);

            }

            for (int i=1;i<=A;i++) {
                if(!visited[i]) {
                    DFSBridges(i, -1, edges, visited, entryTime, minTime, bridges);
                }
            }


            Console.WriteLine();
            foreach(var bridge in bridges) {
                Console.WriteLine($"[{bridge[0]}, {bridge[1]}]");
            }
            for(int i=0;i<marked.Count;i++) {
                if (marked[i]) Console.Write($"{i} ");
            }
        }

        private void DFSBridges(int node, int parent, Dictionary<int, List<int>> edges, List<bool> visited, List<int> entryTime, List<int> minTime, List<List<int>> bridges) {
            visited[node] = true;
            minTime[node] = entryTime[node] = timer++;
            foreach(var neighbor in edges[node]) {
                if (neighbor == parent) continue;

                if (visited[neighbor]) {
                    minTime[node] = Math.Min(minTime[node], entryTime[neighbor]);
                } else {
                    DFSBridges(neighbor, node, edges, visited, entryTime, minTime, bridges);
                    minTime[node] = Math.Min(minTime[node], minTime[neighbor]);
                    if (minTime[neighbor] > entryTime[node]) {
                        bridges.Add(new List<int>() { Math.Min(node, neighbor), Math.Max(node, neighbor) });
                    }
                }
            }
        }
        #endregion

    }
}

