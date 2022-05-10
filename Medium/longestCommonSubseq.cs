using System;


//Hint Dynamic Programming, Binary Search
/*
https://github.com/mission-peace/interview/wiki
Tushar: [3,4,-1,0,6,2,3], [2,5,1,8,3]
(Hint: Start the seq with first element j and next element i)
Neetcode: [1,2,4,3]
Failed cases: [0,1,0,3,2,3]
*/
public class LongestCommonSubseq {
    public int GetLongestCommonSubseq(string text1, string text2){
        //memoize (Storing result of recursion is called DP)
        int[,] memoizeArray = new int[(text1.Length + 1), (text2.Length + 1)];
        int maxValue = 0;

        //Loop starts from end, matrix filled from begin
        for (int i = 1; i <= text1.Length; i++)
        {
            for (int j = 1; j <=text2.Length ; j++)
            {
                if (text1[i-1] == text2[j-1]){
                   //subSeq.Add(text1[i-1]);
                   memoizeArray[i,j] = 1 + (memoizeArray[i-1, j-1]);
                }
                else{
                   memoizeArray[i,j] = Math.Max(memoizeArray[i-1, j],memoizeArray[i, j-1]); 
                }
                maxValue = memoizeArray[i,j]>maxValue? memoizeArray[i,j] :maxValue;  
            }                  
        }

        //Find common sub sequence from matrix

        return maxValue; //Following Kadens rules in multi dimension

    }

    
}