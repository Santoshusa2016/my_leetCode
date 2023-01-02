using System;
using System.Collections.Generic;
using System.Text;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/detect-capital/
    * LeetCode:520. Detect Capital
    * Tag: #easy, #char, #sort
    * Company:
    * Date: 01/02/2023
    * Time Complexity: 0(N)
    * Space Complexity:O(1)
    */

    internal class DetectCapitalUse
    {
        bool solve(string word)
        {
            if (word == word.ToLower()
                || word == word.ToUpper())
                return true;
            else if (word.Substring(1) == word.Substring(1).ToLower())
                return true;
            else
                return false;
        }

        public bool solveV2(string word)
        {
            if (word == null || word == string.Empty)
                return false;
            else if (word.Length == 1)
                return true;

            bool allowLowerCase = false, allowUpperCase = false;

            if (((int)word[0] >= 97 && (int)word[0] <= 122) ||
                ((int)word[0] >= 65 && (int)word[0] <= 90 
                && (int)word[1] >= 97 && (int)word[1] <= 122))
                allowLowerCase = true;

            if ((int)word[0] >= 65 && (int)word[0] <= 90 && (int)word[1] >= 65 && (int)word[1] <= 90)
                allowUpperCase = true;

            for (int i = 1; i <= word.Length - 1; i++)
            {
                if (allowUpperCase && ((int)word[i] > 90 || (int)word[i] < 65))
                    return false;
                if (allowLowerCase && ((int)word[i] > 122 || (int)word[i] < 97))
                    return false;
            }
            return true;
        }

        public void Driver()
        {
            bool retVal = solveV2("mL");
            Console.WriteLine($"DetectCapitalUse:{retVal}");
        }
    }
}
