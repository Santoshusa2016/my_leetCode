using System;
using System.Collections.Generic;
using System.Text;

namespace my_leetCode.Interview
{
    internal class sockMerchant
    {
        //ar = [1, 2, 1, 2, 1, 3, 2]
        public static int solve(int n, List<int> ar)
        {

            Dictionary<int, int> dictSocks = new Dictionary<int, int>();

            for (int i = 0; i < ar.Count; i++)
            {
                if (!dictSocks.ContainsKey(ar[i]))
                {
                    dictSocks.Add(ar[i], 1);
                }
                else
                {
                    dictSocks[ar[i]] = dictSocks[ar[i]] + 1;
                }
            }

            //dict (1,3) (2,3) (3,1)
            int counter = 0;
            foreach (var item in dictSocks)
            {
                int quotient = item.Value / 2;
                counter = Math.Max(counter, counter + quotient);
            }

            return counter;

        }
    }

}
