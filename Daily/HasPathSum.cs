using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Daily
{
    internal class HasPathSum
    {
        /*
         * Ref: https://leetcode.com/problems/path-sum/submissions/
         * LeetCode: 112. Path Sum 
         * Date: 10/05/2022
         * Test case:
         * Failed:[1,-2,-3,1,3,-2,null,-1]-1,[1,2]1,[]0
         * Time Complexity:
         * Space Complexity:
         */
        void solve(TreeNode root, int targetSum)
        {
            var resp = hasPathWithSum(root, 0 , targetSum);
        }

        bool hasPathWithSum(TreeNode node, int runningSum, int targetSum)
        {
            //base (or) exit case
            //we should not check runningsum here, because given node can be null but alternate in cases had value, which is incorrect
            if (node == null)
            {
                return false;
            }

            //decision tree. should not return false in else because leaf node could have -ve vals
            if (runningSum + node.val == targetSum && (node.left == null && node.right == null))
                 return true; 

            bool hasPathLeft = hasPathWithSum(node.left, runningSum + node.val, targetSum);
            bool hasPathRight = hasPathWithSum(node.right, runningSum + node.val, targetSum);


            return hasPathRight | hasPathLeft;
        }

        public void Driver()
        {
            var inputVal = new TreeNode(5,
                new TreeNode(4, new TreeNode(11, new TreeNode(7), new TreeNode(2)), null),
                new TreeNode(8, new TreeNode(13, null, null), new TreeNode(4, null, new TreeNode(1)))
                );

            solve(inputVal, 22);
            Console.WriteLine("HasPathSum");

        }
    }
}
