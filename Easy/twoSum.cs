
using System.Collections.Generic;
using System.Linq;
public class TwoSum{
    /*
Test Cases:
[2,7,11,15]
9
[3,2,4]
6
[3,3]
6
*/
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

    public int[] FindTargetWithHash(int[] nums, int target) {
        Dictionary<int, int> uniqueList = new Dictionary<int, int>();
        
        //in selection sort we iterate over list to determine ans
        //here we create a new list based on old one, but before adding we check if we get target

        for (int i = 0; i < nums.Length; i++)
        {
            int diffValue = target - nums[i];
            if (uniqueList.ContainsValue(diffValue))
            {
                int index1 = uniqueList.FirstOrDefault(a => a.Value == diffValue).Key;
                return new int[] { index1, i };
            }
            else
            {
                uniqueList.Add(i, nums[i]);
            }
        }
        return new int[] { 0, 0 };
    }

}