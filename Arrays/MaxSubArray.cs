using System;
using System.Collections.Generic;
using System.Text;

namespace my_leetCode.Arrays
{
    /*
    * Ref: https://leetcode.com/problems/maximum-subarray/ 
    * LeetCode: 128. Longest Consecutive Sequence
    * Tag: #array, #medium, #D&C, #dp, #quickSort
    * Date: 08/14/2022
    * Test case: [-2, 1, -3, 4, -1, 2, 1, -5, 4], [5,4,-1,7,8]
    * Failed cases: [8,-19,5,-4,20] ,[-2,3,0,2,-2,3]
    * Time Complexity: O(n), O(nlogn)
    * Space Complexity:O(1), O(n)
    */

    internal class MaxSubArray
    {
        public int GetMaxSubArray(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int currMax, maxValue;
            currMax = maxValue = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                //Determine max value in each iteration
                currMax = Math.Max((nums[i] + currMax), nums[i]);
                maxValue = currMax > maxValue ? currMax : maxValue;
            }
            return maxValue;
        }
        public int GetMaxSubArrayDC(int[] nums)
        {
            return doFindMax(0, (nums.Length - 1), nums);
        }

        public int doFindMax(int startIndex, int endIndex, int[] nums)
        {
            //base condition
            int retValue = 0;
            if (startIndex == endIndex)
                retValue = nums[startIndex];
            else if (startIndex < endIndex)
            {
                int median = (startIndex + endIndex) / 2;

                int a, b, c;
                a = doFindMax(startIndex, median, nums);
                b = doFindMax(median + 1, endIndex, nums);
                c = FindCrossMax(startIndex, median, endIndex, nums);
                retValue = Math.Max(Math.Max(a, b), c);
            }
            return retValue;
        }

        public int FindCrossMax(int startIndex, int median, int endIndex, int[] nums)
        {
            int leftMax = nums[median];
            int rightMax = nums[median + 1];

            int tempMax = leftMax;
            for (int i = (median - 1); i >= startIndex; i--)
            {
                /*You cannot apply kadens logic because Kadens use either current/ curr+prev for
                max. If current is taken then you are breaking the contiguos finding   
                */
                tempMax += nums[i];
                leftMax = (leftMax > tempMax) ? leftMax : tempMax;
            }

            tempMax = rightMax;
            for (int i = (median + 2); i <= endIndex; i++)
            {
                tempMax += nums[i];
                rightMax = (rightMax > tempMax) ? rightMax : tempMax;
            }
            return leftMax + rightMax;
        }
    }
}
