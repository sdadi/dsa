using System.Text;

namespace ConsistantHashSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            mapsample();
            //LRUCacheMain.Run();
            //return;
            ////MainWnd mn = new MainWnd();
            //mn.btnTest_Click();

            //var input = "Hello World!";
            //uint seed = 420;

            //ReadOnlySpan<byte> inputSpan = Encoding.UTF8.GetBytes(input).AsSpan();
            ////[InlineData("key", 293, 2495785535)]
            ////[InlineData("Hello World!", 420, 1535517821)]
            ////[InlineData("a$6ajXViSAfFw5pR2kkz3Q28YGrDx$jeaLJ5HFPe", 69, 3131871211)]
            //var actual = MurmurHash3.Hash32(ref inputSpan, seed);
            //Console.WriteLine($"Hash expected:{1535517821} and actual:{actual}");

        }
        static void mapsample()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, string> map = new Dictionary<string, string>();
            List<string> queries = new List<string>();
            string query = "";
            
            for(int i = 0; i < n; i++)
            {
                query = Console.ReadLine();
                string[] item = query.Split(" ");
                map.Add(item[0], item[1]??"");
            }

            while((query=Console.ReadLine()).Length > 0) 
            {
                queries.Add(query);
            }
            foreach(var name in queries)
            {
                if (map.ContainsKey(name))
                    Console.WriteLine($"{name}={map[name]}");
                else
                    Console.WriteLine("Not found");
            }
        }

    }

    public partial class MainWnd
    {
        class Server
        {
            public int ID { get; set; }

            public Server(int _id)
            {
                ID = _id;
            }

            public override int GetHashCode()
            {
                return ("svr_" + ID).GetHashCode();
            }
        }

        public void btnTest_Click()
        {
            List<Server> servers = new List<Server>();
            for (int i = 0; i < 1000; i++)
            {
                servers.Add(new Server(i));
            }

            ConsistentHash<Server> ch = new ConsistentHash<Server>();
            ch.Init(servers);

            int search = 100000;

            DateTime start = DateTime.Now;
            SortedList<int, int> ay1 = new SortedList<int, int>();
            for (int i = 0; i < search; i++)
            {
                int temp = ch.GetNode(i.ToString()).ID;

                ay1[i] = temp;
            }
            TimeSpan ts = DateTime.Now - start;
            Console.WriteLine(search + " each use macro seconds: " + (ts.TotalMilliseconds / search) * 1000);

            //ch.Add(new Server(1000));
            ch.Remove(servers[1]);
            SortedList<int, int> ay2 = new SortedList<int, int>();
            for (int i = 0; i < search; i++)
            {
                int temp = ch.GetNode(i.ToString()).ID;

                ay2[i] = temp;
            }

            int diff = 0;
            for (int i = 0; i < search; i++)
            {
                if (ay1[i] != ay2[i])
                {
                    diff++;
                }
            }

            Console.WriteLine("diff: " + diff);
        }
    }
}
