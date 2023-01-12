using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/bag-of-tokens/
     * LeetCode: 948 Bag of Tokens 
     * Date: 09/12/2022
     * Test case:[100],50; [100,200],150; [100,200,300,400],200
     * Failed:
     * Hint: sort the array and take 2 pointer, 
     * begin pointer - use power buy stocks, end pointer - use vote buy max stock
     * Time Complexity: O(n)
     * Space Complexity: O(1)
     */
    internal class BagOfTokensScore
    {
        int Solve(int[] tokens, int power)
        {
            int maxVotes, votes;
            maxVotes = votes = 0;

            //step01: sort array asc
            tokens = tokens.OrderBy(a => a).ToArray();

            //step 01: take 2 pointer & start iteration
            int begin = 0;
            int end = tokens.Length - 1;

            while (begin <= end)
            {
                if (tokens[begin] <= power)
                {
                    //step 02: if tokens[i] < power ->buy
                    votes += 1;
                    power -= tokens[begin];
                    begin++;
                }
                else if (votes > 0)
                {
                    //step 3: if tokens[i]> power -> use vote to buy most shares
                    votes -= 1;
                    power += tokens[end];
                    end--;
                }
                else { 
                    //step 04: default case when you dont have enough vote/score & money/power to buy
                    break;
                }
                maxVotes = Math.Max(maxVotes, votes);
            }

            return maxVotes;
        }

        public void Driver()
        {
            int maxVote = Solve(new int[] { 100, 200, 300, 400 }, 200);
            Console.WriteLine("maxVote: {0}", maxVote);
        }
    }
}
