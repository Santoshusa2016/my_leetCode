public class MinimumRotatedArray
{
    public int FindMin(int[] nums) {
        return FindMin(nums, 0, nums.Length-1);
    }

    private int FindMin(int[] nums, int start, int end){
        int minValue = 0;
        bool minFound = false;

        if(minFound)
            return minValue;

        //base criteria
        if(start == end){
            return nums[start];
        }
        else{
            //index was out of range when comparing 2 elements
            int median = (start + end)/ 2;
            int left = FindMin(nums, start, median);
            int right = FindMin(nums, median + 1, end);
            if (right < left)
            {
                 //there are 2 portions of array, one on left which is sorted and one on right which is also sorted and has less value
                minFound = true;
                minValue = right;
            }
            else{
                 minValue = left;
            }
            return minValue;        
        }       
    }


   //This method using BS with Time complexity O(logN) using while loop
    public int FindMinWithBS(int[] nums){
        int left = 0, right = nums.Length - 1;
        int median;
        
        /*left<=right did not work, because when both are in same index the loops goes 
        into infinite*/
        while (left < right)
        {
            median = (left + right)/2;
            if(nums[median] > nums[right]){
                /*Because right < median we can skip median & check from median+1*/
                left = median + 1;
            }
            else{
                /*since median can also be least we make it = right and not median -1*/
                right = median;
            }            
        }
        return nums[right]; //you could also use left because both are same
    }
}

/*
Cases Tested: [4,5,6,7,0,1,2], [11,13,15,17]
Failed cases: [3,-1,4] Exp 4, Act 3
[-2,0,-1] Exp 0, Act 1
Hint: The idea is to find the pivot/median and determine which side could have the least element. If median is greater
than start then least is on right side.
*/
