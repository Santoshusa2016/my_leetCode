using System;
using System.Collections.Generic;
using System.Linq;

namespace my_leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/integer-to-roman/
     * LeetCode: 12. Integer to Roman
     * Date: 10/20/2022
     * hash: #medium, #dictionary
     * Test case:4, 1
     * Time Complexity:
     * Space Complexity:
     */

    internal class IntToRoman
    {
        //step01: create dict for mapping
        Dictionary<int, string> romanCharMap = new Dictionary<int, string>();
        public IntToRoman()
        {
            romanCharMap.Add(1, "I");

            romanCharMap.Add(4, "IV");
            romanCharMap.Add(5, "V");

            romanCharMap.Add(9, "IX");
            romanCharMap.Add(10, "X");

            romanCharMap.Add(40, "XL");
            romanCharMap.Add(50, "L");

            romanCharMap.Add(90, "XC");
            romanCharMap.Add(100, "C");

            romanCharMap.Add(400, "CD");
            romanCharMap.Add(500, "D");

            romanCharMap.Add(900, "CM");//XXM or DCCC
            romanCharMap.Add(1000, "M");
        }


        string solve(int num)
        {
            string romanChar = "";
            //base case
            if (num < 1)
            {
                return romanChar;
            }
            else if (romanCharMap.ContainsKey(num))
            {
                romanChar = romanCharMap[num].ToString();
                return romanChar;
            }

            int startIndex = findIndex(num);
            int endIndex = startIndex + 1;

            romanChar = romanChar + (romanCharMap.ElementAt(startIndex).Value);
            int subNum = num - romanCharMap.ElementAt(startIndex).Key;
            romanChar = romanChar + solve(subNum);

            return romanChar;
        }

        int findIndex(int num)
        {
            //step02: find start,end index
            int start, end;
            start = 0; end = 1;
            while (end < romanCharMap.Count())
            {
                if (num < romanCharMap.ElementAt(end).Key)
                    break;
                else
                {
                    start++;
                    end++;
                }
            }
            return start;
        }

        public string solveV2(int num)
        {
            if (num >= 1000) return "M" + solveV2(num - 1000);

            if (num >= 500) return num >= 900 ? ("CM" + solveV2(num - 900)) : ("D" + solveV2(num - 500));

            if (num >= 100) return num >= 400 ? ("CD" + solveV2(num - 400)) : ("C" + solveV2(num - 100));

            if (num >= 50) return num >= 90 ? ("XC" + solveV2(num - 90)) : ("L" + solveV2(num - 50));

            if (num >= 10) return num >= 40 ? ("XL" + solveV2(num - 40)) : ("X" + solveV2(num - 10));

            if (num >= 5) return num == 9 ? "IX" : "V" + solveV2(num - 5);

            if (num > 0) return num == 4 ? "IV" : "I" + solveV2(num - 1);

            return "";
        }


        public void Driver()
        {
            int inputVal = 1994;
            string romanChar = solve(inputVal);
            Console.WriteLine($"IntToRoman:{romanChar}");
        }
    }
}
