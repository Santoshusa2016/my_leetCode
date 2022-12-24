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
    * Time Complexity: O(m*n)
    * Space Complexity:
    */

    public class LongestCommonSubseq
    {
        #region Dynammic
        public int LCS(string text1, string text2)
        {
            int[,] memoizeArray = new int[(text1.Length + 1), (text2.Length + 1)];
            int maxValue = 0;

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
                        //take max of prev row/ column from table
                        memoizeArray[i, j] = Math.Max(memoizeArray[i - 1, j], memoizeArray[i, j - 1]);
                    }

                    maxValue = memoizeArray[i, j] > maxValue ? memoizeArray[i, j] : maxValue;
                }
            }
            return maxValue;
        }
        #endregion
        #region recurssion
        int LCS (string text1, int i, string text2, int j)
        {
            //base case
            if (text1[i] == '0' || text2[j] == '0')
                return 0;
            else if (text1[i] == text2[j])
                return LCS(text1, i + 1, text2, j + 1);
            else
                return Math.Max(LCS(text1, i, text2, j + 1)
                    , LCS(text1, i + 1, text2, j));
        }
        #endregion
    }
}
