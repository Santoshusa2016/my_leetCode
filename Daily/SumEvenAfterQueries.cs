using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/sum-of-even-numbers-after-queries/submissions/
     * LeetCode: 985. Sum of Even Numbers After Queries
     * Date: 09/21/2022
     * Test case:
     * Failed:
     * Time Complexity:
     * Space Complexity:
     */

    internal class SumEvenAfterQueries
    {
        int[] solve(int[] nums, int[][] queries)
        {
            int[] sumArray = new int[nums.Length];
            //step01: first save sum of existing even nums
            int evenSum = nums.Sum(a => a % 2 == 0 ? a : 0);

            //step02: iterate queries array & based on index update value in nums
            for (int i = 0; i < queries.GetLength(0); i++)
            {
                int val = queries[i][0];
                int index = queries[i][1];

                //step03: check if original num was part of sum, if yes remove it.
                if (nums[index] % 2 == 0)
                {
                    evenSum -= nums[index];
                }

                nums[index] = nums[index] + val;
                //step04: if new sum is even add it to sum.
                if (nums[index] % 2 == 0)
                {
                    evenSum += nums[index];
                }
                sumArray[i] = evenSum;
            }

            return sumArray;
        }
        public void Driver()
        {
            var retval = solve(new int[] { 1, 2, 3, 4 },
                new int[4][]
                {
                    new int[]{1,0 },
                    new int[]{-3,1 },
                    new int[]{-4,0 },
                    new int[]{2,3 },
                });
            Console.WriteLine("SumEvenAfterQueries:{0}", retval.Length);
        }
    }
}
