using _3Advanced;

namespace Intermediate
{
    internal class Contest4_2
    {
        public static void ContainerWithMostWater()
        {
            List<int> A = [1, 5, 4, 3];//0

            //A = [1];//0

            if(A == null || A.Count ==1)
            {
                Console.WriteLine(0);
                return;
            }
            var nsLeft = new List<int>();
            var nsRight = new List<int>();
            int maxArea = int.MinValue;

            for (int i = 0; i < A.Count; i++)
            {
                nsLeft.Add(-1);
                nsRight.Add(-1);
            }

            var stack = new Stack<int>();
            for (int i = 0; i < nsLeft.Count; i++)
            {
                while (stack.Count > 0 && A[stack.Peek()] >= A[i])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                    nsLeft[i] = stack.Peek();
                stack.Push(i);
            }

            stack = new Stack<int>();
            for(int i=A.Count-1; i>=0; i--)
            {
                while(stack.Count > 0 && A[stack.Peek()] >= A[i])
                {
                    stack.Pop();
                }
                if(stack.Count > 0)
                    nsRight[i] = stack.Peek();
                stack.Push(i);
            }

            for(int i = 0; i < A.Count; i++)
            {
                int left = nsLeft[i];
                int right = nsRight[i];

                int area = A[i] * (right - left - 1);
                maxArea = Math.Max(maxArea, area);
            }

            Console.WriteLine(maxArea);
        }


        public static void ReverseEvenNodes()
        {
            List<int> input = [1, 2, 3, 4];

            //input = [1, 2, 3];

            var A = input.ListToListNode();

            var odd = A;
            var evenH = new ListNode(-1);
            var even = evenH;

            if (A == null)
            {
                return;
            }

            while (odd != null)
            {
                even.next = odd.next;
                even = even.next;
                if (even != null)
                    odd.next = even.next;
                odd = odd.next;
            }
            evenH = evenH.next;
            var current = evenH;
            ListNode previous = null;

            while (current != null)
            {
                var next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }
            evenH = previous;

            odd = A;
            even = evenH;
            var result = new ListNode(-1);
            current = result;

            while(odd !=null && even != null)
            {
                //var next = odd.next;
                //odd.next = even;
                //even.next = next;
                //odd = even.next;
                current.next = odd;
                if(current.next != null)
                    current.next.
                odd = odd.next;
                current = current.next;
                current.next = even;
                even = even.next;
            }
            if (odd != null)
               current.next = odd;
            if (even != null)
                current.next = even;

            A.PrintLinkedList();
            
        }
    }
}
