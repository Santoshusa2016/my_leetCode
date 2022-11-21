using System;
using System.Collections.Generic;
using System.Text;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/basic-calculator/
    * LeetCode:224. Basic Calculator
    * Tag: #hard, #stack
    * Company:
    * Date: 11/20/2022
    * Time Complexity: 
    * Space Complexity:
    */
    internal class Calculate
    {
        int solve(string s)
        {
            s = s.Trim();
            int index, leftOperand, sign, rightOperand, runningSum;
            index = leftOperand = rightOperand = runningSum = 0;
            sign = 1;
            Stack<int> calcStack = new Stack<int>();

            while (index < s.Length)
            {
                if (s[index] == '+' || s[index] == '-')
                {
                    leftOperand = runningSum;
                    rightOperand = 0;
                    sign = s[index] == '+' ? 1 : -1;
                }
                else if (s[index] == '(')
                {
                    if (sign != 0)
                    {
                        calcStack.Push(sign);
                        calcStack.Push(runningSum);

                        //reset the values
                        leftOperand = rightOperand = 0;
                        sign = 1;
                    }
                }
                else if (s[index] == ')')
                {
                    //taking sum of values inside braces as right operand
                    rightOperand = runningSum;
                    if (calcStack.Count > 0)
                    {
                        leftOperand = calcStack.Pop();
                        sign = calcStack.Pop();
                    }
                }
                else if (s[index] != ' ')
                {
                    //base case
                    rightOperand = rightOperand * 10 + (int)(s[index] - '0');
                }

                //calc running sum
                runningSum = leftOperand + (sign * rightOperand);
                index++;
            }
            return runningSum;
        }

        public void Driver()
        {
            var inputVal = "(1+(4+5+2)-3)+(6+8)";
            var retVal = solve(inputVal);
            Console.WriteLine($"Calculate-{retVal}");
        }
    }
}
