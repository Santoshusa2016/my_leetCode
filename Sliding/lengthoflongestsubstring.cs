using System.Collections.Generic;
using System;

namespace my_leetCode.Sliding
{
    /*
    * Ref: https://leetcode.com/problems/longest-substring-without-repeating-characters/
    * LeetCode: 3. Longest Substring Without Repeating Characters
    * Tag: #slidingwindow, #medium, #string, #hashtable
    * Date: 10/29/2022
    * Test case: abcabcbb, bbbbb, pwwkew
    * Time Complexity: O(n)
    * Space Complexity:O(1)
    */
    public class LengthOfLongestSubstring
    {
        public int GetLongestSubStringLen(string s)
        {
            int maxlength = 0;
            if (s.Length == 0) return 0;
            if (s.Length == 1) return 1;
            if (s.Length == 2)
            {
                if (s.Substring(0, 1) != s.Substring(1, 1))
                    return 2;
                else return 1;
            }

            for (int i = 0; i < s.Length - 1; i++)
            {
                var substr = s.Substring(i, 1);
                for (int j = i + 1; j < s.Length; j++)
                {
                    string nxtSubStr = s.Substring(j, 1);
                    if (substr.IndexOf(nxtSubStr) == -1)
                    {
                        substr = substr + nxtSubStr;
                    }
                    else
                    {
                        break; //exit the for loop 
                    }
                }
                maxlength = maxlength > substr.Length ? maxlength : substr.Length;
            }
            return maxlength;
        }

        public int GetLongestSubstringLen(string s)
        {
            int maxlength = 0, i = 0;
            string uniqueChar = "";

            if (s == null || s == String.Empty)
                return 0;

            while (i < s.Length)
            {
                char check = s[i];
                if (!uniqueChar.Contains(check))
                {
                    uniqueChar = uniqueChar + check;
                }
                else
                {
                    int index = uniqueChar.IndexOf(check);
                    uniqueChar = uniqueChar.Substring(index + 1);
                    uniqueChar = uniqueChar + check;
                }
                i++;
                maxlength = maxlength > uniqueChar.Length ? maxlength : uniqueChar.Length;
            }
            return maxlength;
        }

        public int LenOfLongestSubstring(string s)
        {
            if (s == null || s == String.Empty)
                return 0;

            HashSet<char> set = new HashSet<char>();
            int currentMax = 0,
                i = 0,
                j = 0;

            while (j < s.Length)
                if (!set.Contains(s[j]))
                {
                    set.Add(s[j++]);
                    currentMax = Math.Max(currentMax, j - i);
                }
                else
                    set.Remove(s[i++]);

            return currentMax;
        }
    }
}