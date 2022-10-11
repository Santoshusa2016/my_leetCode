using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/break-a-palindrome/
    * LeetCode: 1328. Break a Palindrome
    * hint: greedy alg
    * Date: 10/10/2022
    * Test case: aa, abccba
    * Time Complexity: 
    * Space Complexity:
    */

    internal class BreakPalindrome
    {

        string solve(string palindrome)
        {
            char charA = 'a';
            int len = palindrome.Length;

            //base case when str len = 1
            if (len <= 1)
                return "";

            char[] palindromes = palindrome.ToCharArray();
            
            //for palindrome to negate we just need to change any 1 char till midpoint
            for (int i = 0; i < len/2; i++)
            {
                //if any char in list is not A, replace it with B
                if (palindromes[i] != charA)
                {
                    palindromes[i] = charA;
                    return string.Concat(palindromes);
                }
            }

            //when all chars are a, replace the last one with b.
            palindromes[len-1] = 'b';
            return string.Concat(palindromes);

        }
        public void Driver()
        {
            var retval = solve("aa");
            Console.WriteLine("BreakPalindrome:{0}", retval);
        }
    }
}
