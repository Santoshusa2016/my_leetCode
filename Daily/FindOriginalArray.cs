using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/find-original-array-from-doubled-array/
     * LeetCode: 2007
     * Date: 09/15/2022
     * Test case:[1,3,4,2,6,8], [6,3,0,1], [1], [0,0,0,0]
     * Time Complexity:
     * Space Complexity:
     */
    internal class FindOriginalArray
    {
        int[] solve(int[] changed)
        {
            if (changed.Length % 2 == 1 || changed.Length < 2)
                return new int[0];

            //step 01: sort array asc to bring val first followed by their double
            Array.Sort(changed);

            //step 02: maintain list of items and their doubles with count
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < changed.Length; i++)
            {
                dic.TryAdd(changed[i], 0);
                dic[changed[i]]++;
            }

            List<int> res = new List<int>();
            //step 03: iterate over array and reduce count of item/ item double 
            for (int i = 0; i < changed.Length; i++)
            {
                if (dic[changed[i]] > 0)
                {
                    dic[changed[i]]--;
                    if (!dic.ContainsKey(changed[i] * 2) || dic[changed[i] * 2] == 0)
                        return new int[0];
                    else
                        dic[changed[i] * 2]--;
                    res.Add(changed[i]);
                }

            }

            return  res.ToArray();
        }

        public void Driver()
        {
            var retVal = solve(new int[] { 2, 1 });
            Console.WriteLine("FindOriginalArray:{0}", retVal.Count());
        }
    }
}
