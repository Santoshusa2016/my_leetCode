using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/count-and-say/
     * LeetCode: 38. Count and Say
     * Date: 10/18/2022
     * hash: #medium, #string
     * Test case:4, 1
     * Time Complexity:
     * Space Complexity:
     */

    internal class CountAndSay
    {
        string solve(int n)
        {
            var inputNum = "1";
            for (int i = 1; i < n; i++)
            {
                string sb = "";
                char prevChar=' ';
                int j, counter;
                j = counter = 0;

                while (j < inputNum.Length)
                {
                    var currentChar = inputNum[j];
                    if (prevChar != currentChar)
                    {
                        if(prevChar != ' ')
                            sb+= (counter.ToString() + prevChar.ToString());
                        counter = 1;
                    }
                    else
                    {
                        counter++;
                    }
                    prevChar = currentChar;
                    j++;
                }
                sb += (counter.ToString() + prevChar.ToString());
                inputNum = sb;
            }

            return inputNum;
        }

        public void Driver()
        {
            var retVal = solve(4);
            Console.Write("CountAndSay:{0}", retVal);
        }
    }
}
