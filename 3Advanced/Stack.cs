using System.Text;

namespace _3Advanced
{
    public class Stack
    {
        ListNode Head = null;
        public bool IsEmpty()
        {
            return (Head == null);
        }

        public int Peek()
        {
            if(IsEmpty())
                return -1;

            return Head.val;
        }
        public void Push(int data)
        {
            var node = new ListNode(data);
            node.next = Head;
            Head = node;
        }

        public int Pop()
        {
            if (IsEmpty())
                return -1;

            var node = Head;
            if (Head != null) 
                Head = Head.next;
            return node == null ? -1:node.val;
        }

        public List<int> ToList()
        {
            var output = new List<int>();
            if(Head == null)
                return output;
            var current = Head;
            while(current != null)
            {
                output.Insert(0, current.val);
                current = current.next;
            }
            return output;
        }
    }

    public static class StackExtension
    {
        public static string PrintStack(this Stack stack)
        {
            if(stack == null)
                return string.Empty;

            StringBuilder output = new StringBuilder();
            foreach(var item in stack.ToList())
            {
                output.Append(item+ " ");
            }
            return output.ToString().Trim();
        }
        public static string PrintCharStack(this Stack stack)
        {
            if (stack == null)
                return string.Empty;

            StringBuilder output = new StringBuilder();
            foreach(var item in stack.ToList())
            {
                output.Append((char)item + " ");
            }
            return output.ToString().Trim();
        }
    }
}
