using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv
     * LeetCode: 188. Best Time to Buy and Sell Stock IV 
     * Date: 09/10/2022
     * Tag: #hard, #dynamicProgram
     * Company: 
     * Test case:[3,2,6,5,0,3], [1,2,4]->E3 02, [1,2,4,2,5,7,2,4,9,0] -> 012 E13
     * Failed: 2 [2,4,1]
     * Time Complexity: O(2^n)
     * Space Complexity:
     */
    internal class MaxProfit
    {

        int doFindMaxProfit_v2(int index, bool canBuy, int k, int[] prices,
            Dictionary<KeyValuePair<int, bool>, int> dp)
        {
            //base case: if all trans are used
            if (k == 0 || index == prices.Length)
                return 0;

            if (dp.ContainsKey(new KeyValuePair<int, bool>(index, canBuy)))
                return dp[new KeyValuePair<int, bool>(index, canBuy)];

            int maxProfit = 0;
            if (canBuy)
            {
                int buy = -prices[index] + doFindMaxProfit_v2(index + 1, false, k, prices, dp);
                int notbuy = 0 + doFindMaxProfit_v2(index + 1, true, k, prices, dp);
                maxProfit = Math.Max(buy, notbuy);
            }
            else
            {
                int sell = prices[index] + doFindMaxProfit_v2(index + 1, true, k - 1, prices, dp);
                int notsell = 0 + doFindMaxProfit_v2(index + 1, false, k, prices, dp);
                maxProfit = Math.Max(sell, notsell);
            }
            dp.Add(new KeyValuePair<int, bool>(index, canBuy), maxProfit);

            return maxProfit;
        }

        int doFindMaxProfit_v1(int index, bool canBuy, int k, int[] prices)
        {
            //base case: if all trans are used
            if (k == 0 || index == prices.Length)
                return 0;

            int maxProfit = 0;
            if (canBuy)
            {
                int buy = -prices[index] + doFindMaxProfit_v1(index + 1, false, k, prices);
                int notbuy = 0 + doFindMaxProfit_v1(index + 1, true, k, prices);
                maxProfit = Math.Max(buy, notbuy);
            }
            else
            {
                int sell = prices[index] + doFindMaxProfit_v1(index + 1, true, k - 1, prices);
                int notsell = 0 + doFindMaxProfit_v1(index + 1, false, k, prices);
                maxProfit = Math.Max(sell, notsell);
            }
            return maxProfit;
        }

        public void Driver()
        {
            int k = 2;
            int[] prices = new int[] { 3, 2, 6, 5, 0, 3 };
            int retVal = solve(k, prices);
            Console.WriteLine($"MaxProfit:{retVal}");
        }

        public int solve(int k, int[] prices)
        {
            int profit = 0;

            //only one day of stock-no buy/sell on same day
            if (k <= 0 && prices.Count() <= 1)
                return profit;

            //step 01: create DS to store max, min and Profit
            Dictionary<KeyValuePair<int, bool>, int> salesRecord =
                new Dictionary<KeyValuePair<int, bool>, int>();

            profit = doFindMaxProfit_v1(0, true, k, prices);
            //profit = doFindMaxProfit(0, true, k, prices, salesRecord);
            return profit;

        }
    }
}
