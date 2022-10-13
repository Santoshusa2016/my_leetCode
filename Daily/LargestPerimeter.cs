using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/largest-perimeter-triangle/submissions/
     * LeetCode: 976. Largest Perimeter Triangle
     * Date: 10/12/2022
     * Hashtag: #perimeter, #sort
     * Test case:[2 1 2], [1 2 1]
     * Failed:[3,6,2,3]
     * Hint: 0/1 Knapsack
     * Time Complexity:
     * Space Complexity:
     */
    internal class LargestPerimeter
    {
        int solve(int[] nums)
        {
            int perimeter = 0;
            if (nums.Length < 3)
                return perimeter;

            //step01: sort the array asc.
            Array.Sort(nums);

            //since array is sorted asc, the last value can be taken as c(base)
            for (int i = nums.Length - 1; i >=2; i--)
            {
                int c = nums[i];
                int b = nums[i - 1];
                int a = nums[i - 2];

                //Scalene triangle = a+b>c
                if (a + b > c)
                { 
                    perimeter = (a + b + c);
                    break;
                }
            }
            return perimeter;
        }

        public void Driver()
        {
            var inputVar = new int[] { 3, 6, 2, 3 };
            var retVal = solve(inputVar);
            Console.WriteLine("LargestPerimeter:{0}", retVal);

        }
    }
}
