using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Arrays
{

    /*
    * Ref: https://leetcode.com/problems/longest-consecutive-sequence/
    * LeetCode: 128. Longest Consecutive Sequence
    * Tag: #hash, #medium, #graph, #array
    * Date: 10/29/2022
    * Test case: [100,4,200,1,3,2], [0,3,7,2,5,8,4,6,0,1]
    * Time Complexity: 
    * Space Complexity:
    */

    internal class LongestConsecutive
    {
        int solve(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            Array.Sort(nums);
            int maxCounter, tempCounter;
            maxCounter = tempCounter = 1;
            int initialVal = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != initialVal)
                {
                    if (nums[i] == initialVal + 1)
                    {
                        tempCounter++;
                    }
                    initialVal = nums[i];                    
                }
                maxCounter = Math.Max(tempCounter, maxCounter);
            }

            return maxCounter;
        }

        int solveV1(int[] nums)
        {
            //#hashset
            if (nums == null || nums.Length <= 0)
                return 0;

            int result = 0, sequence = 0;

            HashSet<int> hash = new HashSet<int>();
            foreach (var num in nums)
                hash.Add(num);

            nums = hash.ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                //check if lesser number exist in set
                if (hash.Contains(nums[i] - 1) == false)
                {
                    sequence = nums[i];

                    //sequence will reach to last element of longest subsequence
                    while (hash.Contains(sequence))
                        sequence++;

                    result = Math.Max(result, sequence - nums[i]);
                }
            }

            return result;
        }

        public void Driver()
        {

            var inputVal = new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 };
            int retVal = solveV1(inputVal);

            Console.WriteLine("LongestConsecutive:{0}", retVal);
        }
    }
}
