using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/contains-duplicate-ii/
     * LeetCode: 219. Contains Duplicate II
     * Date: 10/21/2022
     * hash: #easy, #dictionary
     * Test case:[1,2,3,1] k = 3; [1,0,1,1] k = 1;[1,2,3,1,2,3] k = 2
     * Time Complexity:
     * Space Complexity:
     */
    internal class ContainsNearbyDuplicate
    {
        bool solve(int[] nums, int k)
        {
            Dictionary<int, List<int>> kv = new Dictionary<int, List<int>>();

            //find 2 index having same val
            for (int i = 0; i < nums.Length; i++)
            {
                if (!kv.ContainsKey(nums[i]))
                {
                    kv.Add(nums[i], new List<int>(new int[] { i }));
                }
                else
                {
                    var existVal = kv[nums[i]].Last();
                    if (Math.Abs(i - existVal) <= k)
                        return true;
                    kv[nums[i]].Add(i);
                }                
            }
            return false;
        }
        public void Driver()
        {
            int[] nums = new int[] { 1, 2, 3, 1 };
            int k = 3;
            solve(nums, k);
            Console.WriteLine("ContainsNearbyDuplicate");
        }
    }
}
