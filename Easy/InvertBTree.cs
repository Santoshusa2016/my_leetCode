using leetCode.Daily;
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
}
