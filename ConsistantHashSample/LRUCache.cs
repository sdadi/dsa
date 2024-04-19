namespace ConsistantHashSample
{
    public class LRUCacheMain
    {
        public static void Run()
        {
            //6 1 S 2 1 S 2 2 G 2 S 1 1 S 4 1 G 2
            //95 11 S 1 1 G 11 G 11 S 3 10 G 10 S 3 12 S 1 15 S 4 12 G 15 S 8 6 S 5 3 G 2 G 12 G 10 S 11 5 G 7 S 5 1 S 15 5 G 2 S 13 8 G 3 S 14 2 S 12 11 S 7 10 S 5 4 G 9 G 2 S 13 5 S 10 14 S 9 11 G 5 S 13 11 S 8 12 G 10 S 5 12 G 8 G 11 G 8 S 9 11 S 10 6 S 7 12 S 1 7 G 10 G 9 G 15 G 15 G 3 S 15 4 G 10 G 14 G 10 G 12 G 12 S 14 7 G 11 S 9 10 S 6 12 S 14 11 G 3 S 7 5 S 1 14 S 2 8 S 11 12 S 8 4 G 3 S 13 15 S 1 4 S 5 3 G 3 G 9 G 14 G 9 S 13 10 G 14 S 3 9 G 8 S 3 5 S 6 4 S 10 3 S 11 13 G 8 G 4 S 2 11 G 2 G 9 S 15 1 G 9 S 7 8 S 4 3 G 3 G 1 S 8 4 G 13 S 1 2 G 3

            LRUCache cache = new LRUCache(2);

            cache.set(2, 1);
            cache.set(2, 2);
            Console.WriteLine(cache.get(2));
            cache.set(1, 1);
            cache.set(4, 1);
            Console.WriteLine(cache.get(1));

        }
    }
    internal class LRUCache
    {
        private Dictionary<int, Node> _map;
        private Node head;
        private Node tail;
        private int _capacity;

        public LRUCache(int capacity)
        {
            _map = new Dictionary<int, Node>();
            head = null;
            tail = null;
            _capacity = capacity;
        }
        public int get(int key)
        {
            if (_map.ContainsKey(key))
            {
                var node = _map[key];
                moveToHead(node);
                return node.Value;
            }
            return -1;
        }
        public void set(int key, int value)
        {
            if (_map.ContainsKey(key))
            {
                var node = _map[key];
                node.Value = value;
                moveToHead(node);
            }
            else
            {
                var item = new Node { Key = key, Value = value };
                if(_map.Count >= _capacity)
                {
                    _map.Remove(tail.Key);
                    removeLast();
                }
                _map.Add(key, item);
                addToHead(item);
            }
        }
        void moveToHead(Node node)
        {
            removeNode(node);
            addToHead(node);
        }
        private void addToHead(Node node)
        {
            if(head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.Next = head;
                head.Prev = node;
                head = node;
            }
        }
        private void removeNode(Node node)
        {
            if(node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }
            else
            {
                head = node.Next;
            }

            if(node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }
            else
            {
                tail = node.Prev;
            }
        }
        private void removeLast()
        {
            if(tail != null)
            {
                _map.Remove(tail.Key);
                removeNode(tail);
            }
        }


        private class Node
        {
            public int Key;
            public int Value;
            public Node Next;
            public Node Prev;
        }
    }
    internal class LRUCache<K, V>
    {
        private Dictionary<K, LinkedListNode<CacheItem>> _map;
        private LinkedList<CacheItem> _lruList;
        private readonly int _capacity = 0;
        public LRUCache(int capacity)
        {
            _map = new Dictionary<K, LinkedListNode<CacheItem>>(capacity);
            _lruList = new LinkedList<CacheItem>();
            _capacity = capacity;
        }
        internal V Get(K key)
        {
            if (_map.TryGetValue(key, out var node))
            {
                _lruList.Remove(node);
                _lruList.AddFirst(node);
                return node.Value.Value;
            }
            return default(V);
        }
        internal void Set(K key, V value)
        {
            if (_lruList.Count >= _capacity)
            {
                var node = _lruList.Last;
                _map.Remove(node.Value.Key);
                _lruList.RemoveLast();
            }
            var newNode = new LinkedListNode<CacheItem>(new CacheItem { Key = key, Value = value });
            _lruList.AddFirst(newNode);
            _map.Add(key, newNode);
        }

        private class CacheItem
        {
            public K Key;
            public V Value;
        }
    }
}
