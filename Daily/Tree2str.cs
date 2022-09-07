using leetCode.Easy;
using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/construct-string-from-binary-tree/
     * LeetCode: 606
     * hint: left subtree - grouped, right subtree - grouped using paranthesis
     * Date: 09/07/2022
     * Test case:
     * Time Complexity:
     * Space Complexity:
     */
    internal class Tree2str
    {
        public string Solve(TreeNode root)
        {
            string output = "";
            if (root == null)
                return output;

            //step 01: get value
            output = root.val.ToString();
            
            //step 02: if left node exist explore else add () when only right node exist
            if (root.left != null)
                output += "(" + Solve(root.left) + ")";
            else if (root.right != null)
                output += "()";

            //step 03: explore right node if exist
            if(root.right != null)
                output += "(" + Solve(root.right) + ")";

            return output;
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
}
