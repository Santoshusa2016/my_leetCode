using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://practice.geeksforgeeks.org/problems/minimum-cost-to-cut-a-board-into-squares/1
     * LeetCode: 967
     * hint:
     * Date: 09/03/2022
     * Test case: [3,1] [2,0], [3,7]
     * Time Complexity: O(9*2^N)
     * Space Complexity: O(2^N)
     */
    internal class NumsSameConsecDiff
    {
        #region failed
        int[] Solve_failed(int n, int k)
        {
            //step 01: find pair of 2 numbers whose diff is k
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            List<int> nums = new List<int>();
            int pair1, pair2;
            pair1 = k;

            while (pair1 <= 9)
            {
                pair2 = pair1 - k;

                //step 02: based on count of digits in n, repeat the pairs 
                int tmpNum = 0;
                tmpNum = GetNum(n, pair1, pair2);
                if (tmpNum != 0) nums.Add(tmpNum);

                //step 03: Repeat step 02 in reverse order 
                tmpNum = 0;
                tmpNum = GetNum(n, pair2, pair1);
                if (tmpNum != 0) nums.Add(tmpNum);

                pair1++;
            }
            return nums.Distinct().ToArray();
        }

        static int GetNum(int n, int val1, int val2)
        {
            int tempPointer = 1;
            int tmpNum = 0;
            int val = val1;
            while (tempPointer <= n)
            {
                if (val == 0 && tmpNum == 0) break;
                tmpNum = tmpNum * 10 + val;

                if (val == val1)
                    val = val2;
                else
                    val = val1;
                tempPointer++;
            }

            return tmpNum;
        }
        #endregion

        int[] Solve(int n, int k)
        {
            if (n == 1)
                return new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            List<int> numbers = new List<int>();
            //step 01: since 1 digit cannot be 0, the digits possible are 1-9
            for (int i = 1; i <= 9; i++)
            {
                DFS(i, (n - 1), k, numbers);
            }

            return numbers.ToArray();
        }

        void FindNumber(int num, int noOfDigits, int diff, ref List<int> numbers)
        {
            if (CountDigit(num, noOfDigits) == true)
            {
                if (!numbers.Contains(num)) numbers.Add(num);
                return;
            }

            //step 02: given 1st digit num iterate over digits 0-9 to find diff
            for (int i = 0; i <= 9; i++)
            {
                int lastDigit = num % 10;
                if (Math.Abs(lastDigit - i) == diff)
                {
                    //step 03: continue the DFS for next number by recursive alg
                    num = num * 10 + i;
                    FindNumber(num, noOfDigits, diff, ref numbers);

                    /*step 04: remove the last digit added & continue to explore remaining num ex:[2,1]
                     *Ex: input:[2,1]: when 1st digit is 1 the next set can be [1,0][1,2]
                     */
                    num = num / 10;
                }
            }
        }

        bool CountDigit(int num, int noOfDigits)
        {
            int count = 0;
            while (num > 0)
            {
                count++;
                num = num / 10;
            }
            return (count == noOfDigits);
        }
       
        void DFS(int num, int noOfNodes, int diff, List<int> nums)
        {
            //base condition
            if (noOfNodes == 0)
            {
                if (!nums.Contains(num)) nums.Add(num);
                return;
            }

            //decision tree
            int lastDigit = num % 10;
            int leftNode = lastDigit - diff;
            if(leftNode >= 0 && leftNode <= 9)
            {
                DFS((num*10+leftNode), (noOfNodes-1), diff, nums);
            }
            
            int rightNode = lastDigit + diff;
            if (rightNode >= 0 && rightNode <= 9)
            {
                DFS((num * 10 + rightNode), (noOfNodes - 1), diff, nums);
            }
        }

        public void Driver(int n, int k)
        {
            var nums = Solve(2, 0);
        }
    }
}
