using System;

public class MaxProdArray
{
    //Dynammic Programming
     public int GetMaxSubArrayKadens(int[] nums){
        if(nums.Length == 0) return 0;
        
        //create temp variables to store current, min and max
        int tempMin, tempMax, maxValue, tempCurrent;

        tempMax = maxValue = nums[0];        
        tempMin = tempCurrent = 1;
 
        for (int i = 1; i < nums.Length; i++)
        {
                if (tempMin == 0 && tempMax == 0){
                    tempMax = tempMin = 1;
                }
                tempMin = (tempMin * nums[i]); 
                tempMax = (tempMax * nums[i]);

                if(tempMin > tempMax){
                    //Swap min and max
                    tempCurrent = tempMax;
                    tempMax = tempMin;
                    tempMin = tempCurrent;
                }

                //Compare min and max with the current element value
                tempMax = Math.Max(tempMax, nums[i]);
                tempMin = Math.Min(tempMin, nums[i]);

            //update the maximum value
            tempCurrent = Math.Max(tempMax, tempMin);
            maxValue = maxValue > tempCurrent ? maxValue:tempCurrent;
        }

        return maxValue;
    }


/*
Cases Tested: [2,3,-2,4], [2,3,-2,-4], [2,0,-1,8]
Failed cases: [3,-1,4] Exp 4, Act 3
[-2,0,-1] Exp 0, Act 1
*/
}