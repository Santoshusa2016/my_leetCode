using System;
using System.Collections.Generic;
using System.Linq;


//Hint Dynamic Programming, Binary Search
/*
https://github.com/mission-peace/interview/wiki
Tushar: [3,4,-1,0,6,2,3], [2,5,1,8,3]
(Hint: Start the seq with first element j and next element i)
Neetcode: [1,2,4,3]
Failed cases: [0,1,0,3,2,3]
*/
public class LongestSubsequence {
    public int GetLongestSubsequence(int[] nums){

        //Memoize 
        List<int> LIS = Enumerable.Repeat(1, nums.Length).ToList();
        
        for (int i=(nums.Length-2); i >= 0; i--)
        {
            int j = (nums.Length -1);
            int tempval = LIS[i];
            while (j > i)
            {
                 if(nums[i]<nums[j]){
                    tempval = Math.Max(tempval, (LIS[i] + LIS[j]));                    
                 }
                 j--;
            }
            LIS[i] = tempval;
        }

        return LIS.Max(a => a);
    }

    
}