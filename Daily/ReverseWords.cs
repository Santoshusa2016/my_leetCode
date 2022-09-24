using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/reverse-words-in-a-string-iii/
     * LeetCode: 557. Reverse Words in a String III
     * Date: 09/22/2022
     * Test case:
     * Failed:
     * Time Complexity:
     * Space Complexity:
     */
    internal class ReverseWords
    {
        string solve(string s)
        {
            if (s.Length == 1) return s;
            string[] words = s.Split(" ");

            for (int i = 0; i < words.Length; i++)
            {
                char[]item = words[i].ToCharArray();
                int start = 0;
                int end = item.Length - 1;
                while (start < end)
                {
                    char temp = item[start];
                    item[start] = item[end];
                    item[end] = temp;
                    end--;
                    start++; 
                }

                words[i] = string.Concat(item);
            }

            return string.Join(" ", words);
        }

        public void Driver()
        {
            string retval = solve(@"Let's take LeetCode contest");
            Console.WriteLine("ReverseWords:{0}", retval.Length);
        }
    }
}
