
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace leetCode.Easy
{
    /*
    * Question:https://leetcode.com/problems/valid-palindrome/
    * Hint:Two pointer, quick sort
    * Test cases:
    * Failed cases:
    * Explain:
    */
    internal class ValidPalindrome
    {        
        public bool IsPalindrome(string s)
        {
            //remove spaces and special chars from string
            string updStr = Regex.Replace(s, "[^a-zA-Z0-9]", String.Empty).Replace(" ","").ToLower();

            int i, j;
            i = 0; j = updStr.Length - 1;
            while (i<=j)
            {
                if(updStr[i] != updStr[j])
                    return false;
                else {
                    i++; j--;
                }
            }
            return true;
        }
    }
}
