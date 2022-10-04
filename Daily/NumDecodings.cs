using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/decode-ways/
     * LeetCode: 91. Decode Ways
     * Date: 10/01/2022
     * Test case:"12", "226", "06"
     * Time Complexity:
     * Space Complexity:
     */

    internal class NumDecodings
    {

        int solve(string s)
        {
            int[] dp = new int[s.Length];
            Array.Fill(dp, -1);

            return solve(s, 0, dp);
        }

        private int solve(string s, int index, int[] dp)
        {
            //base condition
            if (index == s.Length) return 1;

            if (s[index] == '0') return 0;

            if (dp[index] != -1)
                return dp[index];

            //step01: Take 1 digit and find Alphabet

            Console.WriteLine("1 Digit:{0}", s[index]);

            int oneDigit = solve(s, index+1, dp);
            int twoDigit = 0;

            //step02: Take 2 digit. Since z=26 is 2 digit
            
            if (index < s.Length- 1 
                && (s[index] == '1' || s[index] == '2' && s[index + 1] <= '6'))
            {
                Console.WriteLine("2 Digit:{0},{1}", s[index], s[index + 1]);
                twoDigit += solve(s, index + 2, dp);
            }

            return dp[index] = oneDigit + twoDigit;

        }

        public void Driver()
        {
            string inputVal = "06";
            int retVal =  solve(inputVal);
            Console.WriteLine("NumDecodings:{0}", retVal);
        }
    }
}
