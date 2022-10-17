using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Contest
{
    internal class Contest315
    {
        public int FindMaxK(int[] nums)
        {
            Array.Sort(nums);
            int i = 0;
            int j = nums.Length-1;

            while (i<j)
            {
                int a = Math.Abs(nums[i]);
                int b = Math.Abs(nums[j]);
                if (nums[i] == -(nums[j])
                    || nums[j] == -(nums[i]))
                {
                    return a;
                }
                else if (a > b)
                {
                    i++;
                }
                else { 
                    j--;
                }
            }
            return -1;
        }

        public int CountDistinctIntegers(int[] nums)
        {
            HashSet<int> distIntegers = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int a = nums[i];
                distIntegers.Add(a);

                string stra = Convert.ToString(a);
                string rstra = ReverseNum(stra);
                int b = Convert.ToInt32(rstra);
                distIntegers.Add(b);
            }

            return distIntegers.Count;
        }

        private static string ReverseNum(string str)
        {
            char[] chars = new char[str.Length];
            for (int i = str.Length - 1, j = 0; i >= 0; --i, ++j)
            {
                chars[j] = str[i];
            }
            return new String(chars);
        }

        public bool SumOfNumberAndReverse(int num)
        {
            int i = 0;
            while (i <= num)
            {
                string rev = ReverseNum(i.ToString());
                int revInt = Convert.ToInt32(rev);
                if (i + revInt == num)
                    return true;
                else
                    i++;
            }
            return false;
        }

        public long CountSubarrays(int[] nums, int minK, int maxK)
        {
            int minIndex, maxIndex, bound, retVal = 0;
            List<List<int>> contSubArrays = new List<List<int>>();
            
            for (int i = 0; i < nums.Length; i++)
            {
                int tempMin, tempMax = 0;
                List<int> subArrays = new List<int>();

                if (nums[i] > maxK)
                    continue;

                tempMin = tempMax = nums[i];
                subArrays.Add(nums[i]);

                if (tempMin == minK && tempMax == maxK)
                    contSubArrays.Add(subArrays);

                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[j] > maxK)
                        break;

                    tempMin = Math.Min(tempMin, nums[j]);
                    tempMax = Math.Max(tempMax, nums[j]);
                    subArrays.Add(nums[j]);

                    if (tempMin == minK && tempMax == maxK)
                        contSubArrays.Add(subArrays);
                }
            }
            return contSubArrays.Count;
        }

        public void Driver()
        {
            //problem01:
            var inputReq01 = new int[] { -104, -449, -318, -930, -195, 579, -410, 822, -814, -388, -863, 174, -814, 919, -877, 993, 741, 741, -623, -4, -4, 542, 997, 239, 447, -317, 409, -487, -34, 6, -914, 607, -622, 915, 573, 666, -229, 165, 841, -820, 703 };
            int retVal01 = FindMaxK(inputReq01);
            Console.WriteLine("FindMaxK:{0}", retVal01);

            //problem02:
            var inputReq02 = new int[] { 1, 13, 10, 12, 31 };
            int retVal02 = CountDistinctIntegers(inputReq02);
            Console.WriteLine("CountDistinctIntegers:{0}", retVal02);

            //problem03:
            var inputReq03 = 63; //443, 63, 181
            bool retVal03 = SumOfNumberAndReverse(inputReq03);
            Console.WriteLine("SumOfNumberAndReverse:{0}", retVal03);


            //problem04: 1, 3, 5, 2, 7, 5
            var inputReq04 = new int[] { 1, 1, 1, 1 };
            var retVal04 = CountSubarrays(inputReq04,1,1);
            Console.WriteLine("CountSubarrays:{0}", retVal04);
        }
    }
}
