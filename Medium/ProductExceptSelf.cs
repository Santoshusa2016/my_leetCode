public class ProductExceptSelf
{
    /*
    Explanation: The logic is to use determine Prefix, Suffix of array.
    Given the index, in output mutiply the prev * suffix value which is required for that position
    */
    public int[] GetProductExceptSelf(int[] nums){
        //hint: Prefix Sum and Suffix Sum in Arrays
        
        int[] outputArray = new int[nums.Length];
        outputArray[0] = 1; 
        for (int i = 1; i < nums.Length; i++)
        {      
            //Prefix-Product till index i     
            outputArray[i] = outputArray[i-1] * nums[i-1];
        }

        int tempMultiplier = 1;
        for (int i = nums.Length-2; i >= 0; i--)
        {
            //Suffix Product till the index i, multiplied with prefix determined in earlier loop
            outputArray[i] =  outputArray[i] * (tempMultiplier * nums[i+1]);
            tempMultiplier = tempMultiplier * nums[i+1];
        }

        return outputArray;
    }

    private void PrefixProduct(int[] nums){
        int[] outputArray = new int[nums.Length];
        outputArray[0] = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            outputArray[i] = outputArray[i-1]*nums[i];
        }

    }

    private void SuffixProduct(int[] nums){
        int[] outputArray = new int[nums.Length];
        outputArray[nums.Length-1] = nums[nums.Length-1];

        for (int i = (nums.Length-2); i >=0; i--)
        {
            outputArray[i] = outputArray[i+1]*nums[i];
        }
    }
    
}

/* Example
Input: nums = [1,2,3,4]
Output: [24,12,8,6]
*/