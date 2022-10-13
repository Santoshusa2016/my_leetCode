using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Arrays
{
    internal class GroupAnagrams
    {
        IList<IList<string>> solve(string[] strs)
        {
            IList<IList<string>> retVal = new List<IList<string>>();
            if (strs.Length == 0)
            {
                return retVal;
            }

            Dictionary<string, List<string>> anagrams = 
                new Dictionary<string, List<string>>();

            foreach (var str in strs)
            {
                string key = string.Concat(str.OrderBy(a => a));
                if (anagrams.ContainsKey(key))
                {
                    anagrams[key].Add(str);
                }
                else
                {
                    anagrams.Add(key, new List<string>(new string[] { str }));
                }
            }

            foreach (var item in anagrams)
            {
                retVal.Add(item.Value);
            } 
            return retVal;
        }
        
        public void Driver()
        {
            var inputVal = new string[]
            {
                //"eat", "tea", "tan", "ate", "nat", "bat"
                "aa"
            };
            solve(inputVal);

            Console.WriteLine("GroupAnagrams");
        }
    }
}
