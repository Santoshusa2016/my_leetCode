using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/max-points-on-a-line/description/
    * LeetCode:149. Max Points on a Line
    * Tag: #hard, #maths, #slope
    * Company:
    * Date: 01/08/2023
    * Time Complexity: 0(N^2)
    * Space Complexity:O(1)
    */
    internal class MaxPoints
    {
        public int solve(int[][] points)
        {
            int maxPoint = 0;
            Dictionary<decimal, int> maxPoints = new Dictionary<decimal, int>();
            for (int i = 0; i < points.Length - 1; i++)
            {
                decimal slope = 0;
                decimal x1 = points[i][0];
                decimal y1 = points[i][1];

                for (int j = i + 1; j < points.Length; j++)
                {
                    decimal x2 = points[j][0];
                    decimal y2 = points[j][1];

                    decimal a =  y2 - y1;
                    decimal b =  x2 - x1;
                    if (b != 0)
                        slope = a / b;
                    else
                        slope = int.MaxValue;
                   
                    if (maxPoints.ContainsKey(slope))
                        maxPoints[slope] += 1;
                    else
                        maxPoints.Add(slope, 1);

                    maxPoint = Math.Max(maxPoint, maxPoints[slope]);

                }
                maxPoints.Clear();
            }

            return maxPoint + 1;
        }

        public void Driver()
        {
            //[[1,0],[0,0]]
            //[[0,0],[4,5],[7,8],[8,9],[5,6],[3,4],[1,1]]
            //[[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]

            var points = new int[6][];
            points[0] = new int[2] { 1, 1 };
            points[1] = new int[2] { 3, 2 };
            points[2] = new int[2] { 5, 3 };
            points[3] = new int[2] { 4, 1 };
            points[4] = new int[2] { 2, 3 };
            points[5] = new int[2] { 1, 4 };

            //var points = new int[2][];
            //points[0] = new int[2] { 1, 0 };
            //points[1] = new int[2] { 0, 0 };

            int retVal = solve(points);
            Console.WriteLine($"MaxPoints:{retVal}");
        }
    }
}
