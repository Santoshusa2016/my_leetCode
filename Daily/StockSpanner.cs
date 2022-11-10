using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/online-stock-span/description/
    * LeetCode:901. Online Stock Span
    * Tag: #medium
    * Company:
    * Date: 11/09/2022
    * Test case:
    * Time Complexity: 
    * Space Complexity:
    */
    
    internal class StockSpanner
    {
        public List<int> stockPrices { get; set; }
        public List<int> stockIndicators { get; set; }
        public StockSpanner()
        {
            stockPrices = new List<int>();
            stockIndicators = new List<int>();
        }

        public int Next(int price)
        {
            stockPrices.Add(price);
            int index = stockPrices.Count - 2;
            int tempVal = 1;

            while (index >= 0)
            {
                if (price > stockPrices[index])
                {
                    tempVal = tempVal+ stockIndicators[index];
                }
                else
                    break;
                index = index- stockIndicators[index];
            }

            stockIndicators.Add(tempVal);
            return tempVal;
        }

        public void Driver()
        {
            StockSpanner instance = new StockSpanner();
            int retVal = 0;
            retVal = instance.Next(100);
            retVal = instance.Next(80);
            retVal = instance.Next(60);
            retVal = instance.Next(70);
            retVal = instance.Next(60);
            retVal = instance.Next(75);
            retVal = instance.Next(85);

            Console.WriteLine("StockSpanner:" + retVal);
        }
    }

    //public class StockSpanner
    //{

    //    private Stack<(int, int)> stack;

    //    public StockSpanner()
    //    {
    //        stack = new Stack<(int, int)>();
    //    }

    //    public int Next(int price)
    //    {
    //        int span = 1;

    //        while (stack.Count > 0 && stack.Peek().Item1 <= price)
    //            span += stack.Pop().Item2;


    //        stack.Push((price, span));

    //        return span;
    //    }
    //}
}
