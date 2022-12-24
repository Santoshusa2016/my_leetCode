using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_leetCode.Dynammic
{
    internal class LongestIncreasingSeq
    {
        /*
        * Ref: https://leetcode.com/problems/longest-increasing-subsequence/
        * LeetCode: 300. Longest Increasing Subsequence
        * Tag: #dynamicProgram, #medium, #array
        * Date: 01/20/2022
        * Test case: [10,9,2,5,3,7,101,18]
        * Time Complexity: O(n^2)
        * Space Complexity:O(n)
        */
        public int LIS(int[] nums)
        {
            //Memoize 
            List<int> LIS = Enumerable.Repeat(1, nums.Length).ToList();

            for (int i = (nums.Length - 2); i >= 0; i--)
            {
                int j = (nums.Length - 1);
                int tempval = LIS[i];
                while (j > i)
                {
                    if (nums[j] > nums[i])
                    {
                        tempval = Math.Max(tempval, (LIS[i] + LIS[j]));
                    }
                    j--;
                }
                LIS[i] = tempval;
            }

            return LIS.Max(a => a);
        }
    }
}
