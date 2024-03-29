﻿using System;
using System.Collections.Generic;
using System.Text;

namespace my_leetCode.Arrays
{
    /*
    * Ref: https://leetcode.com/problems/maximum-product-subarray/
    * LeetCode: 152. Maximum Product Subarray
    * Tag: #array, #medium, #dp
    * Date: 09/21/2022
    * Test case: [2,3,-2,4], [2,0,-1,8]
    * Failed cases: [3,-1,4]
    * Time Complexity: O(n)
    * Space Complexity:O(1)
    */

    internal class MaxProdArray
    {
        public int GetMaxProduct(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int min = nums[0], max = nums[0], res = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                //from 3 values below, choose min/max
                int product1 = nums[i] * min;
                int product2 = nums[i] * max;
                int product3 = nums[i];

                max = Math.Max(Math.Max(product1, product2), product3);
                min = Math.Min(Math.Min(product1, product2), product3);

                res = Math.Max(res, max);
            }
            return res;
        }
    }
}
