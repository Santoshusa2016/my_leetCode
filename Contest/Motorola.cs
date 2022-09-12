using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Contest
{
    internal class Motorola
    {
        public int MostFrequentEven(int[] nums)
        {
            Dictionary<int, int> container = new Dictionary<int, int>();

            //step 01: store the even nums in dict with count
            for (int i = 0; i < nums.Length; i++)
            {
                int reminder = nums[i] % 2;
                if (reminder == 0)
                {
                    if (container.ContainsKey(nums[i]))
                    {
                        int val = container[nums[i]];
                        container[nums[i]] = val + 1;
                    }
                    else
                    {
                        container.Add(nums[i], 1);
                    }
                }
            }

            //step 02: find the max of integer
            var retValues = container.OrderByDescending(a => a.Value).ThenBy(a => a.Key).FirstOrDefault();

            //step 03: if there are no values return -1
            if (retValues.Key == 0 & retValues.Value > 0)
                return 0;

            return retValues.Value == 0 ? -1 : retValues.Key;
        }

        /// <summary>
        /// testcases: abacaba, ssssss, "shkqbyutdvknyrpjof"
        /// problem: 2405. Optimal Partition of String
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        int MaxPartition(string s)
        {
            HashSet<char> unique = new HashSet<char>();
            int countSubSets = 0;
            for (int i = 0; i < s.Length; i++)
            {   
                if (unique.Contains(s[i]))
                {
                    countSubSets++;
                    unique.Clear();
                }
                unique.Add(s[i]);
            }
            return countSubSets+1;
        }



        /// <summary>
        /// test cases: [[1,3],[5,6],[8,10],[11,13]]->1
        /// [[5,10],[6,8],[1,5],[2,3],[1,10]] -> 3
        /// problem: 2406. Divide Intervals Into Minimum Number of Groups
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        int FindMinOverlapIntervals(int[][] intervals)
        {
            //step 01: sort train by arrival/ departure ascending (1,2 subscript)
            var trainArrivals = intervals.OrderBy(a => a[0]).Select(a => a[0]).ToArray();
            var trainDepartures = intervals.OrderBy(a => a[1]).Select(a => a[1]).ToArray();

            //step 02: create 2 pointer 1-startTime, 2-endTime
            int noOfPlatforms = 1;
            int startIndex, endIndex;
            startIndex = 1; endIndex = 0;

            while (startIndex < trainArrivals.Length
                && endIndex < trainDepartures.Length)
            {
                if (trainArrivals[startIndex] <= trainDepartures[endIndex])
                {
                    //step 03: if already there is train in platform add new platform.
                    noOfPlatforms++;
                    startIndex++;
                }
                else
                {
                    //step 04: if platform is available reuse it
                    endIndex++;
                    startIndex++;
                }
            }

            return noOfPlatforms;
        }

        int LengthOfLIS(int[] nums, int k)
        {
            List<int> LIS = Enumerable.Repeat(1, nums.Length).ToList();

            for (int i = (nums.Length - 2); i >= 0; i--)
            {
                int j = (nums.Length - 1);
                int tempval = LIS[i];
                while (j > i)
                {
                    if ((nums[j] > nums[i]) && (nums[j] - nums[i] <= k))
                    {
                        tempval = Math.Max(tempval, (LIS[i] + LIS[j]));
                    }
                    j--;
                }
                LIS[i] = tempval;
            }

            return LIS.Max(a => a);
        }

        public void Driver()
        {
            int maxLen = MaxPartition("ssssss");
            //int profit = LengthOfLIS(new int[] { 4, 2, 1, 4, 3, 4, 5, 8, 15 }, 3);

            var groups = new int[4][]
            {
                new int []{ 1, 3 },
                new int []{ 5, 6 },
                new int []{ 8, 10 },
                new int []{ 11, 13 }
            };
            //int minGroups = FindMinOverlapIntervals(groups);
        }

    }
}
