using _3Advanced;
using Helpers;

namespace Intermediate
{
    internal class Contest4
    {

        public static void WarmerTemparature()
        {
            List<int> A = [73, 74, 75, 76, 77, 78, 79, 80];//[1 1 1 1 1 1 1 0]
            A = [75,71,69,72,76,73];//[4,2,1,1,0,0]


            List<int> result = new List<int>();
            foreach (var i in A)
                result.Add(0);
            var stack = new Stack<int>();

            for (int i = A.Count - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && A[stack.Peek()] <= A[i])
                {
                    stack.Pop();
                }
                if(stack.Count > 0)
                    result[i] = stack.Peek()-i;
                stack.Push(i);
            }

            result.PrintArray();
        }

        public static void MaximumGoodPair()
        {
            string A = "bcc";
            string B = "abc";//1

            //A = "add";
            //B = "abcd";//2

            //A = "aabbbbcc";
            //B = "abbccccccd";//2

            int j = 0,N = A.Length, M = B.Length;
            int result =0;
            int diff = 0;

           for(int i=0; i<A.Length; i++)
            {
                while(j<M && A[i] >= B[j])
                {
                    diff = j - i;
                    result = Math.Max(result, diff);
                    j++;
                }
                if (j >= M)
                    break;//after this any diff can never be max than till now.
            }

            Console.WriteLine(result);
        }


        public static void RemoveLoopFromLinkedList()
        {
            ListNode A = new ListNode(6);
            A.next = new ListNode(5);
            var pt = new ListNode(3);
            A.next.next = pt;
            pt.next = new ListNode(8);
            pt.next.next = pt;

            if (A == null)
                return;// A;

            var slow = A;
            var fast = A;
            bool isLoop = false;

            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (fast == slow)
                {
                    isLoop = true;
                    break;
                }
            }
            if (isLoop = false)
            {
                return;// A;
            }

            var current = A;
            while (slow.next != current.next)
            {
                slow = slow.next;
                current = current.next;
            }
            slow.next = null;
            A.PrintLinkedList();
        }
    }
}
