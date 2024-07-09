namespace _4Advanced
{
    internal class MinHeapClass
    {
        private List<int> _heapList;
        public MinHeapClass()
        {
            _heapList = new List<int>();
        }
        public MinHeapClass(int[] array)
        {
            _heapList = new List<int>(array);
        }
        public int[] BuildHeap()
        {
            int N = _heapList.Count;
            for (int i = N / 2 - 1; i >= 0; i--)
            {
                Heapify(_heapList, i);
            }
            
            return _heapList.ToArray();
        }
        private static void Heapify(List<int> array, int index)
        {
            int N = array.Count;
            int smallest = index, left = 2 * index + 1, right = 2 * index + 2;

            if (left < N && array[left] < array[smallest])
            {
                smallest = left;
            }
            if (right < N && array[right] < array[smallest])
            {
                smallest = right;
            }
            if (smallest != index)
            {
                int temp = array[smallest];
                array[smallest] = array[index];
                array[index] = temp;
                Heapify(array, smallest);
            }
        }
        public int Count
        {
            get { return _heapList.Count; }
        }
        public int PeekMin()
        {
            if (Count > 0)
            {
                return _heapList[0];
            }
            return int.MinValue;
        }
        public int GetMin()
        {
            int result = _heapList[0];
            _heapList[0] = _heapList[_heapList.Count - 1];
            _heapList.RemoveAt(_heapList.Count - 1);

            int index = 0;
            while (index < Count)
            {
                int left = 2 * index + 1;
                int right = 2 * index + 2;

                if (left < Count && right < Count)
                {
                    if (_heapList[left] <= _heapList[index] && _heapList[left] <= _heapList[right])
                    {
                        Swap(left, index);
                        index = left;
                    }
                    else if (_heapList[right] <= _heapList[index] && _heapList[right] <= _heapList[left])
                    {
                        Swap(right, index);
                        index = right;
                    }
                    else
                        break;
                }
                else if (left < Count)
                {
                    if (_heapList[left] <= _heapList[index])
                    {
                        Swap(left, index);
                        index = left;
                    }
                    else break;
                }
                else
                    break;
            }


            return result;
        }
        private void Swap(int left, int right)
        {
            int temp = _heapList[left];
            _heapList[left] = _heapList[right];
            _heapList[right] = temp;
        }
        public void Insert(int val)
        {
            _heapList.Add(val);
            int index = _heapList.Count-1;
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (val < _heapList[parent])
                {
                    _heapList[index] = _heapList[parent];
                    _heapList[parent] = val;
                    index = parent;
                }
                else
                    break;
            }
        }
    }

    public class MaxHeapClass
    {

    }
}
