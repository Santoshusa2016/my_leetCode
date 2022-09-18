using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/palindrome-pairs/
     * LeetCode: 336. Palindrome Pairs
     * Date: 09/17/2022
     * Test case:
     * Failed:
     * Hint:
     * Time Complexity:
     * Space Complexity:
     */
    internal class PalindromePairs
    {
        void Solve(string[] words)
        {
            IList<IList<int>> paliandromePairs = new List<IList<int>>();

            for (int i = 0; i < words.Length-1; i++)
            {   
                for (int j = i+1; j < words.Length; j++)
                {
                    if (IsPaliandrome(words[i], words[j]))
                    {
                    }

                }
                
            }
        }

        private bool IsPaliandrome(string v1, string v2, bool isconcat=false)
        {
            bool isPaliandrome = false;
            string reverseV1 = v1.Reverse().ToString();
            if (reverseV1.Equals(v2))
            {
                isPaliandrome = true;
            }
            
            //pre
            string preVal = v1 + v2;
            int median = preVal.Length / 2;
            if(preVal.Length%2 == 0)
            {
                isPaliandrome = IsPaliandrome(preVal.Substring(0, median)
                    , preVal.Substring(median,median), true);
            }
            //post
            string postVal = v2 + v1;
            if (postVal.Length % 2 == 0)
            {
                isPaliandrome = IsPaliandrome(postVal.Substring(0, median)
                    , postVal.Substring(median, median), true);
            }
            return isPaliandrome;
        }

        public void Driver()
        {

        }
    }
}
