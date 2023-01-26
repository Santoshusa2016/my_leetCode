using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace my_leetCode.Recursion
{
    internal class MaxProfit_Cooldown
    {
        int doFindMaxProfit_v1(int[] prices, int index, bool canBuy)
        {
            //base case
            if (index >= prices.Length) return 0;

            int a, b = 0;
            if (canBuy)
            {
                a = -prices[index] + doFindMaxProfit_v1(prices, index + 1, false);
                b = doFindMaxProfit_v1(prices, index + 1, true);
            }
            else
            {
                a = prices[index] + doFindMaxProfit_v1(prices, index + 2, true);
                b = doFindMaxProfit_v1(prices, index + 1, false);
            }
            return Math.Max(a, b);
        }


        int dp_FindMaxProfit(int[] prices)
        { 
            int i, valley, peek, profit;
            profit = i = valley = peek = 0;

            while (i < prices.Length - 1)
            {
                while (i < prices.Length - 1 && prices[i] > prices[i + 1])
                    i++;
                valley = prices[i];//buy

                while (i < prices.Length - 1 && prices[i] < prices[i + 1]) { 
                    i++;
                }
                peek = prices[i];//sell

                profit = Math.Max(profit, profit + (peek - valley));
                i += 2;
            }
            return profit;
        }

        public int solve(int[] prices)
        {
            int profit;
            //recursion
            //profit = doFindMaxProfit_v1(prices, 0, true);

            //dp 
            profit = dp_FindMaxProfit(prices);
            return profit;
        }

        public void Driver()
        {
            int[] prices = new int[] { 1, 2, 3, 0, 2 };
            int retVal = solve(prices);
            Console.WriteLine($"MaxProfit_BS2:{retVal}");
        }
    }
}
