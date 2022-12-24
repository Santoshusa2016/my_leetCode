using System;
using System.Collections.Generic;
using System.Text;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/domino-and-tromino-tiling/description/
    * LeetCode:790. Domino and Tromino Tiling
    * Tag: #medium, #dp
    * Company:
    * Date: 12/24/2022
    * Time Complexity: 0(N)
    * Space Complexity:O(N)
    */
    internal class NumTilings
    {
        private const long mod = 1000000007; //10e+7
        private int[] memArray = new int[1000];
        private int[] dp = new int[1000];

        public int doCalc(int n)
        {
            //basecase
            if (n <= 1)
                return 1;
            else if (n == 2)
                return 2;
            else
            {
                return (int)((2 * doCalc(n - 1) % mod + doCalc(n - 3) % mod) % mod);
            }
        }

        public int doCalc_memo(int n)
        {
            //memoization
            if (memArray[n] != 0)
                return memArray[n];
            if (n <= 1)
                return memArray[n] = 1;
            else if (n == 2)
                return memArray[n] = 2;
            else
            {
                return memArray[n] = (int)(
                    (2 * doCalc_memo(n - 1) % mod + doCalc_memo(n - 3) % mod) % mod
                    );
            }
        }

        public int doCalc_Dp(int n)
        {
            dp[0] = 1; dp[1] = 1; dp[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                dp[i] = (int)((2 * dp[i - 1] % mod + dp[i - 3] % mod) % mod);
            }
            return dp[n];
        }

        public void Driver()
        {
            int retVal = doCalc_memo(60);
            Console.WriteLine($"NumTilings:{retVal}");
        }

    }
}
