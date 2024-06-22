namespace _3Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LinkedList1.ReverseLinkedList();
            //LinkedList1.ReverseLinkedListRange();
            //LinkedList1.PalindromeLinkedList();
            //LinkedListMethods();

            //LinkedList1.RemoveDuplicatesFromSortedLinkedList();
            //LinkedList1.RemoveNthFromEnd();
            //LinkedList1.ReverseBNodesRecursive();
            //LinkedList1.LongestPalindromeLinkedList();


            //LinkedList2.MiddleElementofLinkedList();
            //LinkedList2.MergeTwoSortedLinkedLists();
            //LinkedList2.SortLinkedList();
            //LinkedList2.RemoveLoopFromLinkedList();
            //LinkedList2.AddTwoNumberofLists();

            //LinkedList2.ReorderLinkedList();

            //LinkedLIst3.IntersectionOfLinkedList();
            //LinkedLIst3.LRUCheck();
            //LinkedLIst3.PartitionListLessthanB();

            //Stack1.BalancedParanthesis();
            //Stack1.DoubleCharacterTrouble();
            //Stack1.PassingGame();
            //Stack1.InfixToPostfix();
            //Stack1.EvaluatePostfix();

            //Stack2.NearestSmallestElement();
            //Stack2.LargestRectangleInHistogram();
            //Stack2.NearestGreaterOnRight();
            //Stack2.MaxMinDifferenceSubArrays();

            //Queues.QueueUsingStack();
            //Queues.PerfectNumber();
            //Queues.NIntegersContainingOnly123();
            //Queues.ParkingIceCreamTruck();
            //Queues.ReverseBItemsInQueue();

            //Trees1.PreOrderTraversal();
            //Trees1.InOrderTraversal();
            //Trees1.BinaryTreeFromInOrderPostOrder();
            //Trees1.PostOrderTraversal();
            //Trees1.BinaryTreeFromPreOrderInOrder();

            //Trees2.LevelOrder();
            //Trees2.RightViewofBinaryTree();
            //Trees2.VerticalOrderTraversal();
            //Trees2.IsBalancedBinaryTree();

            //Trees2.TopViewOfBinaryTree();
            //Trees2.SerializeBinaryTree();
            //Trees2.DeserializeBinaryTree();
            Trees2.ZigZagLevelOrderBT();
        }

        static void LinkedListMethods()
        {
            //LinkedList1.insert_node(1, 23);
            //LinkedList1.print_ll();
            //LinkedList1.insert_node(2, 25);
            //LinkedList1.print_ll();
            //LinkedList1.insert_node(2, 24);
            //LinkedList1.insert_node(1, 20);
            //LinkedList1.print_ll();
            //LinkedList1.delete_node(4);
            //LinkedList1.print_ll();

            LinkedList1.insert_node(1, 226);
            LinkedList1.insert_node(2, 875);
            LinkedList1.insert_node(3, 604);
            LinkedList1.insert_node(4, 550);
            LinkedList1.insert_node(5, 498);
            LinkedList1.insert_node(6, 875);
            LinkedList1.insert_node(7, 847);
            LinkedList1.insert_node(8, 633);
            LinkedList1.insert_node(9, 793);
            LinkedList1.insert_node(10, 872);
            LinkedList1.insert_node(11, 313);
            LinkedList1.insert_node(12, 440);
            LinkedList1.insert_node(13, 331);
            LinkedList1.insert_node(14, 582);
            LinkedList1.insert_node(15, 188);
            LinkedList1.insert_node(16, 476);
            LinkedList1.insert_node(17, 722);
            LinkedList1.insert_node(18, 402);
            LinkedList1.insert_node(19, 890);
            LinkedList1.insert_node(20, 713);
            LinkedList1.insert_node(21, 421);
            LinkedList1.insert_node(22, 930);
            LinkedList1.insert_node(23, 579);
            LinkedList1.insert_node(24, 459);
            LinkedList1.insert_node(25, 278);
            LinkedList1.insert_node(26, 818);
            LinkedList1.insert_node(27, 320);
            LinkedList1.insert_node(28, 549);
            LinkedList1.insert_node(29, 240);
            LinkedList1.insert_node(30, 528);
            LinkedList1.insert_node(31, 367);
            LinkedList1.insert_node(32, 835);
            LinkedList1.insert_node(33, 20);
            LinkedList1.insert_node(34, 170);
            LinkedList1.insert_node(35, 903);
            LinkedList1.insert_node(36, 242);
            LinkedList1.insert_node(37, 943);
            LinkedList1.insert_node(38, 802);
            LinkedList1.insert_node(39, 145);
            LinkedList1.insert_node(40, 291);
            LinkedList1.insert_node(41, 224);
            LinkedList1.insert_node(42, 400);
            LinkedList1.insert_node(43, 43);
            LinkedList1.insert_node(44, 355);
            LinkedList1.insert_node(45, 83);
            LinkedList1.insert_node(46, 26);
            LinkedList1.insert_node(47, 816);
            LinkedList1.insert_node(48, 477);
            LinkedList1.insert_node(49, 425);
            LinkedList1.insert_node(50, 543);
            LinkedList1.insert_node(51, 211);
            LinkedList1.insert_node(52, 799);
            LinkedList1.insert_node(53, 185);
            LinkedList1.insert_node(54, 5);
            LinkedList1.insert_node(55, 184);
            LinkedList1.insert_node(56, 150);
            LinkedList1.insert_node(57, 572);
            LinkedList1.insert_node(58, 626);
            LinkedList1.insert_node(59, 109);
            LinkedList1.insert_node(60, 807);
            LinkedList1.delete_node(25);
            LinkedList1.print_ll();
            LinkedList1.delete_node(53);
            LinkedList1.print_ll();
            LinkedList1.delete_node(12);
            LinkedList1.delete_node(54);
            LinkedList1.print_ll();
            LinkedList1.print_ll();
            LinkedList1.print_ll();
            LinkedList1.print_ll();
            LinkedList1.print_ll();
            LinkedList1.delete_node(39);
            LinkedList1.delete_node(42);
            LinkedList1.print_ll();
            LinkedList1.delete_node(47);
            LinkedList1.delete_node(45);
            LinkedList1.delete_node(35);
            LinkedList1.print_ll();
            LinkedList1.delete_node(13);
            LinkedList1.print_ll();
            LinkedList1.delete_node(18);
            LinkedList1.delete_node(59);
            LinkedList1.delete_node(47);
            LinkedList1.delete_node(43);
            LinkedList1.delete_node(38);
            LinkedList1.print_ll();
            LinkedList1.print_ll();
            LinkedList1.print_ll();
            LinkedList1.print_ll();
            LinkedList1.print_ll();
            LinkedList1.print_ll();
            LinkedList1.delete_node(8);
            LinkedList1.print_ll();
            LinkedList1.delete_node(8);
            LinkedList1.print_ll();
            LinkedList1.delete_node(39);
            LinkedList1.delete_node(60);
            LinkedList1.delete_node(16);
            LinkedList1.print_ll();
            LinkedList1.print_ll();

        }
    }

}
