using System.Collections.Generic;
using System.Linq;

namespace leetCode.Easy
{
    /*
    * Question: https://leetcode.com/problems/contains-duplicate/
    * Hint:
    * Test cases:
    * Failed cases:
    * Explain:
    */
    public class ContainsDuplicate
    {
        public bool hasDuplicate(int[] nums)
        {
            HashSet<int> uniqueNumbers = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (uniqueNumbers.Contains(nums[i]))
                {
                    return true;
                }
                else
                {
                    uniqueNumbers.Add(nums[i]);
                }
            }
            return false;
        }
        
    }
}
