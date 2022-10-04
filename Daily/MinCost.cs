using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/minimum-time-to-make-rope-colorful/
     * LeetCode: 1578. Minimum Time to Make Rope Colorful
     * Date: 10/03/2022
     * Test case: abaac,[1,2,3,4,5]
     * Failed:
     * Time Complexity:
     * Space Complexity:
     */
    internal class MinCost
    {
        int solve(string colors, int[] neededTime)
        {

            //base case
            if (colors.Length != neededTime.Length)
                return 0;


            int prevIndex, currentIndex, totalMinCost, n;
            prevIndex = currentIndex = totalMinCost = 0;
            n = colors.Length;

            //step01: create 2 pointer current/ prev for determining the group of similar items
            while (prevIndex<n && currentIndex<n)
            {
                int tempMax, tempTotal;
                tempMax = tempTotal = 0;
                while (currentIndex < n && colors[currentIndex] == colors[prevIndex])
                {
                    //step02: if consecutive items are equal, add values and keep track of largest element 
                    tempMax = Math.Max(tempMax, neededTime[currentIndex]);
                    tempTotal += neededTime[currentIndex];
                    currentIndex++;
                }

                //step03: keep the max item, and remove all min items.
                totalMinCost += (tempTotal - tempMax); //cases where consec element are not equal, both temp will be equal
                prevIndex = currentIndex;
            }

            return totalMinCost;
        }

        public void Driver()
        {
            var retVal = solve("brbrrr", new int[] { 1, 2, 3, 7, 8, 6 });
            Console.WriteLine("MinCost");
        }
    }
}
