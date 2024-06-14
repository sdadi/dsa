namespace _3Advanced
{
    internal class QueueWithStack
    {
        /** Initialize your data structure here. */
        private Stack pushStack;
        private Stack popStack;
        public QueueWithStack()
        {
            pushStack = new Stack();
            popStack = new Stack();
        }

        /** Push element X to the back of queue. */
        public void Push(int X)
        {
            pushStack.Push(X);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            if (Empty())
                return -1;

            if (popStack.IsEmpty())
                MovePush2PopStack();

            return popStack.Pop();
        }

        /** Get the front element of the queue. */
        public int Peek()
        {
            if (Empty())
                return -1;

            if (popStack.IsEmpty())
                MovePush2PopStack();

            return popStack.Peek();
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return pushStack.IsEmpty() && popStack.IsEmpty();
        }

        private void MovePush2PopStack()
        {
            while (!pushStack.IsEmpty())
                popStack.Push(pushStack.Pop());
        }
    }

    public class QueueWithLinkedList
    {
        private ListNode Head;
        private ListNode Tail;
        public void Enqueue(int x)
        {
            var node = new ListNode(x);

            if (IsEmpty())
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.next = node;
                Tail = Tail.next;
            }
        }

        public int Dequeue()
        {
            if (IsEmpty())
                return -1;

            var node = Head;
            Head = Head.next;
            return node.val;
        }
        public int Front()
        {
            if (Head == null)
                return -1;
            return Head.val;
        }
        public int Rear()
        {
            if (Tail == null)
            {
                return -1;
            }
            return Tail.val;
        }
        public bool IsEmpty()
        {
            return Head == null && Tail == null;
        }
    }


    public class QueueWithDoubleLinkedList
    {
        private DoubleListNode Prev;
        private DoubleListNode Next;
        private DoubleListNode Head;
        private DoubleListNode Tail;

        public void EnqueueRear(int x)
        {
            var node = new DoubleListNode(x);

            if (Tail == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.next = node;
                node.prev = Tail;

                Tail = Tail.next;
            }
        }
        public void EnqueueFront(int x)
        {
            var node = new DoubleListNode(x);
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.next = Head;
                Head.prev = node;

                Head = Head.prev;
            }
        }
        public int DequeueRear()
        {
            if (IsEmpty())
                return -1;

            var node = Tail;
            if(Tail == Head)
            {
                Tail = Head= null;
                //Head = null;
            }
            if (Tail != null)
                Tail = Tail.prev;
            if (Tail != null)
                Tail.next = null;
            return node.val;
        }
        public int DequeueFront()
        {
            if (IsEmpty())
                return -1;

            var node = Head;
            if (Tail == Head)
            {
                Tail = null;
                Head = null;
            }
            if (Head != null)
                Head = Head.next;
            if (Head != null) 
                Head.prev = null;
            return node.val;
        }
        public int PeekFront()
        {
            if (IsEmpty())
                return -1;

            return Head.val;
        }
        public int PeekRear()
        {
            if (IsEmpty())
                return -1;
            return Tail.val;
        }
        public bool IsEmpty()
        {
            return Head == null && Tail == null;
        }
    }
}
