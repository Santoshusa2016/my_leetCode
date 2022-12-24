using System;
using System.Collections.Generic;
using System.Text;

namespace my_leetCode.Arrays
{
    /*
    * Ref: https://leetcode.com/problems/longest-consecutive-sequence/
    * LeetCode: 128. Longest Consecutive Sequence
    * Tag: #array, #medium, #prefix, #suffix
    * Date: 10/29/2022
    * Test case: [1,2,3,4]
    * Time Complexity: O(n)
    * Space Complexity: O(n)
    */
    public class ProductExceptSelf
    {
        public int[] GetProductExceptSelf(int[] nums)
        {
            int[] outputArray = new int[nums.Length];
            outputArray[0] = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                //Prefix-Product till index i     
                outputArray[i] = outputArray[i - 1] * nums[i - 1];
            }

            int tempMultiplier = 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                //Suffix Product till the index i, multiplied with prefix determined in earlier loop
                tempMultiplier = tempMultiplier * nums[i + 1];
                outputArray[i] = outputArray[i] * (tempMultiplier);

            }
            return outputArray;
        }

        private void PrefixProduct(int[] nums)
        {
            int[] outputArray = new int[nums.Length];
            outputArray[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                outputArray[i] = outputArray[i - 1] * nums[i];
            }
        }

        private void SuffixProduct(int[] nums)
        {
            int[] outputArray = new int[nums.Length];
            outputArray[nums.Length - 1] = nums[nums.Length - 1];
            for (int i = (nums.Length - 2); i >= 0; i--)
            {
                outputArray[i] = outputArray[i + 1] * nums[i];
            }
        }

    }
}
