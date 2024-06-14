using Helpers;

namespace _3Advanced
{
    internal class Queues
    {
        /// <summary>
        /// Implement a First In First Out (FIFO) queue using stacks only.
        /// The implemented queue should support all the functions of a normal queue(push, peek, pop, and empty).
        /// Implement the UserQueue class:
        /// void push(int X) : Pushes element X to the back of the queue.
        /// int pop() : Removes the element from the front of the queue and returns it.
        /// int peek() : Returns the element at the front of the queue.
        /// boolean empty() : Returns true if the queue is empty, false otherwise.
        /// NOTES:
        /// You must use only standard operations of a stack, which means only push to top, peek/pop from top, size, and is empty operations are valid.
        /// Depending on your language, the stack may not be supported natively.You may simulate a stack using a list or deque(double-ended queue) as long as you use only a stack's standard operations.
        /// Problem Constraints
        /// 1 <= X <= 10^9
        /// At most 1000 calls will be made to push, pop, peek, and empty function.
        /// All the calls to pop and peek are valid. i.e.pop and peek are called only when the queue is non-empty.
        /// </summary>
        public static void QueueUsingStack()
        {
            QueueWithStack queue = new QueueWithStack();
            queue.Push(20);
            Console.WriteLine(queue.Empty());//false
            Console.WriteLine(queue.Peek());//20
            Console.WriteLine(queue.Pop());//20
            Console.WriteLine(queue.Empty());//true
            queue.Push(30);
            Console.WriteLine(queue.Peek());//30
            queue.Push(40);
            Console.WriteLine(queue.Peek());//30
        }

        /// <summary>
        /// Given an integer A, you have to find the Ath Perfect Number.
        /// A Perfect Number has the following properties:
        /// It comprises only 1 and 2.
        /// The number of digits in a Perfect number is even.
        /// It is a palindrome number.
        /// For example, 11, 22, 112211 are Perfect numbers, where 123, 121, 782, 1 are not.
        /// Problem Constraints
        /// 1 <= A <= 100000
        /// </summary>
        public static void PerfectNumber()
        {
            int A = 2;
            //A = 3;

            var result = new List<string>();
            var queue = new Queue<string>();
            queue.Enqueue("1");
            queue.Enqueue("2");

            int i = 0;
            while (i < A)
            {
                string front = queue.Dequeue();
                result.Add(front);
                i++;

                queue.Enqueue(front+"1");
                queue.Enqueue(front+"2");
            }

            string temp = result[A - 1];
            var t = string.Join("",temp.ToString().Reverse());

            Console.WriteLine(temp+temp.Reverse());
        }

        /// <summary>
        /// Given an integer, A. Find and Return first positive A integers in ascending order containing only digits 1, 2, and 3.
        /// NOTE: All the A integers will fit in 32-bit integers.
        /// Problem Constraints
        /// 1 <= A <= 29500
        /// </summary>
        public static void NIntegersContainingOnly123()
        {
            int A = 7;

            var result = new List<int>();
            var queue = new Queue<string>();

            queue.Enqueue("1");
            queue.Enqueue("2");
            queue.Enqueue("3");
            int i = 0;
            while(i < A)
            {
                string front = queue.Dequeue();
                result.Add(Convert.ToInt32(front));

                queue.Enqueue(front + "1");
                queue.Enqueue(front + "2");
                queue.Enqueue(front + "3");
                i++;
            }

            result.PrintArray();
        }

        /// <summary>
        /// Imagine you're an ice cream truck driver in a beachside town. 
        /// The beach is divided into several sections, 
        /// and each section has varying numbers of beachgoers wanting ice cream given by the array of integers A.
        /// For simplicity, let's say the beach is divided into 8 sections. 
        /// One day, you note down the number of potential customers in each section: [5, 12, 3, 4, 8, 10, 2, 7]. 
        /// This means there are 5 people in the first section, 12 in the second, and so on.
        /// You can only stop your truck in B consecutive sections at a time because of parking restrictions.
        /// To maximize sales, you want to park where the most customers are clustered together.
        /// For all B consecutive sections, identify the busiest stretch to park your ice cream truck and 
        ///         serve the most customers.Return an array C, where C[i] is the busiest section in each of the B consecutive sections. 
        ///         Refer to the given example for clarity.
        /// NOTE: If B > length of the array, return 1 element with the max of the array.
        /// Problem Constraints
        /// 1 <= |A|, B <= 10^6
        /// </summary>
        public static void ParkingIceCreamTruck()
        {
            List<int> A = [1, 3, -1, -3, 5, 3, 6, 7];
            int B = 3; // [3, 3, 5, 5, 6, 7]

            A = [1, 2, 3, 4, 2, 7, 1, 3, 6];
            B = 6; //[7, 7, 7, 7]

            A = [1];
            B = 1;

            var result = new List<int>();
            var queue = new QueueWithDoubleLinkedList();


            for(int i = 0; i < B; i++)
            {
                while(!queue.IsEmpty() && A[queue.PeekRear()] < A[i])
                {
                    queue.DequeueRear();
                }
                queue.EnqueueRear(i);
            }
            result.Add(A[queue.PeekFront()]);

            for (int i = B; i < A.Count; i++)
            {
                while (!queue.IsEmpty() && A[queue.PeekRear()] < A[i])
                {
                    queue.DequeueRear();
                }
                queue.EnqueueRear(i);

                if(queue.PeekFront() == i - B)
                {
                    queue.DequeueFront();
                }
                result.Add(A[queue.PeekFront()]);
            }

            result.PrintArray();

        }
        /// <summary>
        /// Given an array of integers A and an integer B, we need to reverse the order of the first B elements of the array, 
        /// leaving the other elements in the same relative order.
        /// NOTE: You are required to the first insert elements into an auxiliary queue then perform Reversal of first B elements.
        /// Problem Constraints
        /// 1 <= B <= length of the array <= 500000
        /// 1 <= A[i] <= 100000
        /// </summary>
        public static void ReverseBItemsInQueue()
        {
            List<int> A = [1, 2, 3, 4, 5];
            int B = 3;//[3, 2, 1, 4, 5]

            //A = [5, 17, 100, 11];
            //B = 2;//[17, 5, 100, 11]
            A = [1];
            B = 1;

            var queue = new Queue<int>();
            for(int i=0; i < B; i++)
            {
                queue.Enqueue(A[i]);   
            }
            for(int i=B-1;i >= 0; i--)
            {
                A[i] = queue.Dequeue();
            }
            A.PrintArray();
        }
    }
}
