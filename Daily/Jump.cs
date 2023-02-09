using System;
using System.Collections.Generic;
using System.Text;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/jump-game-ii/description/
    * LeetCode:45. Jump Game II
    * Tag: #medium, #maths, #slope
    * Company:
    * Date: 02/08/2023
    * Time Complexity: 0(N)
    * Space Complexity:O(1)
    */

    internal class Jump
    {
        public int solve(int[] nums)
        {
            int jumps = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] = Math.Max(nums[i - 1], nums[i]+i);
            }

            int step = 0;
            while (step < nums.Length-1)
            {
                jumps++;
                step = nums[step];
            }

            return jumps;
        }
        public void Driver()
        {
            int retVal = solve(new int[]{ 2,3,1,1,4});
            Console.WriteLine($"Jump:{retVal}");
        }
    }
}
