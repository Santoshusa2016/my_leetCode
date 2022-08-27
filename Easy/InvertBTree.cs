using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Easy
{
    internal class InvertBTree
    {
        /*
        * Hint: swap each of the children node in recurssion using DFS
        * 2:[1] -> [1], 3:[1,2] ->[1, null, 2]
        */
        public TreeNode Solution(TreeNode root)
        {
            //base case
            //if (root == null || root.left == null || root.right == null)//3 
            if (root == null)
                return root;//2

            var tempValue = root.left;
            root.left = root.right;
            root.right = tempValue;
            Solution(root.left); //explore child nodes
            Solution(root.right);

            return root;
        }
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
}
