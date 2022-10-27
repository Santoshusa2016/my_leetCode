using System;
using System.Collections.Generic;
using System.Text;

namespace my_leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/continuous-subarray-sum/
     * LeetCode: 523. Continuous Subarray Sum
     * Date: 10/26/2022
     * hash: #medium,
     * Company: microsoft
     * Test case:
     * Time Complexity:
     * Space Complexity:
     */

    internal class CheckSubarraySum
    {
        /// <summary>
        /// TimeComplexity: O(n^2)
        /// </summary>
        bool solve(int[] nums, int k)
        {
            int[] auxNums = new int[nums.Length];
            //Array.Fill(auxNums, -1);
            auxNums[0] = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                int index = i - 1;
                auxNums[i] = nums[i];

                while (index >= 0)
                {
                    auxNums[index] = auxNums[index] + nums[i];
                    if ((auxNums[index] % k) == 0)
                        return true;
                    index--;
                }
            }
            return false;
        }

        /// <summary>
        /// TimeComplexity: O(n^2)
        /// </summary>
        bool solveDP(int[] nums, int k)
        {
            int[,] matrix = new int[nums.Length, nums.Length];

            for (int i = 0; i < nums.Length - 1; i++)
            {
                int baseValue = nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    matrix[i, j] = baseValue + nums[j];
                    baseValue = matrix[i, j];
                    if (baseValue % k == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        bool solveV3(int[] nums, int k)
        {
            int reminder = 0;
            int runningTotal = 0;
            Dictionary<int, int> dictRemIndex = new Dictionary<int, int>();

            //we add this element to bypass the return if the first element in array is divisible by k. The   is atleast 2 elements
            dictRemIndex.Add(0, -1);

            for (int i = 0; i < nums.Length; i++)
            {
                runningTotal += nums[i];
                reminder = (runningTotal % k);
                if (dictRemIndex.ContainsKey(reminder))
                {
                    //when we get same reminder, it means enough
                    //number has been added to runningTotal making it divisible by k 
                    if (i - dictRemIndex[reminder] > 1)
                        return true;
                }
                else
                    dictRemIndex.Add(reminder, i);
            }

            return false;
        }

        public void Driver()
        {
            int[] inputVal = { 23, 2, 4, 6, 6 };
            bool retVal = solveV3(inputVal, 7);
            Console.WriteLine("CheckSubarraySum");
        }
    }
}
