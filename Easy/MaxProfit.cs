
namespace leetCode.Easy
{
    /*
    * Question: 
    * Hint:
    * Test cases: [7,6,4,3,1] [7,1,5,3,6,4]
    * Failed cases: [2,4,1]
    * Explain:
    */
    public class MaxProfit
    {
        public int GetMaxProfit(int[] prices)
        {
            int maxIndex = 0; //sell
            int minIndex = 0; //buy
            int maxProfit = 0, tempProfit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < prices[minIndex])
                {
                    minIndex = i;
                    maxIndex = i;
                }
                else if (prices[i] > prices[maxIndex])
                {
                    maxIndex = i;
                }

                //Temp profit is created to determine max profit in each iteration
                tempProfit = (prices[maxIndex] - prices[minIndex]);

                maxProfit = maxProfit > tempProfit
                            ? maxProfit : tempProfit;
            }
            return maxProfit;
        }
    }
}