using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/concatenation-of-consecutive-binary-numbers/submissions/
     * LeetCode: 1680. Concatenation of Consecutive Binary Numbers
     * Date: 09/23/2022
     * Test case: 1, 3, 12, 42
     * Tag: #medium, #array, #bitmanipulation
     * Time Complexity:
     * Space Complexity:
     */

    internal class ConcatenatedBinary
    {

        int noOfBits(double n)
        {
            //step 01: find number of bits required for num n.
            return Convert.ToInt32(Math.Floor(Math.Log2(n))) + 1 ;
        }

        /// <summary>
        /// this method throw memory exception
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        long solvev1(int n)
        {
            StringBuilder binaryBuilder = new StringBuilder();
            long mod = 1000000007;

            for (int i = 1; i <= n; i++)
            {
                binaryBuilder.Append(Convert.ToString(i, 2));
            }
            var retVal= Convert.ToInt64(binaryBuilder.ToString(), 2);

            return retVal % mod;
        }

        int solvev2(int n)
        {
            StringBuilder binaryBuilder = new StringBuilder();
            long mod = 1000000007;
            long number = 0;

            for (int i = 1; i <= n; i+=1)
            {
                //step02: perform leftshift by bits returned for concat, and then add num
                int retVal = noOfBits(i);
                number = (((number << retVal)%mod + i) % mod);
            }

            //step03: return.
            return (int)number;
        }

        string ToBinary(int decimalNumber)
        {
            int remainder;
            string result = string.Empty;
            while (decimalNumber > 0)
            {
                remainder = decimalNumber % 2;
                decimalNumber /= 2;
                result = remainder.ToString() + result;
            }
            return result;
        }

        void TestBitwise()
        {
            int a = 60;
            int b = 13;
            int retInt = a & b;
            var stra = Convert.ToString(a, 2);
            var strb = Convert.ToString(b, 2);
            Console.WriteLine("stra:{0}-{1}, strb:{2}-{3}", a, stra, b, strb);
            Console.WriteLine("retInt:{0}-{1}", retInt, Convert.ToString(retInt, 2));
        }
        public void Driver()
        {
            var retVal = solvev2(12);
            Console.WriteLine("ConcatenatedBinary: {0}", retVal);
        }
    }
}
