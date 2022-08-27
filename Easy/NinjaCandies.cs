using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace leetCode.Easy
{
    /*
     * Array[2,5,1,7,4], X=4. If sum(subarray L)<=X then add length.
     * [2 5 1 7 4] 5, 4
     * [1 2] 2, 3
     */
    internal class NinjaCandies
    {
        public int Solve(int[] a, int len, int targ)
        {
            /*At each index < targ -> continue DFS
             * if index> targ  targbreak & move to next Index
             */
            int arrayLen = 0;
            for (int i = 0; i < len; i++)
            {
                if (a[i] > targ)
                    continue;
                
                arrayLen++;
                int subArrayLen=0;
                
                for (int j = i+1; j < len; j++)
                {
                    if (a[j] > targ)
                        break;
                    subArrayLen++;
                }

                arrayLen = arrayLen + 
                    (subArrayLen>0 ? ++subArrayLen : 0);
            }

            return arrayLen;
        }
    }
}
