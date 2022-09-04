using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Examples
{
    /*
     * https://www.geeksforgeeks.org/find-a-pair-with-the-given-difference/
     */
    public class findPair
    {
        /*
         * Time complexity: O(n^2)
         */
        public bool Solve(int[] a, int n, int z)
        {
            // loop will execute n+1 times, because of i++ and i< check
            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    // Idea is check how many times below code will be executed
                    if (a[i] + a[j] == z)
                        return true;

            return false;
        }

        // The function assumes that the array is sorted
        bool SolveV2(int[] arr, int size, int n)
        {
            Dictionary<int, int> mpp = new Dictionary<int, int>();

            // Traverse the array
            for (int i = 0; i < size; i++)
            {
                // Update frequency of arr[i]
                mpp[arr[i]] = mpp.GetValueOrDefault(arr[i], 0) + 1;

                // Check if any element whose frequency
                // is greater than 1 exist or not for n == 0
                if (n == 0 && mpp[arr[i]] > 1)
                    return true;
            }

            // Check if difference is zero and
            // we are unable to find any duplicate or
            // element whose frequency is greater than 1
            // then no such pair found.
            if (n == 0)
                return false;

            for (int i = 0; i < size; i++)
            {
                if (mpp.ContainsKey(n + arr[i]))
                {
                    Console.WriteLine("Pair Found: (" + arr[i] + ", " +
                                +(n + arr[i]) + ")");
                    return true;
                }
            }
            Console.WriteLine("No Pair found");
            return false;
        }

    }
}
