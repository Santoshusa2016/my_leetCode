using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Easy
{
    /*
    * Question:https://leetcode.com/problems/valid-parentheses/
    * Hint:Create a dict to save mappings and use stack to find last item added
    * Test cases:
    * Failed cases:
    * Explain:
    */
    internal class ValidParentheses
    {

        public bool IsValid(string s)
        {
            if (s.Length%2 != 0) return false; //every open must have closing brackets

            Dictionary<char, char> mapper = new Dictionary<char, char>();
            mapper.Add('(', ')');
            mapper.Add('[', ']');
            mapper.Add('{', '}');

            Stack<char> vs = new Stack<char>();

            for (int i = 0; i <= s.Length-1; i+=1)
            {
                //if stack element contains the mapping remove
                if (mapper.ContainsKey(s[i])){
                    vs.Push(s[i]);
                }
                else
                {
                    if (vs.Count>0 && mapper.GetValueOrDefault(vs.Peek()) == s[i]) //1
                        vs.Pop();
                    else return false;
                }
            }
          
            return (vs.Count==0 ? true: false);
        }
    }
}
