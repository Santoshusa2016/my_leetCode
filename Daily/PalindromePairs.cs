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
     * Test case:["abcd","dcba","lls","s","sssll"], ["bat","tab","cat"], ["a",""]
     * Failed:
     * Hint:https://www.youtube.com/watch?v=iqM6xYQcsx0&t=136s
     * Time Complexity:
     * Space Complexity:
     */
    internal class PalindromePairs
    {
        /// <summary>
        /// Naive solution
        /// Time Complexity: o(n^3)
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        IList<IList<int>> Solve(string[] words)
        {
            IList<IList<int>> paliandromePairs = new List<IList<int>>();
            if (words.Length < 1)
                return paliandromePairs;

            for (int i = 0; i < words.Length - 1; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    //step 01: Add string a+b
                    string temp = words[i] + words[j];
                    if (IsPaliandrome(temp))
                        paliandromePairs.Add(new List<int>(new int[] { i, j }));

                    //step 02: Add string b+a
                    temp = words[j] + words[i];
                    if (IsPaliandrome(temp))
                        paliandromePairs.Add(new List<int>(new int[] { j, i }));
                }
            }

            return paliandromePairs;
        }

        IList<IList<int>> SolveTrie(string[] words)
        {
            IList<IList<int>> rets = new List<IList<int>>();

            int[] indexes = new int[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                indexes[i] = i;
            }

            Tuple<int, int>[] combos = indexes.SelectMany(x => indexes, (x, y) => Tuple.Create(x, y)).ToArray();

            foreach (Tuple<int, int> combo in combos)
            {
                if (combo.Item1 != combo.Item2)
                {
                    string s = words[combo.Item1] + words[combo.Item2];
                    if (new string(string.Join("", s).Reverse().ToArray()) == s)
                    {
                        rets.Add(new List<int>() { combo.Item1, combo.Item2 });
                    }
                }
            }

            return rets;
        }

        private bool IsPaliandrome(string v1)
        {
            bool isPaliandrome = true;
            int i = 0;
            int j = v1.Length - 1;
            for (; i < j; i++, j--)
            {
                if (v1[i] != v1[j])
                {
                    isPaliandrome = false;
                    break;
                }
            }

            return isPaliandrome;
        }

        public void Driver()
        {
            Solve(new string[] { "abcd", "dcba", "lls", "s", "sssll" });
        }
    }
}
