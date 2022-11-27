using System;
using System.Collections.Generic;
using System.Text;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/valid-sudoku/description/
    * LeetCode:36. Valid Sudoku
    * Tag: #medium, #hashset
    * Company:
    * Date: 11/24/2022
    * Time Complexity: O(n^2)
    * Space Complexity:O(m+n)
    */
    internal class IsValidSudoku
    {
        public bool solve(char[][] board)
        {
            //step01: create hashset to maintain list of unique entries in row, col, box
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] != '.')
                    {
                        String row = "row" + i + board[i][j];
                        String col = "col" + j + board[i][j];
                        String box = "box" + ((i / 3) * 3 + (j / 3)) + board[i][j];
                        if (set.Contains(row) || set.Contains(col) || set.Contains(box))
                        {
                            return false;
                        }
                        else
                        {
                            set.Add(row);
                            set.Add(col);
                            set.Add(box);
                        }
                    }
                }
            }
            return true;
        }

        public void Driver()
        {

        }
    }
}
