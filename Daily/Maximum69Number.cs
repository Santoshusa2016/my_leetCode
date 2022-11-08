using System;
using System.Collections.Generic;
using System.Text;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/maximum-69-number/
    * LeetCode:1323. Maximum 69 Number
    * Tag: #easy
    * Company:
    * Date: 11/07/2022
    * Test case:
    * Time Complexity: 
    * Space Complexity:
    */

    internal class Maximum69Number
    {
        public int solve(int num)
        {
            char[] numStr = Convert.ToString(num).ToCharArray();
            int i = 0;
            while (i < numStr.Length)
            {
                if (numStr[i] == '6') { 
                    numStr[i] = '9';
                    return Convert.ToInt32(String.Concat(numStr));
                }
                i++;
            }
            return num;
        }

        public void Driver()
        {
            int inputReq = 9996;
            int retVal = solve(inputReq);
            Console.WriteLine("Maximum69Number:"+ retVal);
        }
    }
}
