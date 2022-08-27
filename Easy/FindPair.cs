using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Easy
{
    /*
     * https://www.geeksforgeeks.org/find-a-pair-with-the-given-difference/
     */
    public class findPair
    {
        /*
         * EXECUTIION time depends quadratically on length of the array
         * 
         */
        public bool Solve(int[] a, int n, int z)
        {

            // loop will execute n+1 times, because of i++ and i< check
            for (int i = 0; i < (n-1); i++)
                for (int j = i+1; j < n; j++)

                    // Idea is check how many times below code will be executed
                    if (a[i] + a[j] == z)
                        return true;

            return false;
        }

    }
}
