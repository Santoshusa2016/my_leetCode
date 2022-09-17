using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/maximum-score-from-performing-multiplication-operations/submissions/
     * LeetCode: 1770. Maximum Score from Performing Multiplication Operations
     * Date: 09/12/2022
     * Test case:[1,2,3]:[3,2,1], [-5,-3,-3,-2,7,1]:[-10,-5,3,4,6]
     * Failed:
     * Hint: 0/1 Knapsack
     * Time Complexity:
     * Space Complexity:
     */
    internal class MaximumScore
    {
        int topDown(int[] nums, int[] multipliers)
        {
            int m = multipliers.Length;
            //because we can explore at max m elements with base case 0, hence m+1
            int?[,] dp = new int?[m, m];

            return Backtracking(0, nums.Length - 1, 0);

            int Backtracking(int left, int right, int index)
            {
                //base condition
                if (index == m) return 0;


                //explore each node and store max in dp & return
                return dp[left, index] ??= Math.Max(
                    nums[left] * multipliers[index] + Backtracking(left + 1, right, index + 1),
                    nums[right] * multipliers[index] + Backtracking(left,right-1, index + 1)
                );
            }            
        }

        public int bottomUp(int[] nums, int[] multipliers)
        {
            int m = multipliers.Length;
            int[,] dp = new int[m + 1, m + 1];

            for (int index = m - 1; index >= 0; index--)
            {
                for (int left = index; left >= 0; left--)
                {
                    int right = nums.Length - 1 - index + left;
                    dp[index, left] = Math.Max(
                        nums[left] * multipliers[index] + dp[index + 1, left + 1],
                        nums[right] * multipliers[index] + dp[index + 1, left]
                    );
                }
            }

            return dp[0, 0];
        }


        public void Driver()
        {
            int[] num = { -5, -3, -3, -2, 7, 1 };
            int[] multiplier = { -10, -5, 3, 4, 6 };
            topDown(num, multiplier);
        }
    }
}
