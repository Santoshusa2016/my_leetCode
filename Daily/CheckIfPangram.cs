using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/find-duplicate-file-in-system/
     * LeetCode: 609. Find Duplicate File in System 
     * Date: 09/18/2022
     * Test case:
     * Failed:
     * Time Complexity:
     * Space Complexity:
     */
    internal class CheckIfPangram
    {
        bool solve(string sentence)
        {
            if (sentence.Count() < 26)
                return false;
            HashSet<char> alphabets = new HashSet<char>();
            for (int i = 0; i < sentence.Count(); i++)
            {
                alphabets.Add(sentence[i]);
            }
            return alphabets.Count < 26 ? false : true;
        }

        bool solveV1(string sentence)
        {
            //#using int[] and storing true against ascii code
            var letters = new int[123];

            for (int i = 0; i < sentence.Length; i++)
            {
                letters[sentence[i]] = 1;
            }

            for (int i = 97; i < 123; i++)
            {
                if (letters[i] == 0) return false;
            }

            return true;
        }

        bool solveV2(string sentence)
        {
            if (sentence.Count() < 26)
                return false;

            return true;
        }
        public void Driver()
        {
            string inputReq = "thequickbrownfoxjumpsoverthelazydog";
            bool retVal = solve(inputReq);
            Console.WriteLine("CheckIfPangram");
        }
    }
}
