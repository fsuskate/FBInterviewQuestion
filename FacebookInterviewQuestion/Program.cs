using System;

// 
// Find the smallest number greater than the passed in target
// i.e.
//     
//     2
//   /   \
//  0     3
// 
// Target == 1
// 
// Smallest number greater than 1 is 2
// 
//
namespace FacebookInterviewQuestion
{
    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val)
        {
            this.val = val;
            left = right = null;
        }
    }

    class BSTHelper
    {
        public int findSmallest(TreeNode node, int target)
        {
            var currentNode = node;
            var previousNode = node;
            while (currentNode != null)
            {
                if (currentNode.val > target)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.left;
                }
                else
                {
                    return previousNode.val;
                }
            }

            return -1;
        }

        public int findSmallestR(TreeNode node, int target)
        {
            if (node == null)
            {
                return -1;
            }

            if (node.val == target)
            {
                return -1;
            }

            if (node.val > target)
            {
                var value = findSmallestR(node.left, target);
                if (value == -1)
                {
                    return node.val;
                }
                else
                {
                    return value;
                }
            }

            return -1;
        }
    }

    class Solution
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(10);
            root.left = new TreeNode(7);
            root.left.left = new TreeNode(2);
            root.left.right = new TreeNode(3);

            root.right = new TreeNode(15);
            root.right.left = new TreeNode(14);
            root.right.right = new TreeNode(20);

            var bst = new BSTHelper();
            Console.WriteLine(bst.findSmallestR(root, 4)); // answer is 7
        }
    }
}
