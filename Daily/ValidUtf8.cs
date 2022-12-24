using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/utf-8-validation/submissions/
     * LeetCode: 393. UTF-8 Validation 
     * Date: 09/13/2022
     * Test case: [197,130,1]; [235,140,4]; [100,200,300,400],200
     * Tag: #medium, #array, #bitmanipulation
     * Time Complexity:O(n)
     * Space Complexity: O(1)
     */
    internal class ValidUtf8
    {
        bool solve(int[] nums)
        {
            //step01: create an integer to store the length consecutive byte calc
            int bytesRemain = 0;
            
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i];                

                if (bytesRemain <= 0)
                {
                    //step 02: based on first byte determine len of successive byte
                    if (val >> 7 == 0b0)
                        bytesRemain = 0;
                    else if (val >> 5 == 0b110)
                        bytesRemain = 1;
                    else if (val >> 4 == 0b1110)
                        bytesRemain = 2;
                    else if (val >> 3 == 0b11110)
                        bytesRemain = 3;
                    else
                        return false;
                }
                else
                {
                    if (val >> 6 == 0b10)
                        bytesRemain--;
                    else
                        return false;
                }                
            }
            return bytesRemain == 0;
        }

        public void Driver()
        {
            bool retval = solve(new int[]{197, 130, 1});
        }
    }
}
