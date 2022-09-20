using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Daily
{
    internal class FindLength
    {
        /*
         * Ref: https://leetcode.com/problems/maximum-length-of-repeated-subarray/
         * LeetCode: 718. Maximum Length of Repeated Subarray
         * Date: 09/19/2022
         * Test case:[1,2,3,2,1] [3,2,1,4,7]; [0,0,0,0,0] [0,0,0,0,0]
         * Time Complexity:
         * Space Complexity:
         */
        int solve(int[] nums1, int[] nums2)
        {
            int[,] matrix = new int[nums1.Length+1, nums2.Length+1];
            int maxValue = 0;

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (nums1[i-1] == nums2[j-1])
                    {
                        matrix[i, j] = 1 + matrix[i - 1, j - 1];
                        maxValue = Math.Max(maxValue, matrix[i, j]);
                    }
                }
            }
            return maxValue;
        }

        int solveSlidingWindow(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;
            int maxCount = 0;



            return maxCount;
        }


        public void Driver()
        {
            int retVal = solveSlidingWindow(new int[] { 69, 51, 94, 52, 72, 74, 65, 65, 99, 1 },
                new int[] { 65, 99, 82, 27, 43, 95, 9, 20, 13, 99 });

            Console.WriteLine("FindLength:{0}", retVal);
        }
    }
}
