using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Examples
{
    /*
     * https://www.geeksforgeeks.org/counting-frequencies-of-array-elements/
     * count of items in array
     */
    internal class countFreq
    {
        public void solveV1(int[] arr, int n)
        {
            bool[] visited = new bool[n];

            // Traverse through array elements and count frequencies
            for (int i = 0; i < n; i++)
            {
                // Skip this element if already processed
                if (visited[i] == true)
                    continue;

                // Count frequency
                int count = 1;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        visited[j] = true;
                        count++;
                    }
                }
                Console.WriteLine(arr[i] + " " + count);
            }
        }

        public void solveV2(int[] arr, int n)
        {
            //auxillary space
            Dictionary<int, int> freq = new Dictionary<int, int>();

            // Traverse through array elements and count
            // frequencies
            for (int i = 0; i < n; i++)
            {
                if (freq.ContainsKey(arr[i]))
                {
                    freq[arr[i]] += 1;
                }
                else
                {
                    freq.Add(arr[i], 1);
                }
            }

            // Traverse through dictionary and print frequencies
            foreach (KeyValuePair<int, int> x in freq)
            {
                Console.WriteLine(x.Key + " " + x.Value);
            }
        }
    }
}
