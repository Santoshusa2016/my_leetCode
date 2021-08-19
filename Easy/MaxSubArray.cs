using System;

public class MaxSubArray
{


    //Dynammic Programming
     public int GetMaxSubArrayKadens(int[] nums){
         if(nums.Length == 0) return 0;
        int prevMax, maxValue;
        prevMax = maxValue = nums[0];        
        for (int i = 1; i < nums.Length; i++)
        {
            prevMax = Math.Max((nums[i]+prevMax), nums[i]);
            maxValue = prevMax > maxValue ? prevMax: maxValue;
        }
        return maxValue;
    }

    /* Divide and Conquer - recurrsion
    Failed Cases:
    [8,-19,5,-4,20] -> Exp:21 Act: 20 (Instead of counting Left/Right I was getting max
    OF left or right by using comparison)
    [-2,3,0,2,-2,3] -> Exp:6 Act:5: (Since we were stopping when sum decreased we never check 
    if there is any higher value after the decrease. This is why we need to find max and not stop when 
    )
    */
    public int GetMaxSubArrayDC(int[] nums){
        return FindMax(0, (nums.Length - 1), nums);
    }

    public int FindMax(int startIndex, int endIndex, int[] nums){      
        if (startIndex != endIndex) 
        {
            int median = (startIndex + endIndex)/2;
            int a, b, c;
            Console.WriteLine("FindMax startIndex:{0},endIndex:{1}, median:{2}", startIndex, endIndex, median);

            a = FindMax(startIndex, median, nums);
            b = FindMax(median + 1, endIndex, nums);            
            c = FindCrossMax(startIndex, median, endIndex, nums);
            Console.WriteLine("FindMax a:{0}, b:{1}, Max:{2}", a, b, c);
            return Math.Max(Math.Max(a,b), c);
        }
        else{
            return nums[startIndex]; 
        }
    }

    public int FindCrossMax(int startIndex, int median, int endIndex, int[] nums){
        int leftMax = nums[median];
        int rightMax = nums[median+1];
        int tempMax = leftMax;
        for (int i = (median -1); i >= startIndex; i--)
        {
            // if(leftMax > (leftMax + nums[i]))
            // break;
            // else
            tempMax += nums[i];
            leftMax = (leftMax > tempMax) ? leftMax : tempMax;
        }

        tempMax = rightMax;
        for (int i = (median+2); i <= endIndex; i++)
        {
            // if(rightMax > (rightMax + nums[i]))
            // break;
            // else
            tempMax += nums[i];
            rightMax = (rightMax > tempMax) ? rightMax : tempMax;
        }

        return leftMax+rightMax;
    }

    //Brute force - Submission 01
    //Failed -1, [-2,-1]
    public int GetMaxSubArrayValueOpt01(int[] nums){
        int maxvalue = 0;
        if(nums.Length == 1){
            return nums[0];
        }
        else if (nums.Length == 0){
            return 0;
        }
        else{            
            for (int i = 0; i < nums.Length; i++)
            {
                int tempMax , tempSum ;
                tempMax = tempSum = nums[i];
                if (i < nums.Length-1)
                {
                    for (int j = i+1; j < nums.Length; j++)
                    {
                    tempSum = tempSum + nums[j];
                    tempMax = tempMax > tempSum ? tempMax: tempSum;
                    }
                }
                maxvalue = maxvalue > tempMax ? maxvalue: tempMax;
            }
        }
        return maxvalue;
    }
}

/*
Cases Tested: [-2, 1, -3, 4, -1, 2, 1, -5, 4], [5,4,-1,7,8]
Failed cases: [8,-19,5,-4,20] ,[-2,3,0,2,-2,3]
*/
