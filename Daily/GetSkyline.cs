using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/the-skyline-problem/submissions/
     * LeetCode: 218. The Skyline Problem 
     * Date: 10/04/2022
     * Test case:
     * Failed:[[2,9,10],[9,12,15]], [[0,3,3],[1,5,3],[2,4,3],[3,7,3]]
     * Time Complexity:
     * Space Complexity:
     */
    internal class GetSkyline
    {
        IList<IList<int>> solvev1(int[][] buildings)
        {
            IList<IList<int>> height = new List<IList<int>>();
            Dictionary<int, int> stack = new Dictionary<int, int>();
            SortedDictionary<int, int> walls = new SortedDictionary<int, int>();

            for (int i = 0; i < buildings.Length; i++)
            {
                //condition01: if 2 walls are built on same point break/remove                
                AddModifyDict(buildings[i][0], buildings[i][2], walls);
                AddModifyDict(buildings[i][1], buildings[i][2], walls);
            }

            var prev = walls.First();
            stack.Add(prev.Key, prev.Value);
            height.Add(new List<int>() { prev.Key, prev.Value });
            KeyValuePair<int, int> current;

            for (int i = 1; i < walls.Count; i++)
            {
                current = walls.ElementAt(i);

                if (stack.ContainsValue(current.Value))
                {
                    //creating the rightside wall.
                    var item = stack.First(a => a.Value == current.Value);
                    stack.Remove(item.Key);

                    if (current.Value > prev.Value)
                    {
                        //intersection point.
                        height.Add(new List<int>() { current.Key, prev.Value });
                    }
                    else if (current.Value == prev.Value)
                    {
                        //final terminating wall
                        height.Add(new List<int>() { current.Key, 0 });
                        prev = new KeyValuePair<int, int>(0, 0);
                    }
                }
                else
                {
                    stack.Add(current.Key, current.Value);
                    if (current.Value > prev.Value)
                    {
                        //new wall, bigger than prev
                        height.Add(new List<int>() { current.Key, current.Value });
                    }
                    prev = current;
                }

            }

            return height;

            static void AddModifyDict(int key, int val, SortedDictionary<int, int> walls)
            {
                bool keyExist = walls.ContainsKey(key);
                if (keyExist)
                {
                    int existVal = walls[key];
                    if (existVal == val)
                    {
                        walls.Remove(key);
                    }
                    else if (existVal < val)
                    {
                        walls[key] = val;
                    }
                }
                else
                    walls.Add(key, val);
            }
        }

        public IList<IList<int>> solve(int[][] buildings)
        {
            var height = new List<IList<int>>();


            // collect all vertcal building edges
            for (int i = 0; i < buildings.Length; i++)
            {
                // left building edge (make it NEGATIVE so we can identify it first)
                height.Add(new int[] { buildings[i][0], -buildings[i][2] });
                // right building edge
                height.Add(new int[] { buildings[i][1], buildings[i][2] });
            }

            height.Sort((a, b) =>
            {
                // sort by vertcal building edge order
                if (a[0] != b[0])
                {
                    return a[0].CompareTo(b[0]);
                }
                // if 2 buiding share edge let left buiding edge go first (because it is negative)
                return a[1].CompareTo(b[1]);
            });



            var result = new List<IList<int>>();

            // note that the dictionary is MAX heap so that the first is the fallest            
            var sd = new SortedDictionary<int, int>(Comparer<int>.Create((a, b) => -a.CompareTo(b)));

            sd.Add(0, 0);
            var pre = 0;
            // for each buiding edge in order left to right
            foreach (var h in height)
            {
                // if this is left edge
                if (h[1] < 0)
                {
                    // store height as key, because height determines the edges of wall
                    if (!sd.ContainsKey(-h[1]))
                    {
                        sd[-h[1]] = 0;
                    }

                    // increment height counter based on number of walls built to that height
                    sd[-h[1]]++;
                }
                else // if this is right edge
                {
                    // when right wall is found, reduce the wall count at that height
                    sd[h[1]]--;

                    // remove it for already passed any with that height
                    if (sd[h[1]] <= 0)
                    {
                        sd.Remove(h[1]);
                    }
                }

                // get the tallest so far
                int cur = sd.First().Key;
                if (pre != cur)
                {
                    // record it
                    result.Add(new int[] { h[0], cur });
                    pre = cur;
                }
            }
            return result;
        }

        public void Driver()
        {
            var inputVal = new int[][]
            {
                new int []{2, 9, 10 },
                new int []{3, 7, 15 },
                new int []{5, 12, 12 },
                new int []{15, 20, 10 },
                new int []{19, 24, 8 }

                //new int []{0,2,3 },
                //new int []{ 2, 5, 3 }

                //new int []{1,2,1 },
                //new int []{ 1, 2, 2 },
                //new int []{ 1, 2, 3 }


                //new int []{ 0,3,3 },
                //new int []{ 1,5,3 },
                //new int []{ 2, 4, 3 },
                //new int []{ 3, 7, 3 }
            };

            var retVal = solve(inputVal);
            Console.WriteLine("GetSkyline");
        }
    }
}
