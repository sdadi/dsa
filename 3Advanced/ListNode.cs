using System.Text;

namespace _3Advanced
{
    public  class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int data)
        {
            val = data;
            next = null;
        }
    }
    public class DoubleListNode
    {
        public DoubleListNode(int data)
        {
            val = data;
            prev = null;
            next = null;
        }
        public int val;
        public DoubleListNode next;
        public DoubleListNode prev;
    }

    public static class ListNodeExtension
    {
        public static void PrintLinkedList(this ListNode head)
        {
            Console.WriteLine(head.Stringify());
        }
        public static string Stringify(this ListNode head)
        {
            StringBuilder sb = new StringBuilder();
            ListNode temp = head;
            while (temp != null)
            {
                sb.Append($"{temp.val} ");
                temp = temp.next;
            }
            return sb.ToString();
        }

        public static ListNode ListToListNode(this List<int> input)
        {
            if (input == null || !input.Any()) return null;
            ListNode head = new ListNode(input[0]);
            var temp = head;
            for (int i = 1; i < input.Count; i++)
            {
                temp.next = new ListNode(input[i]);
                temp = temp.next;
            }
            return head;
        }
    }
}
