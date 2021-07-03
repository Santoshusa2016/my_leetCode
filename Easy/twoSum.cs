
using System.Collections.Generic;
using System.Linq;
public class TwoSum{
    public int[] FindTarget(int[] nums, int target) {

            int[] targetIndex = new int[2];

            for (int i = 0; i < nums.Length-1; i++)
            {
                for (int j = (i+1); j < nums.Length; j++)
                {
                    if(nums[i] + nums[j] == target)
                    {
                        targetIndex[0] = i;
                        targetIndex[1] = j;
                        return targetIndex;
                    }
                }
            }
        return targetIndex;
    }

    /*
    Test Cases:
    [2,7,11,15]
    9
    [3,2,4]
    6
    [3,3]
    6
    */
    public int[] FindTargetWithHash(int[] nums, int target) {
            Dictionary<int,int> ht = new Dictionary<int,int>(nums.Length);
            int[] sumpair = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {
              int diffValue = target - nums[i];
              if(ht.ContainsValue(diffValue)){ //the main idea is dic has containsValue function
                  sumpair[0] = ht.FirstOrDefault(a => a.Value == diffValue).Key;
                  sumpair[1] = i;
              }
              else{
                  ht.Add(i, nums[i]);
              }  
            }
        return sumpair;
    }

}