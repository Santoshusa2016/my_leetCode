using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static leetCode.Daily.Tree2str;

namespace leetCode.Contest
{
    /*
     * Ref: https://leetcode.com/contest/weekly-contest-312/
     * Date: 09/24/2022
     * Problems:
     * 6188. Sort the People
     * 2419. Longest Subarray With Maximum Bitwise AND
     * 2420. Find All Good Indices
     * 2421. Number of Good Paths
     */
    internal class Contest312
    {
        public string[] SortPeople(string[] names, int[] heights)
        {

            if (names.Length <= 1)
            {
                return names;
            }
            Dictionary<int, int> heightDict = new Dictionary<int, int>();
            string[] sortedNames = new string[names.Length];
            int index = 0;

            for (int i = 0; i < heights.Length; i++)
            {
                heightDict.Add(i, heights[i]);
            }

            foreach (var item in heightDict.OrderByDescending(a => a.Value))
            {
                sortedNames[index] =  names[item.Key];
                index++;
            }
            return sortedNames;
        }

        public int LongestSubarray(int[] nums)
        {
            //https://www.geeksforgeeks.org/bitwise-operators-in-c-cpp/
            //step 01: get the max value from nums.
            var max = nums.Max();

            var length = 0;
            var result = 0;

            //step 02: iterate over items and find numbers equal to max value
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == max)
                    length++;
                else
                    length = 0;
                result = Math.Max(result, length);
            }
            return result;
        }

        public IList<int> GoodIndicesv1(int[] nums, int k)
        {
            //Timelimit exceeded
            IList<int> vals = new List<int>();
            if (nums.Length < (2 * k + 1))
                return vals;

            int startIndex, endIndex;
            int midPointer = k;
            startIndex = 0;
            endIndex = k * 2;

            while (endIndex<nums.Length)
            {
                int leftCounter, rightCounter;
                leftCounter = rightCounter = 1;

                while (nums[startIndex+1] <= nums[startIndex]
                    && leftCounter < k)
                {
                    leftCounter++;
                    startIndex++;
                }
                

                while (nums[endIndex] >= nums[endIndex - 1]
                    && rightCounter < k)
                {
                    rightCounter++;
                    endIndex--;
                }

                if (rightCounter == k && leftCounter == k)
                    vals.Add(midPointer);


                //reset the pointers
                midPointer++;
                startIndex = midPointer - k;
                endIndex = midPointer + k;
            }

            return vals;

        }


        public IList<int> GoodIndices(int[] nums, int k)
        {
            IList<int> retVal = new List<int>();
            if (nums.Length < (2 * k + 1))
                return retVal;
            
            IList<int> leftDescVals = Enumerable.Repeat(1, nums.Length).ToList();
            IList<int> rightAscVals = Enumerable.Repeat(1, nums.Length).ToList();
            
            //prefix sum
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] <= nums[i - 1])
                    leftDescVals[i] = leftDescVals[i-1] + 1;
            }

            //suffix sum
            for (int i = nums.Length-2; i >=0; i--)
            {
                if (nums[i] <= nums[i+1])
                    rightAscVals[i] = rightAscVals[i + 1] + 1;
            }

            for (int i = k; i < nums.Length-k; i++)
            {
                if (leftDescVals[i - 1] >= k && rightAscVals[i + 1] >= k)
                    retVal.Add(i);

            }

            return retVal;

        }


        public void Driver()
        {
            GoodIndices(new int[] { 2, 1, 1, 1, 3, 4, 1 }, 2);            
        }

        void TryBitOps()
        {

            int a = 6;
            int b = 2;

            Console.WriteLine("bit->{0}:{1}, {2}:{3}"
                ,a , Convert.ToString(a, 2)
                ,b, Convert.ToString(b, 2));

            int var1 = a | b;
            Console.WriteLine("bitwise OR:{0}, {1}", var1,
               Convert.ToString(var1, 2));

            int var2 = a & b;
            Console.WriteLine("bitwise AND:{0}, {1}", var2,
                Convert.ToString(var2, 2));

            int var3 = a ^ b;
            Console.WriteLine("bitwise XOR:{0}, {1}", var3,
                Convert.ToString(var3, 2));
        }
    }
}
