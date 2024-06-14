namespace _3Advanced
{
    /// <summary>
    /// Design and implement a data structure for Least Recently Used (LRU) cache. It should support the following operations: get and set.
    /// get(key) - Get the value(will always be positive) of the key if the key exists in the cache, otherwise return -1.
    /// set(key, value) - Set or insert the value if the key is not already present.When the cache reaches its capacity, 
    /// it should invalidate the least recently used item before inserting the new item.
    /// The LRUCache will be initialized with an integer corresponding to its capacity.
    /// Capacity indicates the maximum number of unique keys it can hold at a time.
    /// Definition of "least recently used" : An access to an item is defined as a get or a set operation of the item. 
    /// "Least recently used" item is the one with the oldest access time.
    /// NOTE: If you are using any global variables, make sure to clear them in the constructor.
    /// </summary>
    internal class LRUCache
    {
        int _capacity = 0;
        Dictionary<int, DLinkedList> hashMap = null;
        DLinkedList Head = null;
        DLinkedList Tail = null;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            hashMap = new Dictionary<int, DLinkedList>(capacity);
        }

        public int get(int key)
        {
            if (hashMap.ContainsKey(key))
            {
                DLinkedList node = hashMap[key];
                RemoveNode(node);
                InsertNode(node);
                return node.val;
            }
            else
                return -1;
        }

        public void set(int key, int value)
        {
            var node = new DLinkedList(key,value);
            if (hashMap.ContainsKey(key))
            {
                node = hashMap[key];
                node.val = value;
                RemoveNode(node);
                InsertNode(node);
            }
            else
            {
                if (hashMap.Count < _capacity)
                {
                    InsertNode(node);
                }
                else
                {
                    hashMap.Remove(Tail.key);
                    RemoveNode(Tail);
                    InsertNode(node);
                }
                hashMap.Add(key, node);
            }
        }

        private void RemoveNode(DLinkedList node)
        {
            if (node.prev != null)
                node.prev.next = node.next;
            else
                Head = node.next;

            if (node.next != null)
                node.next.prev = node.prev;
            else
                Tail = node.prev;
        }

        private void InsertNode(DLinkedList node)
        {
            node.next = Head;
            node.prev = null;
            if (Head != null)
            {
                Head.prev = node;
            }

            Head = node;
            if (Tail == null)
            {
                Tail = node;
            }
        }

    }
    internal class DLinkedList
    {
        public DLinkedList(int key ,int val)
        {
            this.key = key;
            this.val = val;
            prev = null;
            next = null;
        }

        public int val;
        public int key;
        public DLinkedList next;
        public DLinkedList prev;
    }
}
