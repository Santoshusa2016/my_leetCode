using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/minimum-difficulty-of-a-job-schedule/
    * LeetCode: 1335. Minimum Difficulty of a Job Schedule
    * hint: #hard, #dp, #split
    * Date: 10/10/2022
    * Company: amazon
    * Test case: [6,5,4,3,2,1], d = 2; [9,9,9], d = 4
    * https://medium.com/@chuncaohenli/1335-minimum-difficulty-of-a-job-schedule-5ee30d10a88b
    * https://wentao-shao.gitbook.io/leetcode/dynamic-programming/qu-jian-xing/1335.minimum-difficulty-of-a-job-schedule
    * Time Complexity: 
    * Space Complexity:
    */

    internal class MinDifficulty
    {
        int solve(int[] jobDifficulty, int d)
        {
            int arrayCount = jobDifficulty.Length;
            if (arrayCount < d)
                return -1;
            else if (arrayCount == d)
                return jobDifficulty.Sum();
            else
            {
                int[] dailyJobs = new int[d];
                int jobNum = arrayCount - 1;

                for (int i = d - 1; i >= 0; i--)
                {
                    dailyJobs[i] = jobDifficulty[jobNum];
                    jobNum--;
                }

                int tempMax = jobDifficulty[0];
                for (int i = 1; i < arrayCount - (d - 1); i++)
                {
                    tempMax = Math.Max(tempMax, jobDifficulty[i]);
                }

                dailyJobs[0] = tempMax;
                return dailyJobs.Sum();
            }

        }

        int solveViaMemoization(int[] jobDifficulty, int d)
        {
            int arrayCount = jobDifficulty.Length;
            if (arrayCount < d)
                return -1;
            else if (arrayCount == d)
                return jobDifficulty.Sum();

            //d+1: this is because we are going to save value against day based index
            int[,] memo = new int[d+1, jobDifficulty.Length];

            //set default value to -1
            for (int i = 0; i < memo.GetLength(0); i++)
            {
                for (int j = 0; j < memo.GetLength(1); j++)
                {                     
                    memo[i, j] = -1;
                }
            }

            //we are going to split at each index to create subarray & determine the min job schedule
            return dfs(jobDifficulty, d, memo, 0);
        }

        int dfs(int[] jobDifficulty, int d, int[,] memo, int idx)
        {
            //base case:only 1 day left,take max of remaining tasks/idexs
            if (d == 1)
            {
                int maxVal = jobDifficulty.Skip(idx - 1).Max();
                return maxVal > 0 ? maxVal : 0;
            }

            //dynammic programming
            if (memo[d, idx] != -1)
            {
                return memo[d, idx];
            }

            int currentD = int.MinValue; 
            int res = int.MaxValue;
            for (int i = idx; i <= jobDifficulty.Length-d; i++)
            {
                currentD = Math.Max(currentD, jobDifficulty[i]);
                res = Math.Min(res, currentD + dfs(jobDifficulty, d - 1, memo, i+1));
            }
            memo[d, idx] = res;
            return res;
        }

        int solveViaDp(int[] jobDifficulty, int d)
        {
            int arrayCount = jobDifficulty.Length;
            if (arrayCount < d)
                return -1;
            else if (arrayCount == d)
                return jobDifficulty.Sum();

            //+1: because we need default for day 0;
            int[,] dp = new int[d + 1, arrayCount + 1];

            //step01: create 2D matrix and set default value to Max
            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    dp[i, j] = int.MaxValue;
                }
            }
            dp[0, 0] = 0;


            //step02: iterate over each day
            for (int day = 1; day <= d; day++)
            {
                //step03: iterate over tasks which can be done on each selected day.
                for (int task = day; task <= arrayCount; task++)
                {
                    int local_Max = jobDifficulty[task - 1];

                    //step04: loop thru all tasks done to find same day max.
                    for (int s = task; s >= day; s--)
                    {
                        //same day tasks: max
                        local_Max = Math.Max(local_Max, jobDifficulty[s - 1]);
                        
                        //check prev day task
                        if(dp[day - 1,s - 1] != int.MaxValue)
                        {
                            //job schedule: min
                            dp[day,task] = Math.Min(dp[day,task]
                                , dp[day - 1,s - 1] + local_Max);
                        }

                    }
                }
            }
            return dp[d, arrayCount];

        }

        public void Driver()
        {
            //6, 5, 4, 3, 2, 1:2; 
            var inputReq = new int[] { 7, 1, 7, 1, 7, 1 };
            int retVal = solveViaDp(inputReq, 3);
            Console.WriteLine("MinDifficulty:{0}", retVal);
        }
    }
}
