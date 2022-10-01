using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/find-k-closest-elements/submissions/
     * LeetCode: 658. Find K Closest Elements
     * Date: 09/28/2022
     * Test case:
     * Failed:
     * https://leetcode.com/problems/find-k-closest-elements/discuss/1310981/Simple-Solutions-w-Explanation-or-All-Possible-Approaches-Explained!
     * Time Complexity:O(log(n-k) + k)
     * Space Complexity:O(1)
     */
    internal class FindClosestElements
    {
        IList<int> solve(int[] arr, int k, int x)
        {
            /*approach: we are going to determine starting point of sub-array(k) from arr[] */
            
            List<int> res = new List<int>();
            int idx = 0;


            //step01: since len of contiguous sub-array is k, we need to do BinarySearch on range [0 to len-k]
            int left = 0;
            int right = arr.Length - k;

            while (left < right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] < x)
                {
                    //step02: if element on midpoint is > than right we move midpoint to right
                    if (x - arr[mid] > arr[mid + k] - x) //we consider [mid+k] as a set/block
                        left = mid + 1;
                    else
                        right = mid;
                }
                else
                    right = mid;
            }



            idx = left;
            while (k != 0)
            {
                res.Add(arr[idx++]);
                k--;
            }
            return res;
        }


        /// <summary>
        /// TimeComplexity: O(n-k)
        /// </summary>
        IList<int> solveV2(int[] arr, int k, int x)
        {
            int low = 0;
            int high = arr.Length - 1;

            while (high-low >= k)
            {
                //assumption:x is in the array, which means arr[lo] is always <= x and arr[hi] is always >= x
                if (arr[high] - x >= x - arr[low])
                {
                    high--;
                }
                else
                    low++;
            }

            List<int> result = new List<int>(k);
            for (int i = low; i <= high; i++)
            {
                result.Add(arr[i]);
            }

            return result;

        }
        public void Driver()
        {
            var inputVal = new int[] { 1, 1, 1, 10, 10, 10 };
            var retVal = solve(inputVal, 1, 9);
        }
    }
}
