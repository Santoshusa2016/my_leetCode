using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Easy
{
    /*
    * Question: codingninjas - 21051
    * Hint:
    * Test cases: [2,5] [2,99] [3,4] [5,3] [4,55] [2,99], 2, [1,1]
    * Failed cases: 
    * Explain:
    */
    internal class MinValue
    {
        public double? Solve(int a, int? b = null)
        {
            if (b == null)
                return null;

            //if a == noofDigits b, not need to proceed
            if (a == FindNumberOfDigit(b))
                return b;

            int noOfZeros = a-1;

            double decimalNum = Math.Pow(10, noOfZeros);
            var quotient = decimalNum/b;
            double reminder = Math.Round((double)quotient
                , mode: MidpointRounding.ToPositiveInfinity);
            return reminder*b;
        }

        private static int FindNumberOfDigit(int? number)
        {
            int count = 0;
            while (number > 0)
            {
                number /= 10;
                count++;
            }
            return count;
        }

    }
}
