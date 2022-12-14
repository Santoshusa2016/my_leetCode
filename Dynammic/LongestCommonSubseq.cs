using System;
using System.Collections.Generic;
using System.Text;

namespace my_leetCode.Dynammic
{
    /*
    * Ref: https://leetcode.com/problems/longest-common-subsequence/
    * LeetCode: 1143. Longest Common Subsequence
    * Tag: #dynamicProgram, #medium, #string
    * Date: 10/29/2022
    * Test case: abcabcbb, bbbbb, pwwkew
    * Time Complexity: 
    * Space Complexity:
    */

    public class LongestCommonSubseq
    {
        public int LCS_DP(string text1, string text2)
        {
            int[,] memoizeArray = new int[(text1.Length + 1), (text2.Length + 1)];
            int maxValue = 0;

            //Loop starts from end, matrix filled from begin
            for (int i = 1; i <= text1.Length; i++)
            {
                for (int j = 1; j <= text2.Length; j++)
                {
                    if (text1[i - 1] == text2[j - 1])
                    {
                        //find the max till the given index. So we add prev index value
                        memoizeArray[i, j] = 1 + (memoizeArray[i - 1, j - 1]);
                    }
                    else
                    {
                        memoizeArray[i, j] = Math.Max(memoizeArray[i - 1, j], memoizeArray[i, j - 1]);
                    }

                    maxValue = memoizeArray[i, j] > maxValue ? memoizeArray[i, j] : maxValue;
                }
            }
            return maxValue;
        }
    }
}
