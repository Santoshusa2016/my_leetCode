using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/binary-tree-pruning/submissions/
     * LeetCode: 814
     * hint: 
     * Date: 09/06/2022
     * Test case:
     * Time Complexity:
     * Space Complexity:
     */
    internal class PruneTree
    {
        public TreeNode Solve(TreeNode root)
        {
            //base case
            if (root == null)
                return null;

            //Decision
            var leftNode = Solve(root.left);
            var rightNode = Solve(root.right);
            if (leftNode == null && rightNode == null)
            {
                if (root.val <= 0)
                    return null;
            }
            root.left = leftNode;
            root.right = rightNode;
            return root;

        }


        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public void Driver()
        {
            TreeNode root = new TreeNode(1,null,
                new TreeNode(0, new TreeNode(0), new TreeNode(1)));
            var nums = Solve(root);
        }
    }
}
