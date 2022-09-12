using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/
     * LeetCode: 188 
     * Date: 09/10/2022
     * Test case:[3,2,6,5,0,3], [1,2,4]->E3 02, [1,2,4,2,5,7,2,4,9,0] -> 012 E13
     * Failed: 2 [2,4,1]
     * Time Complexity:
     * Space Complexity:
     */
    internal class MaxProfit
    {
        //Option 01: recurssion/ greedy algorithm
        //option 02: Memoize and skip few repetition calls
        int findMaxProfitRec(int i, bool canBuy, int k, int[] prices,
            Dictionary<KeyValuePair<int, bool>, int> dp)
        {
            //base case: if all trans are used
            if (k == 0 || i == prices.Length)
            {
                return 0;
            }

            if (dp.ContainsKey(new KeyValuePair<int, bool>(i, canBuy)))
            {
                return dp[new KeyValuePair<int, bool>(i, canBuy)];
            }
            int maxProfit = 0;
            if (canBuy)
            {
                int buy = -prices[i] + findMaxProfitRec(i + 1, false, k, prices, dp);
                int notbuy = 0 + findMaxProfitRec(i + 1, true, k, prices, dp);
                maxProfit = Math.Max(buy, notbuy);
            }
            else
            {
                int sell = prices[i] + findMaxProfitRec(i + 1, true, k - 1, prices, dp);
                int notsell = 0 + findMaxProfitRec(i + 1, false, k, prices, dp);
                maxProfit = Math.Max(sell, notsell);
            }
            dp.Add(new KeyValuePair<int, bool>(i, canBuy), maxProfit);

            return maxProfit;
        }

        public void Driver()
        {
            Dictionary<KeyValuePair<int, bool>, int> dp
                = new Dictionary<KeyValuePair<int, bool>, int>();

            var profit = findMaxProfitRec(0, true, 2, new int[] { 1, 2, 4 }, dp);
            Console.Write("MaxProfit: ", profit);
        }

        //Failed Try
        public int SolveV1(int k, int[] prices)
        {
            int profit = 0;

            //base case - no trans/only one day of stock-no buy/sell on same day
            if (k <= 0 && prices.Count() <= 1)
                return profit;


            //step 01: create DS to store max, min and Profit
            Dictionary<KeyValuePair<int, int>, int> salesRecord =
                new Dictionary<KeyValuePair<int, int>, int>();
            int min, max, tempProfit;
            min = max = tempProfit = 0;

            //step 02: iterate over each index to find best time to sell/ buy stock
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[max])
                    max = i;
                else
                    min = max = i;

                tempProfit = prices[max] - prices[min];

                if (tempProfit > 0)
                {
                    //check if there exist a key for min & replace it: //2
                    var record = salesRecord.Where(a => a.Key.Key == min).FirstOrDefault();
                    if (record.Value > 0)
                        salesRecord.Remove(record.Key);


                    //While adding new record to list check if difference between prev and next is greater

                    salesRecord.Add(new KeyValuePair<int, int>(min, max)
                        , tempProfit);
                }
            }


            for (int i = 0; i < salesRecord.Count; i++)
            {
                //this step we need to check diff between all min & max
            }
            profit = salesRecord.OrderByDescending(kvp => kvp.Value).Take(k).Sum(
                (kvp) => kvp.Value);

            return profit;
        }
    }
}
