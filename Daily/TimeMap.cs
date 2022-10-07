using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Daily
{

    /*
     * Ref: https://leetcode.com/problems/time-based-key-value-store/submissions/
     * LeetCode: 981. Time Based Key-Value Store
     * Date: 10/06/2022
     * Test case:
     * Time Complexity:O(log(n-k) + k)
     * Space Complexity:O(1)
     */

    public class TimeMap
    {
        public Dictionary<string, List<KeyValuePair<int, string>>> dataStore { get; set; }
        public TimeMap()
        {
            //note: the timestamp would be given in asc order, hence we can use BS
            dataStore = new Dictionary<string, List<KeyValuePair<int, string>>>();
        }

        void Set(string key, string value, int timestamp)
        {
            if (dataStore.ContainsKey(key))
            {
                var vals = dataStore[key];
                vals.Add(new KeyValuePair<int, string>(timestamp, value));
                //dataStore[key].Add(new KeyValuePair<int, string>(timestamp, value));
            }
            else
            {
                dataStore.Add(key, 
                    new List<KeyValuePair<int, string>>() { new KeyValuePair<int, string>(timestamp, value) });
            }
        }

        string Get(string key, int timestamp)
        {
            if (dataStore.ContainsKey(key)) {
                var currentVal = new KeyValuePair<int, string>();

                var valuesList = dataStore[key];
                int startIndex = 0;
                int endIndex = valuesList.Count-1;

                while (startIndex <= endIndex)
                {
                    
                    int median = (startIndex + endIndex) / 2;
                    if (valuesList[median].Key < timestamp)
                    {
                        currentVal = currentVal.Key > valuesList[median].Key ? currentVal : valuesList[median];
                        startIndex = median+1;
                    }
                    else if (valuesList[median].Key == timestamp)
                    {
                        return valuesList[median].Value;
                    }
                    else
                    {
                        endIndex = median - 1;
                    }
                }

                return currentVal.Value?? "";
            }
            return "";
        }

        public void Driver()
        {
            string retVal = "";
            Set("love", "high", 10);
            //retVal = Get("foo", 1);
            //retVal = Get("foo", 3);

            Set("love", "low", 20);
            retVal = Get("love", 5);
            retVal = Get("love", 10);

            Console.WriteLine("TimeMap:{0}", retVal);
        }
    }
}
