using System;
using System.Collections.Generic;
using System.Text;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/where-will-the-ball-fall/submissions/
    * LeetCode: 1706. Where Will the Ball Fall
    * Tag: #dfs, #dp, #matrix, #medium, #simulation
    * Company:
    * Date: 11/01/2022
    * Test case:
    * Time Complexity: 
    * Space Complexity:
    */

    internal class FindBall
    {
        public int[] solveV1(int[][] grid)
        {
            int rowcount = grid.Length;
            int colcount = grid[0].Length;
            int[] ans = new int[colcount];
            for (int j = 0; j < colcount; j++)
            {
                ans[j] = dfs(0, j, grid);
            }
            return ans;
        }

        private int dfs(int a, int b, int[][] grid)
        {
            //base criteria:
            if (a >= grid.Length)
            {
                return b;
            }
            
            if (grid[a][b] == 1
                && b+1 < grid[0].Length
                && grid[a][b+1]==1) 
            {
                return dfs(a + 1, b + 1, grid);
            }
            else if (grid[a][b] == -1
                && b - 1 >=0
                && grid[a][b - 1] == -1)
            {
                return dfs(a + 1, b - 1, grid);
            }
            else
            {
                return -1;
            }
        }

        public int[] solvev2(int[][] grid)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;
            var result = new int[cols];

            //step01: iterate over each cols
            for (var j = 0; j < cols; j++)
            {
                var curr = j;

                //step02: iterate over each rows
                for (var i = 0; i < rows; i++)
                {
                    if (grid[i][curr] == 1)
                    {
                        //step03: when rightmost col or opp direct node is met, break
                        if (curr == cols - 1 || grid[i][curr + 1] == -1)
                        {
                            result[j] = -1;
                            break;
                        }
                        curr++;
                    }
                    else
                    {
                        //step04: when leftmost col or opp direct node is met, break
                        if (curr == 0 || grid[i][curr - 1] == 1)
                        {
                            result[j] = -1;
                            break;
                        }
                        curr--;
                    }
                }

                if (result[j] == 0)
                {
                    //step05: update exit colmn 
                    result[j] = curr;
                }
            }

            return result;
        }

        public void Driver()
        {
            var inputArray = new int[][]
            {
                //new int[]{1, 1, 1, -1, -1 },
                //new int[]{1, 1, 1, -1, -1},
                //new int[]{-1, -1, -1, 1, 1},
                //new int[]{1, 1, 1, 1, -1},
                //new int[]{-1, -1, -1, -1, -1}

                new int[]{1,1,1,1,1,1},
                new int[]{ -1, -1, -1, -1, -1, -1 },
                new int[]{1,1,1,1,1,1},
                new int[]{ -1, -1, -1, -1, -1, -1 }
            };
            var retVal = solveV1(inputArray);
            Console.WriteLine("FindBall");
        }
    }
}
