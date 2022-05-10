using System.Collections.Generic;
using System.Linq;

namespace leetCode.Easy
{
    public class ContainsDuplicate
    {
        public bool hasDuplicate(int[] nums)
        {
            Dictionary<int, int> uniqueNumbers = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (uniqueNumbers.ContainsValue(nums[i]))
                {
                    return true;
                }
                else
                {
                    uniqueNumbers.Add(i, nums[i]);
                }
            }
            return false;
        }

        public bool hasDuplicatewithHashTable(int[] nums)
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
