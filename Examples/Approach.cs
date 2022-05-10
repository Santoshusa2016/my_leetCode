using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Examples
{
    internal class Approach
    {

        public int FactorialBottomUp(int num)
        {
            int[] dp = new int[num+1];
            dp[0] = 1;
            //tabular with iteration
            for (int i = 1; i <= num; i++)
            {
                dp[i] = dp[i - 1] * i;
            }

            return dp[num];
        }

        public int FactorialTopDown(int num)
        {
            if (num == 0) return 1;
            //memoization with recurssion
            int factorial = num * FactorialTopDown(num-1);
            return factorial;
        }
    }
}
