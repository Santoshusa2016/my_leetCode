/* Test Cases:
[7,6,4,3,1]
[7,1,5,3,6,4]
Failed
[2,4,1]
*/

public class MaxProfit {
    public int GetMaxProfit(int[] prices) {
        int maxIndex = 0, minIndex = 0;
        int maxProfit = 0, tempProfit = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            if(prices[i] < prices[minIndex]){        
                minIndex = i;
                maxIndex = i;
            }else if(prices[maxIndex] < prices[i]){
                maxIndex = i;
            }
            //The temp profit is created to hold the old max profit determined
            tempProfit = (prices[maxIndex] - prices[minIndex]);
            maxProfit = maxProfit > tempProfit
                        ? maxProfit: tempProfit;
        }
        return maxProfit;
    }
}