using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/nearest-exit-from-entrance-in-maze/
    * LeetCode:1926. Nearest Exit from Entrance in Maze
    * Tag: #medium, #bfs, #queue
    * Company:
    * Date: 11/22/2022
    * Time Complexity: 
    * Space Complexity:
    */

    internal class NearestExit
    {
        public int solve(char[][] maze, int[] entrance)
        {
            int rowCount = maze.GetLength(0) - 1;
            int colCount = maze[0].Length - 1;

            Queue<List<int>> nodes = new Queue<List<int>>();
            nodes.Enqueue(new List<int>() { entrance[0], entrance[1], 0 });

            Func<int, int, bool> edgeReached = (x, y) =>
                (x == 0 || x == rowCount
                        || y == 0 || y == colCount);

            Func<int, int, bool> checkBound = (x, y) =>
                (x >= 0 && x <= rowCount) && (y >= 0 && y <= colCount);


            //#bfs
            while (nodes.Count > 0)
            {
                //dequeue
                var cordinates = nodes.Dequeue();
                int x = cordinates[0];
                int y = cordinates[1];
                int pathsCrossed = cordinates[2];

                //top
                if (checkBound(x - 1, y) && maze[x - 1][y] != '+')
                {
                    if (edgeReached(x - 1, y)) return pathsCrossed + 1;
                    nodes.Enqueue(new List<int>() { x - 1, y, pathsCrossed + 1 });
                }

                //bottom
                if (checkBound(x + 1, y) && maze[x + 1][y] != '+')
                {
                    if (edgeReached(x + 1, y)) return pathsCrossed + 1;
                    nodes.Enqueue(new List<int>() { x + 1, y, pathsCrossed + 1 });
                }

                //left
                if (checkBound(x, y - 1) && maze[x][y - 1] != '+')
                {
                    if (edgeReached(x, y - 1)) return pathsCrossed + 1;
                    nodes.Enqueue(new List<int>() { x, y - 1, pathsCrossed + 1 });
                }

                //right
                if (checkBound(x, y + 1) && maze[x][y + 1] != '+')
                {
                    if (edgeReached(x, y + 1)) return pathsCrossed + 1;
                    nodes.Enqueue(new List<int>() { x, y + 1, pathsCrossed + 1 });
                }

                //mark the path processed item as visited
                maze[x][y] = '+';

            }
            return -1;
        }

        public int solveV2(char[][] maze, int[] entrance)
        {
            int rows = maze.Length;
            int cols = maze[0].Length;
            int moves = 0;

            List<(int x, int y)> directions = new List<(int, int)>()
            {
                (0, 1),     // right
                (1, 0),     // down
                (-1, 0),    // up
                (0, -1),    // left
            };

            int srcRow = entrance[0];
            int srcCol = entrance[1];

            Queue<(int x, int y)> queue = new Queue<(int x, int y)>();            
            maze[srcRow][srcCol] = '+'; // visited
            queue.Enqueue((srcRow, srcCol));

            while (queue.Count > 0)
            {
                int s = queue.Count;
                moves++;
                while (s-- > 0)
                {
                    (int x, int y) = queue.Dequeue();
                    for (int i = 0; i < directions.Count; i++)
                    {
                        int p = x + directions[i].x;
                        int q = y + directions[i].y;

                        if (p < 0 || q < 0 || p > rows - 1 || q > cols - 1 || maze[p][q] == '+')
                        {
                            continue; // outside matrix or visited
                        }

                        if (p == 0 || q == 0 || p == rows - 1 || q == cols - 1)
                        {
                            return moves; // reached exit 
                        }
                        maze[p][q] = '+'; // mark visited
                        queue.Enqueue((p, q));
                    }
                }
            }
            return -1; // no exits
        }

        public void Driver()
        {
            char[][] maze = new[] {
                            new []{'+', '+', '.', '+' },
                            new []{'.', '.', '.', '+' },
                            new []{ '+', '+', '+', '.'}
                            };

            //char[][] maze = new[] {
            //                new []{'+','.','+','+','+','+','+'},
            //                new []{'+','.','+','.','.','.','+'},
            //                new []{'+','.','+','.','+','.','+'},
            //                new []{'+','.','.','.','.','.','+'},
            //                new []{'+','+','+','+','.','+','.'}
            //                }; // {0, 1}

            int[] entrance = { 1,2 };

            var retVal = solveV2(maze, entrance);
            Console.WriteLine($"NearestExit:{retVal}");
        }
    }
}
