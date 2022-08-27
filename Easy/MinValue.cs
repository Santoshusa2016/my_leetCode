using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Easy
{
    /*
     * codingninjas - 21051
     * cases * 2,5 => 10
             * 2,99 => 99
             * 3,4 => 100
             * 5,3 = 10002 *
             * 4,55 => 1045
             * 2,99 => 99
             * 2
             * 1,1 => 1
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
