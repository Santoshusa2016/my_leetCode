using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/maximum-bags-with-full-capacity-of-rocks/description/
    * LeetCode:2279. Maximum Bags With Full Capacity of Rocks
    * Tag: #medium, #greedy, #sort
    * Company:
    * Date: 12/27/2022
    * Time Complexity: 0(N)
    * Space Complexity:O(N)
    */

    internal class MaximumBags
    {
        public int solve(int[] capacity, int[] rocks, int additionalRocks)
        {
            int countMax = 0;
            int i = 0;
            int[] remainingCapacity = new int[rocks.Count()];

            for (i = 0; i < capacity.Length; i++)
            {
                remainingCapacity[i] = (capacity[i] - rocks[i]);
            }
            i = 0;

            remainingCapacity = remainingCapacity.OrderBy(a => a).ToArray();
            while (additionalRocks>0 && i< capacity.Length)
            {
                int diff = remainingCapacity[i] - additionalRocks;
                additionalRocks -= remainingCapacity[i];
                remainingCapacity[i] = diff<=0 ?0: diff;
                if (remainingCapacity[i] == 0) countMax++;                
                i++;
            }

            return countMax;
        }
        public void Driver()
        {
            int retVal = solve(new int[] { 10, 2, 2 }, new int[] { 2, 2, 0 }, 100);
            Console.WriteLine($"MaximumBags:{retVal}");
        }
    }
}
