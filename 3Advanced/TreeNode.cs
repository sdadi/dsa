using System.Text;
using System.Transactions;

namespace _3Advanced
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
            left = null;
            right = null;
        }
    }

    public static class TreeNodeExtension
    {
        public static TreeNode ListToTree<T>(this List<int> input)
        {
            if (input == null)
                return null;
            var root = new TreeNode(input[0]);
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int i = 1;

            while (queue.Count > 0 && i < input.Count)
            {
                var current = queue.Dequeue();
                if (i < input.Count && input[i] != -1)
                {
                    current.left = new TreeNode(input[i]);
                    queue.Enqueue(current.left);
                }
                i += 1;
                if (i < input.Count && input[i] != -1)
                {
                    current.right = new TreeNode(input[i]);
                    queue.Enqueue(current.right);
                }
                i += 1;
            }


            return root;
        }
        public static string TreeToLevelOrderString(this TreeNode root)
        {
            var result = new StringBuilder();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                var current = queue.Dequeue();
                int val = current == null ? -1 : current.val;
                result.Append($"{val}, ");
                if(current != null)
                {
                    queue.Enqueue(current.left);
                    queue.Enqueue(current.right);
                }
            }
            return result.ToString().TrimEnd();
        }
    }
}
