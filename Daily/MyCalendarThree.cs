using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Daily
{

    /*
     * Ref: https://leetcode.com/problems/my-calendar-iii/
     * LeetCode: 732. My Calendar III
     * Date: 10/07/2022
     * Test case:
     * Failed:
     * Time Complexity:
     * Space Complexity:
     */

    //
    public class MyCalendarThree
    {
        public List<int> showStartTimes { get; set; }
        public List<int> showEndTimes { get; set; }


        public MyCalendarThree()
        {
            showStartTimes = new List<int>();
            showEndTimes = new List<int>();
        }

        public int Book(int start, int end)
        {
            showStartTimes.Add(start);
            showEndTimes.Add(end);

            //sort ascending
            showStartTimes.Sort();
            showEndTimes.Sort();


            int showsCount = showStartTimes.Count;
            int earliestShowEndTimeIndex = 0;
            int overlapping = 1;
            for (int i = 1; i < showsCount; i++)
            {
                if (showStartTimes[i] < showEndTimes[earliestShowEndTimeIndex])
                {
                    overlapping++;
                }
                else
                {
                    earliestShowEndTimeIndex++;
                }
            }


            return overlapping;
        }


        public void Driver()
        {
            var inputArg = new int[,] {
            {10, 20 },
            {50, 60 },
            {10, 40 },
            {5, 15 },
            {5, 10 },
            {25, 55 }
            };

            for (int i = 0; i < inputArg.GetLength(0); i++)
            {
                Book(inputArg[i, 0], inputArg[i, 1]);
            }
        }
    }
}
