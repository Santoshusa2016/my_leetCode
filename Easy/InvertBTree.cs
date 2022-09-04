using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Easy
{
    /*
    * Question: https://leetcode.com/problems/contains-duplicate/
    * Hint:swap each of the children node in recurssion using DFS
    * Test cases: 2:[1] -> [1], 3:[1,2] ->[1, null, 2]
    * Failed cases:
    * Explain:
    */
    internal class InvertBTree
    {
        public TreeNode Solution(TreeNode root)
        {
            //base case
            if (root == null)
                return root;

            var tempValue = root.left;
            root.left = root.right;
            root.right = tempValue;

            //explore child nodes
            Solution(root.left); 
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
