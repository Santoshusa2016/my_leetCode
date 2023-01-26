using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_leetCode.Recursion
{
    /*
    * Ref: https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii
    * LeetCode:122. Best Time to Buy and Sell Stock II
    * Tag: #medium,#dynamicProgram, #recursion, #valley-peak
    * Company:
    * Date: 01/20/2023
    * Time Complexity: 0(2^n), O(n)-valleypeak
    * Space Complexity:O(n)
    */

    internal class MaxProfit_BS2
    {
        int doFindMaxProfit_v1(int[]prices, int index, bool canBuy)
        {
            //base case
            if (index >= prices.Length) return 0;

            int a, b = 0;
            if (canBuy)
            {
                a = -prices[index] + doFindMaxProfit_v1(prices, index+1, false);
                b = doFindMaxProfit_v1(prices, index + 1, true);
            }
            else
            {
                a = prices[index] + doFindMaxProfit_v1(prices, index + 1, true);
                b = doFindMaxProfit_v1(prices, index + 1, false);
            }
            return Math.Max(a, b);
        }

        int doFindMaxProfit_v2(int[] prices, int[] buy, int[] sell, int index, bool canBuy)
        {
            //base case
            if (index >= prices.Length) return 0;

            if (canBuy & buy[index] != -1)
                return buy[index];
            if (!canBuy & sell[index] != -1)
                return sell[index];

            int a, b = 0;
            if (canBuy)
            {
                a = -prices[index] + doFindMaxProfit_v2(prices, buy, sell, index + 1, false);
                b = doFindMaxProfit_v2(prices, buy, sell, index + 1, true);
                return buy[index] = Math.Max(a, b);
            }
            else
            {
                a = prices[index] + doFindMaxProfit_v2(prices, buy, sell, index + 1, true);
                b = doFindMaxProfit_v2(prices, buy, sell, index + 1, false);
                return sell[index] = Math.Max(a, b);
            }            
        }

        int dp_FindMaxProfit(int[] prices)
        {
            int profit = 0;
            if (prices.Length <= 0) return profit;

            for (int i = 0; i < prices.Length - 1; i++)
            {
                if (prices[i + 1] > prices[i])
                {
                    profit += prices[i + 1] - prices[i];
                }
            }
            return profit;
        }

        public int solve(int[] prices)
        {
            int retVal;

            //recursion
            //retVal = doFindMaxProfit_v1(prices, 0, true);

            //memoization
            int[] buy = Enumerable.Repeat(-1, prices.Length).ToArray();
            int[] sell = Enumerable.Repeat(-1, prices.Length).ToArray();
            retVal = doFindMaxProfit_v2(prices, buy, sell, 0, true);

            return retVal;            
        }


        public void Driver()
        {
            int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };
            int retVal = solve(prices);
            Console.WriteLine($"MaxProfit_BS2:{retVal}");
        }
    }
}
