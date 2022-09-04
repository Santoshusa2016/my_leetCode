using System;

namespace leetCode.Easy
{
    /*
    * Question: https://leetcode.com/problems/maximum-subarray/ 
    * Hint:
    * Test cases: [-2, 1, -3, 4, -1, 2, 1, -5, 4], [5,4,-1,7,8]
    * Failed cases: [8,-19,5,-4,20] ,[-2,3,0,2,-2,3]
    * Explain:
    */
    public class MaxSubArray
    {
        //Dynammic Programming
        public int GetMaxSubArrayKadens(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int currMax, maxValue;
            currMax = maxValue = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                //Determine max value in each iteration
                currMax = Math.Max((nums[i] + currMax), nums[i]);
                maxValue = currMax > maxValue ? currMax : maxValue;
            }
            return maxValue;
        }

        /* Divide and Conquer - recurrsion
        Failed Cases:
        [8,-19,5,-4,20] -> 33
        1 Act: 20 (Instead of counting max of Left & Right I was getting 
        max of either left or right by using comparison)
        [-2,3,0,2,-2,3] -> Exp:6 Act:5: (Since we were stopping when sum decreased we never checked 
        if there is any higher value after the decrease. This is why we need to find max and not stop when 
        )
        */
        public int GetMaxSubArrayDC(int[] nums)
        {
            return FindMax(0, (nums.Length - 1), nums);
        }

        public int FindMax(int startIndex, int endIndex, int[] nums)
        {
            //base condition
            int retValue = 0;
            if (startIndex == endIndex)
                retValue = nums[startIndex];
            else if (startIndex < endIndex)
            {
                int median = (startIndex + endIndex) / 2;
                int a, b, c;
                Console.WriteLine("FindMax startIndex:{0},endIndex:{1}, median:{2}"
                , startIndex, endIndex, median);

                a = FindMax(startIndex, median, nums);
                b = FindMax(median + 1, endIndex, nums);
                c = FindCrossMax(startIndex, median, endIndex, nums);
                Console.WriteLine("FindMax a:{0}, b:{1}, Max:{2}", a, b, c);
                retValue = Math.Max(Math.Max(a, b), c);
            }
            return retValue;
        }

        public int FindCrossMax(int startIndex, int median, int endIndex, int[] nums)
        {
            int leftMax = nums[median];
            int rightMax = nums[median + 1];

            int tempMax = leftMax;
            for (int i = (median - 1); i >= startIndex; i--)
            {
                /*You cannot apply kadens logic because Kadens use either current/ curr+prev for
                max. If current is taken then you are breaking the contiguos finding   
                */
                tempMax += nums[i];
                leftMax = (leftMax > tempMax) ? leftMax : tempMax;
            }

            tempMax = rightMax;
            for (int i = (median + 2); i <= endIndex; i++)
            {
                tempMax += nums[i];
                rightMax = (rightMax > tempMax) ? rightMax : tempMax;
            }

            return leftMax + rightMax;
        }



        //Brute force - Submission 01
        //Failed -1, [-2,-1]
        public int GetMaxSubArrayValueOpt01(int[] nums)
        {
            int maxvalue = 0;
            if (nums.Length == 1)
            {
                return nums[0];
            }
            else if (nums.Length == 0)
            {
                return 0;
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    int tempMax, tempSum;
                    tempMax = tempSum = nums[i];
                    if (i < nums.Length - 1)
                    {
                        for (int j = i + 1; j < nums.Length; j++)
                        {
                            tempSum = tempSum + nums[j];
                            tempMax = tempMax > tempSum ? tempMax : tempSum;
                        }
                    }
                    maxvalue = maxvalue > tempMax ? maxvalue : tempMax;
                }
            }
            return maxvalue;
        }
    }
}