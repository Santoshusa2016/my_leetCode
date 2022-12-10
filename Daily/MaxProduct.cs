
using System;
using System.Text;
using System.Collections.Generic;
using leetCode.Daily;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/maximum-product-of-splitted-binary-tree
    * LeetCode:1339. Maximum Product of Splitted Binary Tree
    * Tag: #medium, #bfs, #dfs
    * Company:
    * Date: 12/10/2022
    * Time Complexity: 0(N)
    * Space Complexity:O(N)
    */


    internal class MaxProduct
    {
        private long _maxSum = 0;
        private int _totalSum = 0;
        private const long mod = 1000000007;
        HashSet<int> hashSet = new HashSet<int>();

        #region approach-01
        int solve(TreeNode root)
        {
            //step01: Find sum of all nodes
            _totalSum = sum(root);

            //step02: Find MaxProduct
            findMax(root);
            
            return (int)(_maxSum%mod);
        }

        long findMax(TreeNode root)
        {
            //base case:
            if (root == null)
                return 0;

            long leftSum=0, rightSum = 0, nodeSum = 0;

            //Decision tree using DFS to find node value to subtract and multiply
            if (root.left != null)
                leftSum = findMax(root.left);

            if (root.right != null)
                rightSum = findMax(root.right);

            nodeSum = root.val + leftSum + rightSum;
            _maxSum = Math.Max(_maxSum, (nodeSum * (_totalSum - nodeSum)));

            return nodeSum;
        }

        int sum(TreeNode root)
        {
            int sum = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var tempNode = queue.Dequeue();
                sum += tempNode.val;
                if (tempNode.left != null)
                    queue.Enqueue(tempNode.left);
                if (tempNode.right != null)
                    queue.Enqueue(tempNode.right);
            }

            return sum;
        }
        #endregion

        #region approach-02
        public int solveV2(TreeNode root)
        {
            var sum = TreeSum(root);
            long max = 0;
            foreach (var num in hashSet)
                max = Math.Max(max, 
                    (long)(sum - num) * (long)num);
            return (int)(max % 1_000_000_007);
        }

        private int TreeSum(TreeNode root)
        {
            if (root == null) return 0;
            var sum = root.val + TreeSum(root.left) + TreeSum(root.right);
            hashSet.Add(sum);
            return sum;
        }

        #endregion

        public void Driver()
        {
            var inputReq = new TreeNode(
                1
                , new TreeNode(2, new TreeNode(4, null, null), new TreeNode(5, null, null))
                , new TreeNode(3, new TreeNode(6, null, null), null)
                );
            var retVal = solve(inputReq);

            Console.WriteLine($"MaxProduct:{retVal}");
        }
    }
}
