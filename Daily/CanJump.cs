using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/jump-game/description/
    * LeetCode:55. Jump Game
    * Tag: #medium, #dp
    * Company:
    * Date: 12/24/2022
    * Time Complexity: 0(N)
    * Space Complexity:O(1)
    */

    internal class CanJump
    {
        public bool doJump(int[] nums)
        {
            int[] memResult = Enumerable.Repeat(-1, nums.Length).ToArray();
            return doJump(nums, memResult, 0);
        }

        public bool doJump(int[] nums, int[] results, int index)
        {
            //base condition: stop processing when index > len
            if (index >= nums.Length - 1)
              return true;
            
            if (results[index] != -1)
                return Convert.ToBoolean(results[index]);

            int steps = nums[index];
            int tempIndex = index;
            bool canJump = false;
            while (steps > 0)
            {
                canJump = doJump(nums, results, ++tempIndex);
                if (canJump)
                {
                    results[index] = Convert.ToInt32(canJump);
                    break;
                }
                steps--;
            }
            
            return canJump;
        }
        public bool doJump_DP(int[] nums)
        {
            int len = nums.Length - 1;
            int targetIndex = len;

            for (int i = len-1; i >=0; i--)
            {
                if (i + nums[i] >= targetIndex)
                    targetIndex = i;
            }
            if (targetIndex != 0)
                return false;
            else
                return true;
        }

        public void Driver()
        {
            bool retVal = doJump_DP(new int[] { 2, 3, 1, 1, 4 });
            Console.WriteLine($"CanJump:{retVal}");
        }
    }
}
