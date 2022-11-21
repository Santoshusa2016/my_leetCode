using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string/
    * LeetCode:1047. Remove All Adjacent Duplicates In String
    * Tag: #easy
    * Company:
    * Date: 11/10/2022
    * Time Complexity: 
    * Space Complexity:
    */
    internal class RemoveDuplicates
    {
        public string solve(string s)
        {
            int i = 1;
            Stack<char> stackChars = new Stack<char>();
            stackChars.Push(s[0]);

            while (i < s.Length)
            {
                char prev = ' ';
                if (stackChars.Count > 0)
                    prev = stackChars.Peek();

                if (prev != s[i])
                    stackChars.Push(s[i]);
                else
                    stackChars.Pop();
                i++;
            }
            return string.Concat(stackChars.Reverse());
        }

        public void Driver()
        {
            string inputReq = "azxxzy";
            string retVal = solve(inputReq);
            Console.WriteLine("RemoveDuplicates:" + retVal);
        }
    }
}
