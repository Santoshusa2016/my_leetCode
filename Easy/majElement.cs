using System.Collections.Generic;
using System.Linq;

namespace leetCode.Easy
{
    /*
    * Question: https://leetcode.com/problems/majority-element/
    * Hint:
    * Test cases:
    * Failed cases:
    * Explain:
    */
    class MajorityElement
    {
        public int majorityElement(List<int> A)
        {

            int floor = A.Count / 2;
            int tempValue;
            Dictionary<int, int> dictCounter = new Dictionary<int, int>();

            for (int i = 0; i <= A.Count - 1; i++)
            {
                if (dictCounter.ContainsKey(A[i]))
                {
                    tempValue = dictCounter[A[i]];
                    dictCounter[A[i]] = tempValue + 1;
                }
                else
                {
                    dictCounter.Add(A[i], 1);
                }
                tempValue = 0;
            }

            int maxKey = dictCounter.OrderByDescending(i => i.Value).First().Key;
            return maxKey;
        }

        //Proposed soln
        public int majorityElement02(List<int> A)
        {

            int count = 1;
            int element = A[0];

            for (int i = 1; i < A.Count; i++)
            {
                if (A[i] == element)
                {
                    count++;
                }
                else
                {
                    count--;
                }

                if (count == 0)
                {
                    element = A[i];
                    count++;
                }
            }

            return element;
        }

    }
}