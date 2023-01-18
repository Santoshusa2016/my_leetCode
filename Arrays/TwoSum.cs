using System;
using System.Collections.Generic;
using System.Text;

namespace my_leetCode.Arrays
{
    /*
    * Ref: https://leetcode.com/problems/two-sum-ii-input-array-is-sorted
    * LeetCode: 167. Two Sum II - Input Array Is Sorted
    * Tag: #array, #twopointer, #binarysearch
    * Date: 01/17/2023
    * Time Complexity: O(n)
    * Space Complexity: O(1)
    * not following edge cases
    */

    internal class TwoSum
    {
        int[] solve(int[] numbers, int target)
        {
            int[] ans = new int[2];
            int i = 0;
            int j = numbers.Length - 1;

            while (i < j)
            {
                int sum1 = numbers[i] + numbers[j];

                if (sum1 == target)
                    break;
                else if (sum1 > target)
                    j--;
                else
                    i++;
            }
            ans[0] = i + 1;
            ans[1] = j + 1;
            return ans;
        }

        int[] solvev2(int[] numbers, int target)
        {
            int n = numbers.Length;
            for (int i = 0; i < numbers.Length; i++)
            {
                int j = Array.BinarySearch(numbers, i + 1, n-1-i, target - numbers[i]);
                if (j >= 0)
                    return new int[] { i + 1, j + 1 };
            }
            return new int[] { -1, -1 };
        }

        public void Driver()
        {
            var inputVal = new int[] { 3, 24, 50, 79, 88, 150, 345 };
            var retVal = solvev2(inputVal, 200);
            Console.WriteLine("TwoSum:{0}", retVal);
        }
    }
}
