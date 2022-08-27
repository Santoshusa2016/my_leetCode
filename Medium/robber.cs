//Stickler Thief - Maximum sum subsequence Non Adjacent
using System;

 /*
Problem 22 Failed Cases:  {1}, {1,2}, {2,6,2}, {1,2,2,4}, {2,1,1,2}
Edge cases: Array 1, 0

Problem 23 TestCases: {2,3,2}, {1,2,3,1}
 */

class SticklerThief
{
   
public int FindMaxSum(int[] arr, int n){       
 /*The idea is to determine what maximum amount a robber can steal at given point.*/
        int temp = 0;
        if(n == 0) return temp;
        if(n ==1)return arr[0];

        if(n > 0){
                int rob1=0, rob2 = arr[0], i = 0;                
                for (i = 1; i < n; i++)
                {
                    temp = Math.Max(arr[i]+rob1 , rob2);
                    rob1 = rob2;
                    rob2 = temp;
                }

                /* return max of incl and excl */
                temp = Math.Max(rob1, rob2);
        }
        return temp;
}

public int FindMaxSum(int[] arr){       
 /*The logic is to rob once without 1 house and once without last house 
 The logic to rob without 1 & last house wont work because, if you choose either 2/ last house 
 you cannot choose 1 or last again since they are adjacent
 */
        int n = arr.Length;
        if(n == 0) return 0;
        if(n ==1)return arr[0];
        if (n == 2) return Math.Max(arr[0], arr[1]);
        if (n == 3) return Math.Max(Math.Max(arr[0], arr[1]), arr[2]);
        
        //Rob 1 house, skip last house
        int rob1 = robHouse(arr, 0, n-1);
        int rob2 = robHouse(arr, 1, n);

        return Math.Max(rob1, rob2);

}
public int robHouse(int[] arr, int startIndex, int endIndex){

        int rob1=0, rob2 = arr[startIndex], i = 0, temp = 0;                
        for (i = startIndex + 1; i < endIndex; i++)
        {
                temp = Math.Max(arr[i]+rob1 , rob2);
                rob1 = rob2;
                rob2 = temp;
        }
        return Math.Max(rob1, rob2);
}


//Failed Submissions:
/*
Cases: [1,2,3,1], [1,3,1,3,100], [1,2,1,1]
Reason: The logic was more like add even and odd position numbers and return max
*/
  public int Rob(int[] arr) {
        int n = arr.Length;        
        int include=arr[0], exclude = 0, i=0, temp = 0;
        
        for (i = 1; i < n-1; i++)
        {
            temp = include;
            include = (arr[i] + exclude);
            exclude = temp;
        } 
        /* return max of incl and excl */
        return Math.Max(include, exclude);
        
    }

}