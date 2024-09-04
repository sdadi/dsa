using _3Advanced;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate
{
    internal class Contest6
    {
        #region Question1
        public static void NumbersDivisibleLessThanD()
        {
            int A=2, B=3, C = 4, D=10;
            //D = D - 1;
            int DA = D / A;
            int DB = D/ B;
            int DC = D/ C;
            int DAB = D/lcm(A, B);
            int DAC = D/lcm(A,C);
            int DBC = D/lcm(B,C);
            int DABC = (D* gcd(gcd(A, B), C))/ (A * B * C);

            int result = DA + DB + DC - DAB - DAC - DBC + DABC;

            Console.WriteLine(result);

        }
        private static int lcm(int a, int b)
        {
            return (a * b) / gcd(a, b);
        }
        private static int gcd(int x, int y)
        {
            if (x == y) return x;
            if (y == 0) return x;
            return gcd(y, x % y);
        }
        #endregion


        #region Question1
        public static void detectCycle()
        {
            ListNode a = new ListNode(1);
            a.next = new ListNode(2);
            var c  = new ListNode(3);
            a.next.next = c;
            a.next.next.next = new ListNode(4);
            a.next.next.next.next = c;

            var slow = a;
            var fast = a;
            var found = false;

            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    found = true;
                    break;
                }
            }
            if (found)
                Console.WriteLine(fast.val);
            else
                Console.WriteLine("null");
        }
        #endregion


        #region Question1
        public static void groupoddevenindicesLinkedList()
        {
            List<int> input = [1, 2, 3, 4];
            input = [5, 7, 6, 2, 9];
            var A = input.ListToListNode();

            //if (A == null) return A;
            var oddNode = new ListNode(0);
            var evenNode = new ListNode(0);

            var current = A;
            var c_odd = oddNode;
            var c_even = evenNode;
            int i = 1;

            while (current != null)
            {
                var temp = current;
                if (i % 2 == 0)
                {
                    c_even.next = current;
                    c_even = c_even.next;
                }
                else
                {
                    c_odd.next = current;
                    c_odd = c_odd.next;
                }
                current = current.next;
                i++;
            }
            c_even.next = null;
            //c_odd
            evenNode = evenNode.next;
            c_odd.next = evenNode;
            oddNode =  oddNode.next;
            oddNode.PrintLinkedList();
        }
        #endregion


        #region Question1
        public static int level = 0;
        public static Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();

        public static void minimumSemesters()
        {
            int A = 3;
            List<List<int>> B = [[1, 3], [2, 3]];
            A = 4;
            B = [[1, 3], [2, 3],[3,4]];
            bool isCyclicPath = false;
            var visit = new List<bool>(Enumerable.Repeat<bool>(false, A + 1));
            var path = new List<bool>(Enumerable.Repeat<bool>(false, A + 1));

            for (int i = 1; i <= A; i++)
            {
                if (!visit[i] && isCyclic(B, visit, path, i))
                {
                    isCyclicPath = true;
                    break;
                }
            }
            if (isCyclicPath)
            {
                Console.WriteLine(-1);
                return;
            }
            var adjList = new Dictionary<int, List<int>>();
            foreach (var item in B)
            {
                if (!adjList.ContainsKey(item[0]))
                    adjList.Add(item[0], new List<int>());
                adjList[item[0]].Add(item[1]);
            }
            var visited = new List<bool>(Enumerable.Repeat<bool>(false, A + 1));
            for (int i = 1; i <= A; i++)
            {
                if (!visited[i])
                    BFS(i, adjList,visited);
            }
            Console.WriteLine( level);
        }
        private static void BFS(int i, Dictionary<int, List<int>> adjList, List<bool> visited){
            queue.Enqueue(Tuple.Create(i, 1));
            visited[i] = true;
            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                level = Math.Max(level, item.Item2);
                if (adjList.ContainsKey(item.Item1))
                {
                    foreach (var adList in adjList[item.Item1])
                    {
                        if (!visited[adList])
                        {
                            queue.Enqueue(Tuple.Create(adList, item.Item2 + 1));
                            visited[adList] = true;
                        }
                    }
                }
            }

        }

        private static bool isCyclic(List<List<int>> graph, List<bool> visit, List<bool> path, int i)
        {
            visit[i] = true;
            path[i] = true;

            foreach (var edge in graph)
            {
                if (edge[0] == i)
                {
                    if (path[edge[1]])
                        return true;
                    if (!visit[edge[1]] && isCyclic(graph, visit, path, edge[1]))
                        return true;
                }
            }

            path[i] = false;
            return false;
        }
        #endregion


        #region Question1

        #endregion

    }
}
