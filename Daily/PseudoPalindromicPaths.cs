using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/pseudo-palindromic-paths-in-a-binary-tree/
     * LeetCode: 1457
     * Date: 09/14/2022
     * Test case:
     * Time Complexity:
     * Space Complexity:
     */
    internal class PseudoPalindromicPaths
    {
        //failure in logic building
        int Solve(TreeNode root, Dictionary<int, int> nodeValues)
        {
            int retVal = 0;

            if(nodeValues.ContainsKey(root.val)){
                nodeValues[root.val]++;
            }
            else
                nodeValues.Add(root.val, 1);

            if(root.left == null && root.right == null)
            {
                retVal = CheckPalindrome(nodeValues);
            }
            else
            {
                int leftVal = root.left != null ? Solve(root.left, nodeValues): 0;
                int rightVal = root.right != null ? Solve(root.right, nodeValues): 0;
                retVal = leftVal + rightVal;
            }
            nodeValues[root.val] -= 1;
            return retVal;
        }

        public void Driver()
        {
            var inputReq = new TreeNode(
                2
                , new TreeNode(3, new TreeNode(3, null, null), new TreeNode(1, null, null))
                , new TreeNode(1, null, new TreeNode(1, null, null))
                );

            int retVal = Solve(inputReq, new Dictionary<int, int>());
        }

        private int CheckPalindrome(Dictionary<int, int> dict)
        {
            //only one element can have value 1
            int countOddNos = dict.Count(a => (a.Value % 2 > 0));
            if (countOddNos > 1)
                return 0;
            else
                return 1;
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
