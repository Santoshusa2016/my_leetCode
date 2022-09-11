using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/the-number-of-weak-characters-in-the-game/
     * LeetCode: 1996
     * hint: sort array by attack asc , def desc and then determine if anyone is vulnerable
     * Date: 09/09/2022
     * Test case:
     * Failed: [[1,5],[10,4],[4,3]], [[7,7],[1,2],[9,7],[7,3],[3,10],[9,8],[8,10],[4,3],[1,5],[1,5]]
     * Time Complexity:
     * Space Complexity:
     */
    internal class NumberOfWeakCharacters
    {
        public int SolveV2(int[][] properties)
        {
            int counter = 0;
            /*step 01: sort array by attack asc, def desc
             *the reason for sorting def desc is in each index we compare current to prev.
             *if prev is sorted asc then there are chances that lesser value might show up in prev index
             */
            var sortedProps = properties.OrderBy(a => a[0]).ThenByDescending(a => a[1]).ToArray();

            //step 02: start from last index, since array is sorted by attack asc
            int maxDefValue = Int32.MinValue;
            for (int i = sortedProps.Length-1; i >= 0; i--)
            {
                //step 03: to bypass 1 loop
                if (sortedProps[i][1] < maxDefValue)
                    counter++;

                //step 04: identity elements whose defence value is less than curr max. Those items are vulnerable
                if (sortedProps[i][1] > maxDefValue)
                    maxDefValue = sortedProps[i][1];

            }

            return counter;
        }

        public int SolveV1(int[][] properties)
        {
            //the below code failed due to timelimit exceed. INference sorting is better than multiple looping
            HashSet<int> weakChars = new HashSet<int>();

            for (int i = 0; i < properties.Length-1; i++)
            {
                int attackScore = properties[i][0];
                int defenceScore = properties[i][1];

                for (int j = i+1; j < properties.Length; j++)
                {
                    if (attackScore < properties[j][0]
                        && defenceScore < properties[j][1])
                    {
                        weakChars.Add(i);
                    } 
                    else if (attackScore > properties[j][0]
                        && defenceScore > properties[j][1])
                    {
                        weakChars.Add(j);
                    }
                }
            }

            return weakChars.Count;
        }

        public void Driver()
        {
            //jagged array
            int[][] input = new int[][]{
                                new int[]{7,7},
                                new int[]{1,2},
                                new int[]{9,7},
                                new int[]{7,3},
                                new int[]{3,10},
                                new int[]{9,8},
                                new int[]{8,10},
                                new int[]{4,3},
                                new int[]{1,5},
                                new int[]{1,5}
                            };

            SolveV2(input);

        }
    }
}
