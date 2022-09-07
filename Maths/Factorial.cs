using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Maths
{
    internal class Factorial
    {

        public int FactorialBottomUp(int num)
        {
            /*
             * In this app, we solve smaller problems and combine it to find results of larger one.
             */
            int[] dp = new int[num + 1];
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
            /*
             * In this app we focus on breaking up the problem to smaller parts
             */
            if (num == 0) return 1;

            //memoization with recurssion
            int factorial = num * FactorialTopDown(num - 1);
            return factorial;
        }
    }
}
